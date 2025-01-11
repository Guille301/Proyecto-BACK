using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Usuario
{
    public class AutenticarUsuarioDto
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
        //public string Rol { get; set; }

        public AutenticarUsuarioDto()
        {

        }
        public AutenticarUsuarioDto(string email, string contrasenia)
        {
            Email = email;
            Contraseña = contrasenia;
        }


    }
}
