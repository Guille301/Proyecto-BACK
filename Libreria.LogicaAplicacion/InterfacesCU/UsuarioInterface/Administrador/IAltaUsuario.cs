using Compartido.DTOS.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador
{
    public interface IAltaUsuario
    {
      public void Ejecutar(UsuarioAltaDto usuarioDTO);
    }
}
