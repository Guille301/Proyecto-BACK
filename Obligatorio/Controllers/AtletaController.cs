using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador;
using Libreria.LogicaNegocio.Entidades;
using Compartido.DTOS.Atleta;
using Libreria.LogicaAplicacion.ImplementacionesCU.Atletas;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Compartido.DTOS.Disciplina;
using Microsoft.EntityFrameworkCore;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;

namespace Obligatorio.Controllers
{
    public class AtletaController : Controller
    {



        private IObtenerAtletas _obtenerAtletas;
        private IObtenerDisciplina _obtenerDisciplina;
        private IBuscarAtletas _buscarAtleta;
        private IBuscarDisciplina _buscarDisciplina;
        private IAsignarDisciplina _asignarDisciplina;


        public AtletaController( IObtenerAtletas obtenerAtletas, IObtenerDisciplina obtenerDisciplina, IBuscarAtletas buscarAtleta, IBuscarDisciplina buscarDisciplina,
                                 IAsignarDisciplina asignarDisciplina)
        {
            

            _obtenerAtletas = obtenerAtletas;
            _obtenerDisciplina = obtenerDisciplina;
            _buscarAtleta = buscarAtleta;
            _buscarDisciplina = buscarDisciplina;
            _asignarDisciplina = asignarDisciplina;

        }

        /***********************************************************************************************/
        /***************************************** DIGITADOR *****************************************/
        /***********************************************************************************************/



        public ActionResult ListarAtletas()
        {
            if (HttpContext.Session.GetString("rol") == "Digitador")
            {
                if (TempData.ContainsKey("Mensaje"))
                {
                    ViewBag.Mensaje = TempData["Mensaje"];
                }
                var atletaDto = _obtenerAtletas.EjecutarOrdenado();
                return View(atletaDto);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        /*Asignar disciplina*/
        [HttpGet]
        public IActionResult AsignarDisciplina(int idAtleta)
        {
            if (HttpContext.Session.GetString("rol") == "Digitador")
            {

                ViewBag.IdAtleta = idAtleta;
                var DisciplinaDto = _obtenerDisciplina.Ejecutar();

                ViewBag.DisciplinasSelect = DisciplinaDto;

                return View(DisciplinaDto);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

     

        [HttpPost]
        public IActionResult AsignarDisciplina(int idAtleta, int idV)
        {
            try
            {
                _asignarDisciplina.Ejecutar(idAtleta, idV);

                ViewBag.msg = "Alta realizada";
                return RedirectToAction("ListarAtletas", "Atleta");
            }
            catch (DisciplinaYaAsignadaException ex)
            {
                ViewBag.msg = ex.Message; 
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error: " + ex.Message;
            }
            ViewBag.IdAtleta = idAtleta; 

            var DisciplinaDto = _obtenerDisciplina.Ejecutar();
            ViewBag.DisciplinasSelect = DisciplinaDto;

            return View(); 
        }










        // GET: AtletaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AtletaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AtletaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AtletaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
        }

        // GET: AtletaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtletaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
        }

        // GET: AtletaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AtletaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
        }
    }
}
