using Compartido.DTOS.Disciplina;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina
{
    public class EliminarDisciplina : IEliminarDisciplina
    {


        private readonly IRepositorioDisciplina _repositorioDis;
        private readonly IRepositorioEvento _repoEvento;
        public EliminarDisciplina(IRepositorioDisciplina repositorioDis, IRepositorioEvento repoEvento)
        {
            _repositorioDis = repositorioDis;
            _repoEvento = repoEvento;
        }


        public void Ejecutar(int id)
        {
            try
            {

                if (_repositorioDis.TieneAtletas(id))
                {
                    throw new Exception("No se puede eliminar la disciplina porque tiene atletas asociados.");
                }


                if (_repoEvento.DisciplinaEstaEnEventos(id))
                {
                    throw new Exception("No se puede eliminar la disciplina porque está asociada a uno o más eventos.");
                }



                _repositorioDis.Delete(id); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la disciplina.", ex);
            }
        }

    }
}
