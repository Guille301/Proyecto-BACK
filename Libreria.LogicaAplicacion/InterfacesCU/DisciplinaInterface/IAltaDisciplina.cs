using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface
{
    public interface IAltaDisciplina
    {

        public void Ejecutar(DisciplinaAltaDto DisciplinaDTO);



    }
}
