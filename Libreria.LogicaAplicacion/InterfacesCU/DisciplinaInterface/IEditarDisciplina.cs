using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface
{
    public interface IEditarDisciplina
    {

        void Ejecutar(EditarDisciplinaDTO editDis);

    }
}
