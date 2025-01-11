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
    public class RepositorioDisciplinaEF : IRepositorioDisciplina
    {
        private LibreriaContext _db;
        public RepositorioDisciplinaEF(LibreriaContext db)
        {
            _db = db;
        }

        /*Alta*/
        public void Add(Disciplina dis)
        {
            try
            {
                _db.Disciplina.Add(dis);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario", ex);
            }
        }


        public void Delete(int id)
        {
            var disciplina = _db.Disciplina.Find(id); 

            if (disciplina != null)
            {
                _db.Disciplina.Remove(disciplina);  // Elimina la disciplina del DbContext
                _db.SaveChanges();  // Guardar cambios en la base de datos
            }
            else
            {
                throw new Exception("Disciplina no encontrada");
            }
        }


        public IEnumerable<Disciplina> FindAll()
        {
            try
            {
                return _db.Disciplina.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las disciplinas", ex);
            }
        }

        public IEnumerable<Disciplina> FindAllOrdenado()
        {
            
                return _db.Disciplina.OrderBy(d => d.Nombre).ToList();
            
            
        }

        public Disciplina FindById(int id)
        {
            try
            {
                var disiplina = _db.Disciplina.Find(id);
                return disiplina;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Disciplina", ex);
            }
        }
        public Disciplina FindByName(string name)
        {
            try
            {
                var disciplina = _db.Disciplina
                                    .FirstOrDefault(d => d.Nombre == name);

                return disciplina;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la Disciplina con ese nombre", ex);
            }
        }

        public void Update(Disciplina disCambiado)
        {
            var disOriginal = _db.Disciplina.Find(disCambiado.Id);
            try
            {
                disOriginal.Nombre = disCambiado.Nombre;
                disOriginal.AnoDeIntegracion = disCambiado.AnoDeIntegracion;
              
                _db.Disciplina.Update(disOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public bool TieneAtletas(int idDisciplina)
        {
            return _db.Disciplina
                             .Any(d => d.Id == idDisciplina && d.Atletas.Any());
        }














    }
}
