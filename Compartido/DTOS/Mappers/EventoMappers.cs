using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Evento;
using Compartido.DTOS.PuntajeAtleta;
using Compartido.DTOS.Usuario;
using Libreria.LogicaNegocio.Entidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class EventoMappers
    {
        public static Libreria.LogicaNegocio.Entidades.Evento FromDto(EventoAltaDto eventoAltaDto)
        {

            if (eventoAltaDto != null)
            {
                return new Libreria.LogicaNegocio.Entidades.Evento
                {
                    Disciplina = new Libreria.LogicaNegocio.Entidades.Disciplina { Id = eventoAltaDto.DisciplinaId },
                    NombreDePrueba = eventoAltaDto.NombreDePrueba,
                    FechaDeInicio = eventoAltaDto.FechaDeInicio,
                    FechaDeFin = eventoAltaDto.FechaDeFin,
                    AtletasParticipantes = eventoAltaDto.ListaSeleccionAtletas.Select(a => new Libreria.LogicaNegocio.Entidades.PuntajeAtleta { Atleta = new Libreria.LogicaNegocio.Entidades.Atleta { Id = a },AtletaId = a }).ToList(),
                    //AtletasParticipantes = pa
                };
                
            }
            return null;
        }

        public static Libreria.LogicaNegocio.Entidades.Evento FromDtoAltaEventoToEvento(EventoAltaDto dto)
        {
            Libreria.LogicaNegocio.Entidades.Evento evento = new Libreria.LogicaNegocio.Entidades.Evento();
            evento.NombreDePrueba = dto.NombreDePrueba;
            evento.Disciplina = DisciplinaMappers.FromDto(dto.Disciplina);
            evento.FechaDeInicio = dto.FechaDeInicio;
            evento.FechaDeFin = dto.FechaDeInicio;

            foreach (var item in dto.atletas)
            {
                evento.AtletasParticipantes.Add(new Libreria.LogicaNegocio.Entidades.PuntajeAtleta() { AtletaId = item.id });
            };
            return evento;
        }

        public static List<ListarEventos> FromDtoListarEventos(List<Libreria.LogicaNegocio.Entidades.Evento> ListaEventoDto)
        {
            List<ListarEventos> listaEventos = new List<ListarEventos>();

            foreach (Libreria.LogicaNegocio.Entidades.Evento evento in ListaEventoDto)
            {
                ListarEventos dtoEvento = new ListarEventos();
                dtoEvento.Id = evento.Id;
                dtoEvento.NombreDePrueba = evento.NombreDePrueba;
                dtoEvento.FechaDeInicio = evento.FechaDeInicio;

                listaEventos.Add(dtoEvento);
            }
            return listaEventos;



        }


        public static List<FiltrarEventoDTO> FromDtoFiltrarEventos(List<Libreria.LogicaNegocio.Entidades.Evento> listaEventos)
        {
            List<FiltrarEventoDTO> listaFiltrarEventosDto = new List<FiltrarEventoDTO>();

            foreach (var evento in listaEventos)
            {
                // Inicializamos los valores del rango de puntajes a 0 si no hay atletas participantes
                int rangoPuntaje1 = 0;
                int rangoPuntaje2 = 0;

                if (evento.AtletasParticipantes != null && evento.AtletasParticipantes.Any())
                {
                    rangoPuntaje1 = evento.AtletasParticipantes.Min(p => p.PuntosAtletas);
                    rangoPuntaje2 = evento.AtletasParticipantes.Max(p => p.PuntosAtletas);
                }

                FiltrarEventoDTO dto = new FiltrarEventoDTO
                {
                    IdDisciplina = evento.Disciplina.Id,
                    NombreDePrueba = evento.NombreDePrueba,
                    FechaDeInicio = evento.FechaDeInicio,
                    FechaDeFin = evento.FechaDeFin,
                    RangoPuntaje1 = rangoPuntaje1,
                    RangoPuntaje2 = rangoPuntaje2
                };

                listaFiltrarEventosDto.Add(dto);
            }

            return listaFiltrarEventosDto;
        }






        public static ListarAtletasDeLosEventosDto FromDtoListarLosAtletasDeLosEventos(Libreria.LogicaNegocio.Entidades.PuntajeAtleta dto)
        {

            return new ListarAtletasDeLosEventosDto
            {
                idAtleta = dto.Atleta.Id,
                Nombre = dto.Atleta.Nombre,
                PuntosAtletas = dto.PuntosAtletas,
                idEvento = dto.Evento.Id,

            };



        }

        /*Registro puntaje */


     






















































    }
}
