using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos
{
    public class FechaInvalida : Exception
    {

        public FechaInvalida(string message) : base(message) { }

    }
}
