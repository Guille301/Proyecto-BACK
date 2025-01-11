using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Evento;
using Compartido.DTOS.Mappers;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Evento
{
    public class AltaEvento : IAltaEvento
    {


        private readonly IRepositorioAtleta _repoAtleta;
        private readonly IRepositorioDisciplina _repoDisciplina;
        private readonly IRepositorioEvento _repoEvento;


        public AltaEvento(IRepositorioAtleta repoAtleta,IRepositorioDisciplina repoDisciplina, IRepositorioEvento repoEvento )
        {
            _repoAtleta = repoAtleta;
            _repoDisciplina = repoDisciplina;
            _repoEvento = repoEvento;

        }

        public EventoAltaDto HacerAltaEvento()
        {
            List<Atleta> atletas = (List<Atleta>)_repoAtleta.FindAll();
            List<LogicaNegocio.Entidades.Disciplina> disciplinas = (List<LogicaNegocio.Entidades.Disciplina>)_repoDisciplina.FindAll();

            List<ListarAtletaDto> dtoAtletas = AtletaMappers.FromListAtletaToListDtoListarAtletas(atletas);
            List<ListarDisciplina> dtoDisciplinas = DisciplinaMappers.FromListDisciplinaToListDtoDisciplina(disciplinas);

            EventoAltaDto altaEvento = new EventoAltaDto();
            altaEvento.atletas = dtoAtletas;
            altaEvento.disciplinas = dtoDisciplinas;
            
            
            return altaEvento;

        }




        public void Ejecutar(EventoAltaDto eventoAltaDto)
        {
            if (string.IsNullOrWhiteSpace(eventoAltaDto.NombreDePrueba) ||
                  eventoAltaDto.FechaDeInicio == DateTime.MinValue ||
    eventoAltaDto.FechaDeFin == DateTime.MinValue ||
    
    eventoAltaDto.ListaSeleccionAtletas == null || !eventoAltaDto.ListaSeleccionAtletas.Any() ||
    eventoAltaDto.DisciplinaId <= 0)
            {
                throw new DatosVaciosEvento("Datos vacios");
            }
            if (eventoAltaDto.ListaSeleccionAtletas.Count < 3)
            {
                throw new FaltanAtletas("El evento debe tener al menos tres atletas registrados.");
            }
            if (_repoEvento.FindByNombre(eventoAltaDto.NombreDePrueba))
            {
                throw new Exception("Ya existe una evento con este nombre!");
            }
            if (eventoAltaDto.FechaDeInicio > eventoAltaDto.FechaDeFin)
            {
                throw new FechaInvalida("La fecha de inicio debe ser anterior a la fecha de finalización.");
            }

            //Busco la disciplina seleccionada
            Libreria.LogicaNegocio.Entidades.Disciplina disciplina = _repoDisciplina.FindById(eventoAltaDto.DisciplinaId);
            List<Atleta> listaDeAtletasParticipantes = new List<Atleta>();

    

            //Busco a los atletas seleccionados
            foreach (Atleta a in _repoAtleta.FindAllWithDisciplinas())
            {
                foreach (int id in eventoAltaDto.ListaSeleccionAtletas)
                {
                    if (a.Id == id)
                    {
                        listaDeAtletasParticipantes.Add(a);
                    }
                }
            }


            foreach (Atleta atleta in listaDeAtletasParticipantes)
            {
                if (!atleta.Disciplinas.Contains(disciplina))
                {
                    throw new Exception("Error");
                }
            }




            LogicaNegocio.Entidades.Evento nuevo = EventoMappers.FromDto(eventoAltaDto);

            _repoEvento.Add(nuevo);


           

        }

















    }
}
