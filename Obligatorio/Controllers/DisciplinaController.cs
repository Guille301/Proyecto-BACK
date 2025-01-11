using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Compartido.DTOS.Disciplina;
using Libreria.LogicaAplicacion.ImplementacionesCU.Atletas;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Disciplinas;

namespace Obligatorio.Controllers
{
    public class DisciplinaController : Controller
    {



        private IAltaDisciplina _altaDisciplina;
        private IObtenerDisciplina _obtenerDisciplina;
        private IBuscarDisciplina _buscarDisciplina;

        //Constructor
        public DisciplinaController(IAltaDisciplina altaDisciplina, IObtenerDisciplina obtenerDisciplina, IBuscarDisciplina buscarDisciplina)
        {
            _altaDisciplina = altaDisciplina;
            _obtenerDisciplina = obtenerDisciplina;
            _buscarDisciplina = buscarDisciplina;



        }




        // GET: DisciplinaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DisciplinaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ListarDisciplinas()
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == "Digitador")
                {
                    if (TempData.ContainsKey("Mensaje"))
                    {
                        ViewBag.Mensaje = TempData["Mensaje"];
                    }
                    var DisciplinaDto = _obtenerDisciplina.Ejecutar();
                    
                    return View(DisciplinaDto);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (NoHayDisciplinas ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }


        }




        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("rol") == "Digitador")
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
        public ActionResult Create(DisciplinaAltaDto DisciplinaDTO)
        {

            try
            {
                //Poner indidce unique para validar no se repite 
                _altaDisciplina.Ejecutar(DisciplinaDTO);
                
                TempData["Mensaje"] = "Disciplina creada correctamente";
                return RedirectToAction("Index", "Home");

            }

            
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }






        }

        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
