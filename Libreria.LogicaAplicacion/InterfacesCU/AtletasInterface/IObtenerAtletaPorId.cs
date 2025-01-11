using Compartido.DTOS.Atleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface
{
    public interface IObtenerAtletaPorId
    {


        IEnumerable<AtletaDatosCompletosDto> Ejecutar( int idD);





    }
}
