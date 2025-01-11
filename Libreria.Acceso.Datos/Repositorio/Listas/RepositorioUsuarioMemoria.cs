using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.Listas
{
    public class RepositorioUsuarioMemoria : IRepositorioUsuario
    {



        private static List<Usuario> _usuarios = new List<Usuario>();

        /***Alta ****/
        private static int _ultimoId = 1;
        public void Add(Usuario usuario)
        {
            try
            {
                usuario.Id = _ultimoId++;
                _usuarios.Add(usuario);
            }
            catch (Exception ex)
            {

                throw;
            };
        }

        /*****Delete*****/
        public void Delete(int id)
        {
            var usuario = FindById(id);

            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException($"No existe el usuario id {id}");
            }

            _usuarios.Remove(usuario);
        }


        public Usuario FindById(int id)
        {
            Usuario usuarioBuscado = null;

            foreach (Usuario u in _usuarios)
            {
                if (u.Id == id)
                {
                    usuarioBuscado = u;
                    return usuarioBuscado;
                }
            }
            throw new UsuarioNoEncontradoException($"No existe el usuario id {id}");
        }


        public Usuario FindByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new UsuarioException("El email no puede ser nulo ni vacío");


            Usuario usuarioBuscado = null;

            foreach (Usuario u in _usuarios)
            {
                if (u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase))
                {
                    usuarioBuscado = u;
                    return usuarioBuscado;
                }
            }
            return usuarioBuscado;
        }

        public IEnumerable<Usuario> FindByRol(string rol)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario objeto)
        {
            Usuario usuarioExistente = FindById(objeto.Id);
            Usuario usuarioConMismoMail = FindByEmail(objeto.Email);
            if (usuarioConMismoMail != null && usuarioConMismoMail.Id != objeto.Id)
            {
                throw new UsuarioException("Ya existe un usuario con ese email");
            }
            if (usuarioExistente != null)
            {
                usuarioExistente.Email = objeto.Email;
                usuarioExistente.Rol = objeto.Rol;
                usuarioExistente.Contraseña = objeto.Contraseña;
            }
        }



        public IEnumerable<Usuario> FindAll()
        {
            return _usuarios;

        }

        public IEnumerable<Usuario> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }
    }
}
