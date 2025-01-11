using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.Acceso.Datos.Repositorio.Listas;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Libreria.LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;

namespace Obligatorio.Controllers
{
    public class UsuarioController : Controller
    {

        private IAltaUsuario _altaUsuario;
        private IAutenticarUsuario _autenticarUsuario;
        private IBajaUsuario _bajaUsuario;
        private IBuscarUsuario _buscarUsuario;
        private IObtenerTodos _obtenerTodos;
        private IEditarUsuario _editarUsuario;

        private IObtenerAtletas _obtenerAtletas;

        //Constructor
        public UsuarioController(IAltaUsuario altaUsuario, IAutenticarUsuario autenticarUsuario, IBajaUsuario bajaUsuario,
            IBuscarUsuario buscarUsuario, IObtenerTodos obtenerTodos, IEditarUsuario editarUsuario, IObtenerAtletas obtenerAtletas)
        {
            _altaUsuario = altaUsuario;
            _autenticarUsuario = autenticarUsuario;
            _bajaUsuario = bajaUsuario;
            _buscarUsuario = buscarUsuario;
            _obtenerTodos = obtenerTodos;
            _editarUsuario = editarUsuario;

            _obtenerAtletas = obtenerAtletas;



        }
        //Con el autenticar usuario da error


        /*********************************************/
        /***************** LOGIN ********************/
        /********************************************/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string contraseña)
        {
            
            try
            {
                UsuarioBasicoDto usuario = _autenticarUsuario.Ejecutar(email, contraseña);
                //Mandamos los datos, rol y el email
                HttpContext.Session.SetString("rol", usuario.Rol);
                HttpContext.Session.SetInt32("id", usuario.Id);

                return RedirectToAction("Index", "Home");
            }
            catch (UsuarioException ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Advertencia = "Datos Incorrectos! intente denuevo";
                return View();
            }
        }
        //---------------


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }






        /***********************************************************************************************/
        /*****************************************ADMINISTRADOR*****************************************/
        /***********************************************************************************************/


        /*********************************************/
        /************** LISTAR USUARIO ****************/
        /********************************************/

        // GET: UsuarioController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") == "Administrador")
            {
                if (TempData.ContainsKey("Mensaje"))
                {
                    ViewBag.Mensaje = TempData["Mensaje"];
                }
                var usuariosDto = _obtenerTodos.Ejecutar();
                return View(usuariosDto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }





            //   return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }






        /**********************************************/
        /************* ALTA USUARIO ******************/
        /********************************************/

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("rol") == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAltaDto usuarioDTO)
        {

            try
            {
                usuarioDTO.AdmAlta = HttpContext.Session.GetInt32("id") ?? 0;
                usuarioDTO.FechaAlta = DateTime.Now;
                _altaUsuario.Ejecutar(usuarioDTO);
                TempData["Mensaje"] = "Usuario creado correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Usuario Existente";
                return View();
            }






        }





        /*****************************************/
        /**************EDITAR USUARIO************/
        /***************************************/


        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int? id)
        {
        
            if (HttpContext.Session.GetString("rol") == "Administrador")
            {
                try
                {
                    int idUsuario = id.Value;

                    UsuarioBasicoDto usuarioDto = _buscarUsuario.Ejecutar(idUsuario);

                    var usuarioAltaDto = new UsuarioAltaDto
                    {
                        Email = usuarioDto.Email,
                        Rol = usuarioDto.Rol,

                    };
                    return View(usuarioAltaDto);
                }
                catch (UsuarioNoEncontradoException ex)
                {
                    ViewBag.Advertencia = ex.Message;
                    return View();
                }
                catch (UsuarioException ex)
                {
                    ViewBag.Advertencia = ex.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Advertencia = ex.Message;
                    return View();
                }


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }








        }
        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioAltaDto usuarioDto)
        {
            try
            {
                usuarioDto.Id = id;
                _editarUsuario.Ejecutar(usuarioDto);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View(usuarioDto);
            }
            catch (Exception ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View(usuarioDto);
            }

        }








        /*********************************************/
        /************** BAJA USUARIO ****************/
        /*******************************************/

        // GET: UsuarioController/Delete/5

        public ActionResult Delete(int? id)
        {

            if (HttpContext.Session.GetString("rol") == "Administrador")
            {
                if (id == null)
                {
                    ViewBag.Advertencia = "Incluya el id a buscar.";
                    return View();
                }
                try
                {
                    int idUsuario = id.Value;

                    UsuarioBasicoDto usuarioDto = _buscarUsuario.Ejecutar(idUsuario);
                    if (usuarioDto == null)
                    {
                        ViewBag.Advertencia = "Usuario no encontrado";
                        return View();
                    }

                    return View(usuarioDto);
                }

                catch (UsuarioNoEncontradoException ex)
                {
                    ViewBag.Advertencia = ex.Message;
                    return View();
                }
                catch (UsuarioException ex)
                {
                    ViewBag.Advertencia = ex.Message;
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioBasicoDto usuarioDto)
        {
            try
            {
                _bajaUsuario.Ejecutar(id);
                return RedirectToAction(nameof(Index));
            }

            catch (UsuarioNoEncontradoException ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
            catch (UsuarioException ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado";
                return View();
            }

        }



        
    }

}
