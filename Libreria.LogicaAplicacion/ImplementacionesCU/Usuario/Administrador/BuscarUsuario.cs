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
    public class BuscarUsuario : IBuscarUsuario
    {


        private IRepositorioUsuario _repositorioUsuario;

        public BuscarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }


        public UsuarioBasicoDto Ejecutar(int id)
        {

            LogicaNegocio.Entidades.Usuario usu = _repositorioUsuario.FindById(id);

            UsuarioBasicoDto usuarioDto = UsuarioMappers.ToUsuarioBasicoDto(usu);

            return usuarioDto;


        }



    }
}
