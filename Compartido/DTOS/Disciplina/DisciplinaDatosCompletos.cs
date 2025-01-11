using Compartido.DTOS.Atleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Disciplina
{
    public class DisciplinaDatosCompletos
    {

        public string Nombre { get; set; }
        public int Id { get; set; }
        public DateTime AnoDeIntegracion { get; set; }


        public List<AtletaDatosCompletosDto> Atletas { get; set; } = new List<AtletaDatosCompletosDto>();


        public DisciplinaDatosCompletos()
        {
            
        }


    }
}
