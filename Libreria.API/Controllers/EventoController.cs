using Libreria.LogicaAplicacion.ImplementacionesCU.Atletas;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {


        private readonly IFiltrarEventos _filtrarEventos;

        public EventoController(IFiltrarEventos filtrar)
        {
            _filtrarEventos = filtrar;
        }

        [Authorize(Roles = "Digitador")]
        [HttpGet("Filtrar")]
        public IActionResult GetFiltroEventos(
        [FromQuery] int? disciplinaId,
        [FromQuery] DateTime? fechaInicio,
        [FromQuery] DateTime? fechaFin,
        [FromQuery] string? nombreEvento,
        [FromQuery] int? puntajeMin,
        [FromQuery] int? puntajeMax)
        {
            try
            {
                var eventos = _filtrarEventos.EjecutarListarEventos(disciplinaId, fechaInicio, fechaFin, nombreEvento, puntajeMin, puntajeMax);
                return Ok(eventos);
            }
            catch (NoHayEventos ex)
            {
                return NotFound(new { mensaje = ex.Message }); // Retorna 404 con un mensaje JSON
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message }); // Retorna 500 para errores inesperados
            }

        }






    }
}
