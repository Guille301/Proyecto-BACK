using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.PuntajeAtleta
{
    public class PuntajeAtletaDto
    {

        public int PuntosAtletas { get; set; }
        public int EventoId { get; set; }
        public int AtletaId { get; set; }


    }
}
