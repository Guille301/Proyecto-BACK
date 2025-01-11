using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {
        public void Delete(int id);

        public void Add(Disciplina disciplina);

        public IEnumerable<Disciplina> FindAllOrdenado();

        public Disciplina FindByName(string name);


        public bool TieneAtletas(int idDisciplina);


    }
}
