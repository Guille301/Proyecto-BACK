using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.EF
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {


        private LibreriaContext _db;
        public RepositorioUsuarioEF(LibreriaContext db)
        {
            _db = db;
        }

        /*Alta*/
        public void Add(Usuario usuario)
        {
            try
            {
                  _db.Usuarios.Add(usuario);
                  _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario", ex);
            }
        }

        /*Delete*/
        public void Delete(int id)
        {
                 var usuario = _db.Usuarios.Find(id);
            try
            {
                        _db.Usuarios.Remove(usuario);
                        _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            try
            {
                return _db.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios", ex);
            }
        }

        public IEnumerable<Usuario> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public Usuario FindByEmail(string email)
        {
            try
            {
               var usuario = _db.Usuarios.Where(u => u.Email == email).FirstOrDefault();
               return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios", ex);
            }
        }

        public Usuario FindById(int id)
        {
            try
            {
                var usuario = _db.Usuarios.Find(id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios", ex);
            }
        }

        public IEnumerable<Usuario> FindByRol(string rol)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario usuarioCambiado)
        {
            var usuarioOriginal = _db.Usuarios.Find(usuarioCambiado.Id);
            try
            {
                usuarioOriginal.Email = usuarioCambiado.Email;
                usuarioOriginal.Contraseña = usuarioCambiado.Contraseña;
                usuarioOriginal.Rol = usuarioCambiado.Rol;
                _db.Usuarios.Update(usuarioOriginal);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
      







    }
}
