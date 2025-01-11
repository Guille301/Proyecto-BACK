using Compartido.DTOS.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Mappers
{
    public class UsuarioMappers
    {

        /**** Alta ****/
        public static Libreria.LogicaNegocio.Entidades.Usuario FromUsuarioAltaDto(UsuarioAltaDto usuarioAltaDto)
        {
            Libreria.LogicaNegocio.Entidades.Usuario usu = new Libreria.LogicaNegocio.Entidades.Usuario(usuarioAltaDto.Email, usuarioAltaDto.Contraseña, usuarioAltaDto.Rol);
            usu.FechaCreacion = usuarioAltaDto.FechaAlta;
            usu.CreadoPor = usuarioAltaDto.AdmAlta;
            return usu;

        }


        public static UsuarioBasicoDto ToUsuarioBasicoDto(Libreria.LogicaNegocio.Entidades.Usuario usuario)
        {
            return new UsuarioBasicoDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Rol = usuario.Rol,
            };
        }




        public static Libreria.LogicaNegocio.Entidades.Usuario FromUsuarioModificacionDto(UsuarioAltaDto usuarioDto)
        {
            return new Libreria.LogicaNegocio.Entidades.Usuario(usuarioDto.Id, usuarioDto.Email, usuarioDto.Contraseña, usuarioDto.Rol);
        }



        public static Libreria.LogicaNegocio.Entidades.Usuario FromLoginDto(UsuarioLoginDto usuarioLoginDto)
        {
            return new Libreria.LogicaNegocio.Entidades.Usuario
            {
                Email = usuarioLoginDto.Email,
                Contraseña = usuarioLoginDto.Contrasenia
            };
        }




    }
}
