using Compartido.DTOS.Atleta;
using Compartido.DTOS.Evento;
using Compartido.DTOS.PuntajeAtleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.EventoInterface
{
    public interface IAtletasDeLosEventos
    {

        IEnumerable<ListarAtletasDeLosEventosDto> EjecutarListarAtletasDeLosEventos(int idEvento);



    }
}
