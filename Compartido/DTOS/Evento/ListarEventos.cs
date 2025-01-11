using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Evento
{
    public class ListarEventos
    {
        public int Id { get; set; }

        public string NombreDePrueba { get; set; }
        public DateTime FechaDeInicio { get; set; }

        public ListarEventos()
        {
            
        }



    }
}
