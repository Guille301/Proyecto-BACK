using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        // GET: api/<AtletaController>

        private readonly IObtenerAtletaPorId _obtenerAtletaPorId;


        public AtletaController(IObtenerAtletaPorId obtenerAtletaPorId)
        {
            _obtenerAtletaPorId = obtenerAtletaPorId;
        }



        [Authorize]
        [HttpGet("Disciplina/{idD}")]
        public IActionResult GetAtletasPorId(int idD)
        {
            try
            {
                var atletas = _obtenerAtletaPorId.Ejecutar(idD);
                return Ok(atletas);
            }
            catch (NoHayDisciplinas ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }









    }
}
