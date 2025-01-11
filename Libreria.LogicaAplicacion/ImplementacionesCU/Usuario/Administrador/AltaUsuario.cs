using Compartido.DTOS.Mappers;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador
{
    public class AltaUsuario : IAltaUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuarios;

        public AltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repositorioUsuarios = repoUsuario;

        }



        public void Ejecutar(UsuarioAltaDto usuarioDTO)
        {
            LogicaNegocio.Entidades.Usuario usrexistente = _repositorioUsuarios.FindByEmail(usuarioDTO.Email);
            if (usrexistente == null)
            {
                LogicaNegocio.Entidades.Usuario usr = UsuarioMappers.FromUsuarioAltaDto(usuarioDTO);
                _repositorioUsuarios.Add(usr);
            }
            else 
            {
                throw new UsuarioException("Existe ya un usuario con ese email! intenta denuevo");
            }


        }

        /*Pasos
         1. Crear un usuario igual al de la entidad de negocio(usuario) y mapearlo.
         2. Debo Usuario usuarioNuevo = UsuarioMapper.FromLoginDto(usuario) 
         3. _repositorioUsuarios.Add(usuarioNuevo)
         */

    }
}
