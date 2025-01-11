using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas
{
    public class ErrorDeDatosDisciplina : Exception
    {

        public ErrorDeDatosDisciplina(string message) : base(message) { }


    }
}
