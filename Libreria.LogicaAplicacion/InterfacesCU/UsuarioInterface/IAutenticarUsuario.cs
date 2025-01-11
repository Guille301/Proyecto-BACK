using Compartido.DTOS.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface
{
    public interface IAutenticarUsuario
    {

        UsuarioBasicoDto Ejecutar(string email, string contra);

    }
}
