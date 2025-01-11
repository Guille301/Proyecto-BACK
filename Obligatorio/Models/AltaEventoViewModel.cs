using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Evento;

namespace Obligatorio.Models
{
    public class AltaEventoViewModel
    {
        public EventoAltaDto Dto { get; set; }
        public IEnumerable<DisciplinaDatosCompletos> Disciplinas { get; set; }
    }
}
