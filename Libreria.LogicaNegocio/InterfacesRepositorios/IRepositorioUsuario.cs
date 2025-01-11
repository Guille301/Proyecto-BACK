using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {

        public IEnumerable<Usuario> FindByRol(string rol);
        public Usuario Login(string email, string password);
        public Usuario FindByEmail(string email);

        public void Delete(int id);

        public void Add(Usuario usuario);


    }
}
