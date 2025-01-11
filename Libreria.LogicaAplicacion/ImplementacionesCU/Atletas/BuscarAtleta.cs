using Compartido.DTOS.Atleta;
using Compartido.DTOS.Mappers;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Atletas
{
    public class BuscarAtleta : IBuscarAtletas
    {



        private IRepositorioAtleta _repositorioAtleta;

        public BuscarAtleta(IRepositorioAtleta repositorioAtleta)
        {
            _repositorioAtleta = repositorioAtleta;
        }


        public AtletaDatosCompletosDto Ejecutar(int id)
        {

            LogicaNegocio.Entidades.Atleta usu = _repositorioAtleta.FindById(id);

            AtletaDatosCompletosDto usuarioDto = AtletaMappers.ToAtletaBasicoDto(usu);

            return usuarioDto;


        }

      
    }
}
