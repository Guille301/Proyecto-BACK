using Compartido.DTOS.Evento;
using Libreria.LogicaAplicacion.ImplementacionesCU.Atletas;
using Libreria.LogicaAplicacion.ImplementacionesCU.Evento;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("eventoapi")]

    public class APIeventoController : ControllerBase
    {
        private IObtenerEventos _obtenerEvento;
        private IBuscarAtletas _buscarAtleta;

        public APIeventoController(IObtenerEventos obtenerEvento, IBuscarAtletas buscarAtleta)
        {
            _obtenerEvento = obtenerEvento;
            _buscarAtleta = buscarAtleta;
        }

        [HttpGet]
        [Route("listar")]
        //API / RF5
        public ActionResult<List<EventoDto>> ListarEventosPorAtleta(int id)
        {
            try
            {
                var eventos = _obtenerEvento.EjecutarListarEventosPorAtleta(id);

                // Si no hay eventos, puedes devolver NotFound o simplemente una lista vacía
                if (!eventos.Any())
                {
                    return NotFound("No se encontraron eventos para el atleta.");
                }
                // Mapear eventos a DTO
                var eventoDtos = eventos.Select(e => new EventoDto
                {
                    
                    Id = e.Id,
                    NombreDePrueba = e.NombreDePrueba,
                    disciplina = e.Disciplina,
                    atleta = e.AtletasParticipantes.Select(ap => _buscarAtleta.Ejecutar(ap.AtletaId))
                                                   .Where(a => a != null).ToList(),
                    FechaDeInicio = e.FechaDeInicio,
                    FechaDeFin = e.FechaDeFin
                }).ToList();

                return Ok(eventoDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error del servidor: {ex.Message}");
            }

        
        }
    }
}
