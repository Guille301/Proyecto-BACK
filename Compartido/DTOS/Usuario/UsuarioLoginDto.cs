using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Usuario
{
    public class UsuarioLoginDto : UsuarioBasicoDto
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        

        public UsuarioLoginDto()
        {
                
        }
        public UsuarioLoginDto(string email, string contrasenia)
        {
                Email = email;
                Contrasenia = contrasenia;
        }
    }
}
