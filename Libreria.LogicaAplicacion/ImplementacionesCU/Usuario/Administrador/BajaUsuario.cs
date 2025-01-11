using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador
{
    public class BajaUsuario : IBajaUsuario
    {


        private IRepositorioUsuario _repoUsuario;
        public BajaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public void Ejecutar(int id)
        {
            _repoUsuario.Delete(id);
        }
    }
}
