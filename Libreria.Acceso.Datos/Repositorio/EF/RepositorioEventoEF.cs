using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.EF
{
    public class RepositorioEventoEF : IRepositorioEvento
    {


        private LibreriaContext _db;
        public RepositorioEventoEF(LibreriaContext db)
        {
            _db = db;
        }


        public void Add(Evento objeto)
        {
            List<PuntajeAtleta> pa = new List<PuntajeAtleta>();
            objeto.Disciplina = _db.Disciplina.Find(objeto.Disciplina.Id);

            if (objeto.AtletasParticipantes != null && objeto.AtletasParticipantes.Count > 0)
            {
                foreach (var item in objeto.AtletasParticipantes)
                {
                    pa.Add(new PuntajeAtleta
                    {
                        Atleta = _db.Atletas.Find(item.Atleta.Id)
                    });
                }
            }

            objeto.AtletasParticipantes = pa;


            _db.Eventos.Add(objeto);

            _db.SaveChanges();




        }



        public IEnumerable<Evento> FindAll()
        {
            try
            {
                return _db.Eventos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las disciplinas", ex);
            }
        }












        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Evento> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public Evento FindById(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(Evento objeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PuntajeAtleta> FindAtletasDelEvento(int idEvento)
        {
            {
                try
                {
                    // Encontrar el evento con los atletas asociados (relación muchos a muchos a través de PuntajeAtleta)
                    var evento = _db.Eventos
                        .Include(e => e.AtletasParticipantes) // Incluir la relación con PuntajeAtleta
                            .ThenInclude(pa => pa.Atleta) // Incluir los atletas dentro de PuntajeAtleta
                        .FirstOrDefault(e => e.Id == idEvento);

                    // Verificar que el evento exista
                    if (evento == null)
                    {
                        throw new Exception("Evento no encontrado");
                    }

                    // Retornar la lista de PuntajeAtleta asociados al evento
                    return evento.AtletasParticipantes.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los atletas del evento", ex);
                }
            }

        }




        //API
        public IEnumerable<Evento> FindAllByAtletaId(int id)
        {
            try
            {
                var eventos = _db.Eventos.Include(e => e.Disciplina)
                                         .Include(e => e.AtletasParticipantes)
                                         .Where(e => e.AtletasParticipantes.Any(a => a.AtletaId == id))
                                         .OrderBy(e => e.Disciplina.Nombre)
                                         .ToList();

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener eventos", ex);
            }
        }





        public List<Evento> FindAllByDate(DateTime fecha)
        {
            return _db.Eventos.Where(a => a.FechaDeInicio == fecha).ToList();
        }



        public bool FindByNombre(string nombreEvento)
        {
            return _db.Eventos.Any(e => e.NombreDePrueba == nombreEvento);
        }
        //Si lo encuentra retorna true







        /*RF5*/


        //Version 2 
        public List<Evento> FiltroEvento(
            int? disciplinaId,
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string? nombreEvento,
            int? puntajeMin,
            int? puntajeMax)
        {
            try
            {
                var query = _db.Eventos
                    .Include(e => e.Disciplina)
                    .Include(e => e.AtletasParticipantes)
                    .AsEnumerable();

                // Filtro por disciplina
                if (disciplinaId != null)
                {
                    query = query.Where(e => e.Disciplina.Id == disciplinaId).AsEnumerable();
                }

                // Filtro por fechas
                if (fechaInicio != null && fechaFin != null)
                {
                    var inicio = fechaInicio.Value.Date;
                    var fin = fechaFin.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(e => e.FechaDeInicio >= inicio && e.FechaDeFin <= fin);
                }

                // Filtro por nombre del evento
                if (!string.IsNullOrWhiteSpace(nombreEvento))
                {
                    query = query.Where(e => e.NombreDePrueba.ToLower().Contains(nombreEvento.ToLower()));
                }

                // Filtro por rango de puntajes
                if (puntajeMin != null && puntajeMax != null)
                {
                    query = query.Where(e => e.AtletasParticipantes.Any(ap =>
                        ap.PuntosAtletas >= puntajeMin && ap.PuntosAtletas <= puntajeMax));
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("No se encontraron eventos para el filtro deseado", ex);
            }
        }





        public bool DisciplinaEstaEnEventos(int idDisciplina)
        {
            return _db.Eventos
                             .Any(e => e.Disciplina.Id == idDisciplina);
        }



































        public PuntajeAtleta RegistroPuntaje(PuntajeAtleta PuntajeNuevo)
        {
            throw new NotImplementedException();
        }







    }
}
