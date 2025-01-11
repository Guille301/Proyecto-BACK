using Compartido.DTOS.Atleta;
using Compartido.DTOS.Mappers;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Atletas
{
    public class ObtenerAtletaPorId : IObtenerAtletaPorId
    {



        private IRepositorioAtleta _repositorioAtleta;

        public ObtenerAtletaPorId(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }


        public IEnumerable<AtletaDatosCompletosDto> Ejecutar(int idD)
        {
            var atletas = _repositorioAtleta.ListarPorDisciplina(idD);

            var atletaDto = atletas.Select(u => Compartido.DTOS.Mappers.AtletaMappers.ToAtletaBasicoDto(u));

            return atletaDto;
        }

     
    }
}
