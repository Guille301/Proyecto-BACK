using Compartido.DTOS.Atleta;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Atletas
{
    public class ObtenerAtletas : IObtenerAtletas
    {

        private LogicaNegocio.InterfacesRepositorios.IRepositorioAtleta _repoAtleta;


        public ObtenerAtletas(LogicaNegocio.InterfacesRepositorios.IRepositorioAtleta repoAtleta)
        {
            this._repoAtleta = repoAtleta;
        }
        public IEnumerable<AtletaDatosCompletosDto> Ejecutar()
        {
            var atletas = _repoAtleta.FindAll();
            
            var atletaDto = atletas.Select(u => Compartido.DTOS.Mappers.AtletaMappers.ToAtletaBasicoDto(u));

            return atletaDto;
        }
        public IEnumerable<AtletaDatosCompletosDto> EjecutarOrdenado()
        {
            var atletas = _repoAtleta.FindAllOrdenado();

            var atletaDto = atletas.Select(u => Compartido.DTOS.Mappers.AtletaMappers.ToAtletaBasicoDto(u));

            return atletaDto;
        }







    }
}
