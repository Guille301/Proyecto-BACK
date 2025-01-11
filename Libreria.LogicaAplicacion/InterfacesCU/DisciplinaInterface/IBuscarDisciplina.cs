using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface
{
    public interface IBuscarDisciplina
    {
        DisciplinaDatosCompletos Ejecutar(int id);

        DisciplinaDatosCompletos EjecutarPorNombre(string Nombre);


    }
}
