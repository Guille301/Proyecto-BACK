using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.EF
{
    public class RepositorioAtletasDelEventoEF : IRepositorioAtletasParticipantes
    {



        private LibreriaContext _db;
        public RepositorioAtletasDelEventoEF(LibreriaContext db)
        {
            _db = db;
        }



        public void Update(PuntajeAtleta puntajeAtletaActualizado)
        {
            try
            {
               
                _db.PuntajesAtletas.Update(puntajeAtletaActualizado);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar PuntajeAtleta", ex);
            }
        }



        public PuntajeAtleta FindByIdEspecifico(int idAtleta, int idEvento)
        {
            try
            {
                // Buscar el puntaje utilizando ambos identificadores
                var part = _db.PuntajesAtletas.Include(p => p.Atleta).Include(p => p.Evento)
                    .FirstOrDefault(p => p.AtletaId == idAtleta && p.EventoId == idEvento);

                return part;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Participantes", ex);
            }
        }








        public void Add(PuntajeAtleta objeto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PuntajeAtleta> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PuntajeAtleta> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public PuntajeAtleta FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
