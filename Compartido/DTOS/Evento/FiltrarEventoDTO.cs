using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Evento
{
    public class FiltrarEventoDTO
    {
        public int IdDisciplina { get; set; }

        public string NombreDePrueba { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFin { get; set; }

        public int RangoPuntaje1 { get; set; }

        public int RangoPuntaje2 { get; set; }

        public FiltrarEventoDTO()
        {

        }






    }
}
