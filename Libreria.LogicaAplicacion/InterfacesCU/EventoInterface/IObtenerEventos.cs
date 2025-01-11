using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.EventoInterface
{
    public interface IObtenerEventos
    {

        IEnumerable<ListarEventos> EjecutarListarEventos(DateTime fecheDeEvento);
        IEnumerable<LogicaNegocio.Entidades.Evento> EjecutarListarEventosPorAtleta(int id);




    }
}
