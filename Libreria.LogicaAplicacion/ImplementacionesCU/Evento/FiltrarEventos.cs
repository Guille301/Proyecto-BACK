using Compartido.DTOS.Evento;
using Compartido.DTOS.Mappers;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ImplementacionesCU.Evento
{
    public class FiltrarEventos : IFiltrarEventos
    {

        private IRepositorioEvento _repoEvento;


        public FiltrarEventos(IRepositorioEvento repoEvento)
        {

            _repoEvento = repoEvento;


        }




        

        public IEnumerable<FiltrarEventoDTO> EjecutarListarEventos(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string? nombreEvento, int? puntajeMin, int? puntajeMax)
        {
           
            try
            {
                List<Libreria.LogicaNegocio.Entidades.Evento> listaEventos = _repoEvento.FiltroEvento(disciplinaId, fechaInicio, fechaFin, nombreEvento, puntajeMin, puntajeMax);

                List<FiltrarEventoDTO> DtolistaEventos = EventoMappers.FromDtoFiltrarEventos(listaEventos);

                if (listaEventos.Count == 0)
                {
                    throw new NoHayEventos("No hay eventos");
                }


                return DtolistaEventos;
            }
            catch (NoHayEventos ex)
            {
                throw new NoHayEventos(ex.Message);
            }
            catch(Exception ex)
            {
                throw  new Exception(ex.Message);

            }


        }




    }
}
