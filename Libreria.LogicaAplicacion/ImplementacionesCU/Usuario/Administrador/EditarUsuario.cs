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
    public class EditarUsuario : IEditarUsuario
    {


        private readonly IRepositorioUsuario _repositorioUsuario;
        public EditarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(UsuarioAltaDto usuarioDto)
        {
            if (usuarioDto == null || usuarioDto.Email == null || usuarioDto.Id <= 0)
            {
                throw new Exception("El usuario no es válido");
            }
            var usuarioExistente = _repositorioUsuario.FindByEmail(usuarioDto.Email);
            if (_repositorioUsuario.FindByEmail(usuarioDto.Email) != null && usuarioDto.Email != usuarioExistente.Email)
            {
                throw new InvalidOperationException("El email ya está en uso");
            }
            // Mapear el usuarioDto a un Usuario

            Libreria.LogicaNegocio.Entidades.Usuario usuario = UsuarioMappers.FromUsuarioModificacionDto(usuarioDto);
            // Guardar el usuario pidiéndoselo a la capa de persistencia (Repositorio de usuarios)
            _repositorioUsuario.Update(usuario);
        }
    }
}
