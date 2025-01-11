using Microsoft.AspNetCore.Mvc;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAutenticarUsuario _autenticarUsuario;

        public AuthController(IAutenticarUsuario autenticarUsuario)
        {
            _autenticarUsuario = autenticarUsuario;
        }
        [HttpPost("login")]
        public IActionResult Login(AutenticarUsuarioDto login)
        {
            try
            {
                // Lógica de validación del usuario
                var usuarioValido = _autenticarUsuario.Ejecutar(login.Email, login.Contraseña);

                if (usuarioValido != null)
                {
                    var token = TokenUtility.GenerarToken(usuarioValido.Email, usuarioValido.Rol);

                    var resultado = new
                    {
                        Email = usuarioValido.Email,
                        Rol = usuarioValido.Rol,
                        Token = token
                    };
                    HttpContext.Session.SetString("Email", login.Email);
                    return Ok(resultado);
                }

                return Unauthorized("Credenciales incorrectas.");
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno.");
            }

        }
    }

}
