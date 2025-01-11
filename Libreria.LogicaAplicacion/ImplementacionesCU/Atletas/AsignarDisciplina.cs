using Compartido.DTOS.Atleta;
using Compartido.DTOS.Disciplina;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Atletas
{
    public class AsignarDisciplina : IAsignarDisciplina
    {

        private IRepositorioAtleta _repositorioAtleta;



        public AsignarDisciplina(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }

        public void Ejecutar(int idA, int idD)
        {
           var verificacion =  _repositorioAtleta.AtletaTieneEsaDisciplina(idA, idD);

            if (_repositorioAtleta.AtletaTieneEsaDisciplina(idA, idD))
            {
                throw new DisciplinaYaAsignadaException("El atleta ya tiene esta disciplina asignada.");
            }



            _repositorioAtleta.AsignarDis(idA, idD);
        }

        
    }
}
