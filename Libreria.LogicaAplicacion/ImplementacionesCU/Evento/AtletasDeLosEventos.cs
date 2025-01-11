using Compartido.DTOS.Atleta;
using Compartido.DTOS.PuntajeAtleta;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Evento
{
    public class AtletasDeLosEventos : IAtletasDeLosEventos
    {
        private readonly IRepositorioEvento _repoEvento;


        public AtletasDeLosEventos(IRepositorioEvento repoEvento)
        {
            
            _repoEvento = repoEvento;

        }


        public IEnumerable<ListarAtletasDeLosEventosDto> EjecutarListarAtletasDeLosEventos(int idEvento)
        {

            var atletas = _repoEvento.FindAtletasDelEvento(idEvento);

            var atletaDto = atletas.Select(u => Compartido.DTOS.Mappers.EventoMappers.FromDtoListarLosAtletasDeLosEventos(u));

            return atletaDto;




        }

        
    }
}
