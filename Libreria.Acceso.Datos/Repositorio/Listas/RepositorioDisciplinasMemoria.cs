using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Acceso.Datos.Repositorio.Listas
{
    internal class RepositorioDisciplinasMemoria : IRepositorioDisciplina
    {
        private static List<Disciplina> _dis = new List<Disciplina>();

        /***Alta ****/
        private static int _ultimoId = 1;
        public void Add(Disciplina disciplina)
        {
            try
            {
                disciplina.Id = _ultimoId++;
                _dis.Add(disciplina);
            }
            catch (Exception ex)
            {

                throw;
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disciplina> FindAll()
        {
            return _dis;
        }

        public IEnumerable<Disciplina> FindAllOrdenado()
        {
            throw new NotImplementedException();
        }

        public Disciplina FindById(int id)
        {
            Disciplina DisciplinaBuscado = null;

            foreach (Disciplina u in _dis)
            {
                if (u.Id == id)
                {
                    DisciplinaBuscado = u;
                    return DisciplinaBuscado;
                }
            }
            throw new NotImplementedException($"No existe el usuario id {id}");
        }

        public Disciplina FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool TieneAtletas(int idDisciplina)
        {
            throw new NotImplementedException();
        }

        public void Update(Disciplina objeto)
        {
            throw new NotImplementedException();
        }
    }
}
