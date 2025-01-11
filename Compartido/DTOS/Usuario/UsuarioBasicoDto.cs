using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Usuario
{
    public class UsuarioBasicoDto
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Rol { get; set; }
        public string Contraseña { get; set; }
        public UsuarioBasicoDto()
        {
            
        }
        
    }
}
