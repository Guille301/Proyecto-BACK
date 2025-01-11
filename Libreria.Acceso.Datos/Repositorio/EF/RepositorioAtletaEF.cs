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
    public class RepositorioAtletaEF : IRepositorioAtleta
    {


        private LibreriaContext _db;
        public RepositorioAtletaEF(LibreriaContext db)
        {
            _db = db;
        }

        public void Add(Atleta atletas)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Atleta> FindAll()
        {
            try
            {

                var atletas = _db.Atletas.Include(a => a.Disciplinas).Include(P => P.Pais).ToList();   

                //Esto tenemos que cambiarlo para que no tenga guion bajo 
                return atletas;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios", ex);
            }
        }

        public IEnumerable<Atleta> FindAllOrdenado()
        {
            try
            {

                var atletas = _db.Atletas.Include(a => a.Disciplinas).Include(P => P.Pais).OrderBy(a => a.Pais.Nombre) // Ordena por País
                .ThenBy(a => a.Apellido) // Luego por Apellido
                .ThenBy(a => a.Nombre) // Luego por Nombre
                .ToList();

                return atletas;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios", ex);
            }
        }
        



        public Atleta FindById(int id)
        {
            try
            {
                var atleta = _db.Atletas.Find(id);
                return atleta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el atleta", ex);
            }
        }

        
        public void AsignarDis(int idAtleta, int idDisciplina)
        {
            try
            {
                 Atleta a = _db.Atletas.Find(idAtleta);
    
            Disciplina d = _db.Disciplina.Find(idDisciplina);

            a.AsignarDisciplina(d);
            _db.Update(a);

            _db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el atleta");
            }
           

        }

        public bool AtletaTieneEsaDisciplina(int idAtleta, int idDisciplina)
        {
            var atleta = _db.Atletas
                .Include(a => a.Disciplinas)
                .FirstOrDefault(a => a.Id == idAtleta);

            if (atleta == null)
            {
                return false; 
            }

            
            return atleta.Disciplinas.Any(d => d.Id == idDisciplina);
        }
        //devuelve true


        public IEnumerable<Atleta> ObtenerAtletasConDisciplinas()
        {
            try
            {
                var atletas = _db.Atletas
                    .Include(a => a.Disciplinas) 
                    .Select(a => new Atleta
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        Apellido = a.Apellido,
                        Sexo = a.Sexo,
                        Pais = a.Pais,
                        Disciplinas = a.Disciplinas.Select(d => new Disciplina
                        {
                            Id = d.Id,
                            Nombre = d.Nombre
                        }).ToList()
                    }).ToList();

                return atletas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los atletas con disciplinas", ex);
            }
        }





        public void Update(Atleta objeto)
        {
            throw new NotImplementedException();
        }





        public List<Atleta> FindAllWithDisciplinas()
        {
            return _db.Atletas.Include(a => a.Disciplinas).ToList();
        }




        public List<Atleta> ListarPorDisciplina(int idD)
        {
            var atletas = _db.Atletas
                .Include(a => a.Disciplinas) 
                .Include(a => a.Pais) 
                .Where(a => a.Disciplinas.Any(d => d.Id == idD)) 
                .OrderBy(a => a.Nombre) 
                .ToList(); 

            return atletas;
        }









    }
}
