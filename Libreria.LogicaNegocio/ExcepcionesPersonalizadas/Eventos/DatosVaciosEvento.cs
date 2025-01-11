using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos
{
    public class DatosVaciosEvento : Exception
    {

        public DatosVaciosEvento(string message) : base(message) { }




    }
}
