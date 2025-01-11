using Compartido.DTOS.Disciplina;
using Compartido.DTOS.PuntajeAtleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface
{
    public interface IBuscarAtletaEnEvento
    {

        ListarAtletasDeLosEventosDto Ejecutar(int idAtleta, int idEvento);



    }
}
