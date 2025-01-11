using Microsoft.AspNetCore.Mvc;
using Compartido.DTOS.Disciplina;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Compartido.DTOS.Auditoria;
using System.Security.Claims;
using Libreria.LogicaAplicacion.InterfacesCU.AuditoriaInterface;
using Microsoft.AspNetCore.Authorization;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IEliminarDisciplina _eliminarDisciplina;
        private readonly IAltaDisciplina _altaDisciplina;
        private readonly IObtenerDisciplina _obtenerDisciplina;
        private readonly IBuscarDisciplina _buscarDisciplina;
        private readonly IEditarDisciplina _EditDisciplina;
        private readonly IRegistrarAuditoria _registrarAuditoria;


        // Constructor
        public DisciplinaController(
            IEliminarDisciplina eliminarDisciplina,
            IAltaDisciplina altaDisciplina,
            IObtenerDisciplina obtenerDisciplina,
            IBuscarDisciplina buscarDisciplina,
            IEditarDisciplina editDisciplina,
            IRegistrarAuditoria registrarAuditoria)
        {
            _eliminarDisciplina = eliminarDisciplina;
            _altaDisciplina = altaDisciplina;
            _obtenerDisciplina = obtenerDisciplina;
            _buscarDisciplina = buscarDisciplina;
            _EditDisciplina = editDisciplina;
            _registrarAuditoria = registrarAuditoria;
        }

        /// <summary>
        /// Obtener todas las disciplinas.
        /// </summary>
        [Authorize(Roles = "Digitador")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var disciplinas = _obtenerDisciplina.Ejecutar();
                return Ok(disciplinas); // Devuelve las disciplinas con código 200
            }
            catch (NoHayDisciplinas ex)
            {
                return NotFound(new { mensaje = ex.Message }); // Código 404 si no hay disciplinas
            }
        }

        /// <summary>
        /// Obtener una disciplina específica por ID.
        /// </summary>
        [Authorize(Roles = "Digitador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var disciplina = _buscarDisciplina.Ejecutar(id);
                if (disciplina == null)
                    return NotFound(new { mensaje = "Disciplina no encontrada" });

                return Ok(disciplina);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Obtener una disciplina específica por Nombre.
        /// </summary>
        [Authorize(Roles = "Digitador")]
        [HttpGet("Nombre/{Name}")]
        public IActionResult GetByName(string Name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    return BadRequest(new { mensaje = "El nombre de la disciplina no puede estar vacío o nulo." });
                }

                var disciplinaDto = _buscarDisciplina.EjecutarPorNombre(Name);

                if (disciplinaDto == null)
                {
                    return NotFound(new { mensaje = $"No se encontró ninguna disciplina con el nombre '{Name}'." });
                }

                return Ok(disciplinaDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado al buscar la disciplina.", detalle = ex.Message });
            }
        }


        /// <summary>
        /// Crear una nueva disciplina.
        /// </summary>
        [Authorize(Roles = "Digitador")]
        [HttpPost]
        public IActionResult Create([FromBody] DisciplinaAltaDto disciplinaDto)
        {
            try
            {
                _altaDisciplina.Ejecutar(disciplinaDto);

                string email = HttpContext.Session.GetString("Email");

                // Registrar auditoría para creación (sin EntidadId)
                var auditoria = new AuditoriaDto
                {
                    Fecha = DateTime.Now,
                    Operacion = "Creado",
                    Entidad = "Disciplina",
                    UsuarioEmail = email
                };
                _registrarAuditoria.Ejecutar(auditoria);

                return CreatedAtAction(nameof(GetById), new { id = disciplinaDto.Id }, disciplinaDto);
            }
            catch (ErrorDeDatosDisciplina ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado: " + ex.Message });
            }
        }


        /// <summary>
        /// Actualizar una disciplina existente.
        /// </summary>
        [Authorize(Roles = "Digitador")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EditarDisciplinaDTO disciplinaDto)
        {
            try
            {
                var disciplinaExistente = _buscarDisciplina.Ejecutar(id);
                if (disciplinaExistente == null)
                    return NotFound(new { mensaje = "Disciplina no encontrada" });


                _EditDisciplina.Ejecutar(disciplinaDto);

                string email = HttpContext.Session.GetString("Email"); ;

                // Registrar auditoría para actualización (con EntidadId)
                var auditoria = new AuditoriaDto
                {
                    Fecha = DateTime.Now,
                    Operacion = "Editado",
                    Entidad = "Disciplina",
                    EntidadId = id, // Solo se agrega el ID cuando es una actualización
                    UsuarioEmail = email // Obtener el email del usuario desde el token JWT
                };
                _registrarAuditoria.Ejecutar(auditoria);

                return NoContent(); // Código 204: Actualización exitosa sin contenido
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Eliminar una disciplina por ID.
        /// </summary>
        [Authorize(Roles = "Digitador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _eliminarDisciplina.Ejecutar(id);

                string email = HttpContext.Session.GetString("Email");

                // Registrar auditoría para eliminación (sin EntidadId)
                var auditoria = new AuditoriaDto
                {
                    Fecha = DateTime.Now,
                    Operacion = "Eliminado",
                    Entidad = "Disciplina",
                    UsuarioEmail = email // Obtener el email del usuario desde el token JWT
                };
                _registrarAuditoria.Ejecutar(auditoria); // Usar Ejecutar para registrar la auditoría


                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = $"No se pudo eliminar la disciplina. Detalle: {ex.Message}" });
            }
        }

    }
}
