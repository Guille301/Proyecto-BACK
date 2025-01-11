using Compartido.DTOS.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.EventoInterface
{
    public interface IFiltrarEventos
    {
        IEnumerable<FiltrarEventoDTO> EjecutarListarEventos(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string? nombreEvento, int? puntajeMin, int? puntajeMax);






    }
}
