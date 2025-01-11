using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOS.Evento
{
    public class EventoAltaDto
    {

        public List<ListarAtletaDto>  atletas { get; set; }
        public List<ListarDisciplina> disciplinas { get; set; }

        public DisciplinaDatosCompletos Disciplina { get; set; }
        public string NombreDePrueba { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFin { get; set; }

        public List<int> ListaSeleccionAtletas { get; set; }
        public int DisciplinaId { get; set; }




        /*    public EventoAltaDto(DisciplinaDatosCompletos? disciplina)
            {

            }*/

    }
}
