using Compartido.DTOS.Mappers;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Usuario
{
    public class AutenticarUsuario : IAutenticarUsuario
    {


        private IRepositorioUsuario _repositorioUsuario;

        public AutenticarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }


        public UsuarioBasicoDto Ejecutar(string email, string contra)
        {

            LogicaNegocio.Entidades.Usuario usu = _repositorioUsuario.FindByEmail(email);
            if (usu == null)
            {
                throw new UsuarioException("Usuario no existe!");
            }
            if (usu.Contraseña == contra)
            {
                UsuarioBasicoDto usuarioDto = UsuarioMappers.ToUsuarioBasicoDto(usu);
                return usuarioDto;

            }
            else 
            {
                throw new UsuarioException("Password incorrecta!");
            }    
        }
    }
}
