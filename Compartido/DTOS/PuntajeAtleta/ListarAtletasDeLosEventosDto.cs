using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.PuntajeAtleta
{
    public class ListarAtletasDeLosEventosDto
    {
        public int idAtleta { get; set; }
        public int idEvento { get; set; } 

        public string Nombre { get; set; }
        public int PuntosAtletas { get; set; }
    }

}
