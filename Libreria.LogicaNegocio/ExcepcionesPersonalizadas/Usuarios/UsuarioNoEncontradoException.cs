using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios
{
    public class UsuarioNoEncontradoException : UsuarioException
    {
        public UsuarioNoEncontradoException()
        {
        }

        public UsuarioNoEncontradoException(string? message) : base(message)
        {
        }

        public UsuarioNoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }



    }
}
