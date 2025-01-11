using Compartido.DTOS.PuntajeAtleta;
using Compartido.DTOS.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface
{
    public interface IRegistrarPuntaje
    {

        void Ejecutar(ListarAtletasDeLosEventosDto PuntajeDto);



    }
}
