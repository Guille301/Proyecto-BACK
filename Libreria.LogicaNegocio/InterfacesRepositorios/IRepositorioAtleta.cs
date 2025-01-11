using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAtleta : IRepositorio<Atleta>
    {


        public void Delete(int id);

        public void Add(Atleta atletas);
        void AsignarDis(int idA, int idD);

        public List<Atleta> FindAllWithDisciplinas();

        public bool AtletaTieneEsaDisciplina(int idAtleta, int idDisciplina);

        public List<Atleta> ListarPorDisciplina(int idD);


    }
}
