using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos
{
    public class NoHayEventos : Exception
    {


        public NoHayEventos(string message) : base(message) { }


    }
}
