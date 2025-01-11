using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Operacion { get; set; } = string.Empty; // "Creado", "Editado", "Eliminado"
        public string Entidad { get; set; } = string.Empty;
        public int EntidadId { get; set; }
        public string UsuarioEmail { get; set; } = string.Empty;
    }

}
