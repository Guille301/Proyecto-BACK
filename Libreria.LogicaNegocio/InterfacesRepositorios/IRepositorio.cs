using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T>
    {
        public void Add(T objeto);
        public T FindById(int id);
        public void Delete(int id);
        public void Update(T objeto);
        public IEnumerable<T> FindAll();
        public IEnumerable<T> FindAllOrdenado();


    }
}
