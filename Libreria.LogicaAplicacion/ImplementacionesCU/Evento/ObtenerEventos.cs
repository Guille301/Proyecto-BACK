using Compartido.DTOS.Evento;
using Compartido.DTOS.Mappers;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Evento
{
    public class ObtenerEventos : IObtenerEventos
    {

        private IRepositorioEvento _repoEvento;


        public ObtenerEventos(IRepositorioEvento repoEvento)
        {

            _repoEvento = repoEvento;

            
        }
        public IEnumerable<LogicaNegocio.Entidades.Evento> EjecutarListarEventosPorAtleta(int id)
        {


            var eventosFiltrados = _repoEvento.FindAllByAtletaId(id);

            return eventosFiltrados;

        }
        public IEnumerable<ListarEventos> EjecutarListarEventos(DateTime fecheDeEvento)
        {


            List<Libreria.LogicaNegocio.Entidades.Evento> listaEventos = _repoEvento.FindAllByDate(fecheDeEvento);

            List<ListarEventos> DtolistaEventos = EventoMappers.FromDtoListarEventos(listaEventos);

            return DtolistaEventos;
        }
    }
}
