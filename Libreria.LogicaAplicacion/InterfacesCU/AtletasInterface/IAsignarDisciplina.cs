using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface
{
    public interface IAsignarDisciplina
    {

        void Ejecutar(int idA, int idD);


    }
}
