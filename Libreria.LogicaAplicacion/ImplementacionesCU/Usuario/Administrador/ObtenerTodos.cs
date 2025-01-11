using Compartido.DTOS.Mappers;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador
{
    public class ObtenerTodos : IObtenerTodos
    {
        private IRepositorioUsuario _repoUsuario; 
        public ObtenerTodos(IRepositorioUsuario _repoUsuario)
        {
            this._repoUsuario = _repoUsuario;
        }
        public IEnumerable<UsuarioBasicoDto> Ejecutar()
        {
            var usuarios = _repoUsuario.FindAll();

            var usuariosDto = usuarios.Select(u => UsuarioMappers.ToUsuarioBasicoDto(u));
            return usuariosDto;
        }
    }
}
