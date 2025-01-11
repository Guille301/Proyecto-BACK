using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Auditoria
{
    public class AuditoriaDto
    {
        public string Operacion { get; set; } 
        public string Entidad { get; set; }   
        public int EntidadId { get; set; }  
        public DateTime Fecha { get; set; }  
        public string UsuarioEmail { get; set; } 
    }
}
