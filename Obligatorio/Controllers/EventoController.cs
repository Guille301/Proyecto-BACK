using Compartido.DTOS.Evento;
using Compartido.DTOS.PuntajeAtleta;
using Compartido.DTOS.Usuario;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Libreria.LogicaAplicacion.ImplementacionesCU.Evento;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Eventos;
using Libreria.LogicaNegocio.ExcepcionesPersonalizadas.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    public class EventoController : Controller
    {



        private IAltaEvento _altaEvento;
        private IObtenerEventos _obtenerEventos;
        private IAtletasDeLosEventos _atletaDeLosEventos;
        private IBuscarAtletaEnEvento _buscarAtletaEnEvento;
        private IRegistrarPuntaje _registrarPuntaje;

        //Constructor
        public EventoController(IAltaEvento altaEvento, IObtenerEventos obtenerEventos, IAtletasDeLosEventos atletaEvento, 
                                IBuscarAtletaEnEvento buscarAtletaEnEvento, IRegistrarPuntaje regPuntaje )
        {
            _obtenerEventos = obtenerEventos;
            _altaEvento = altaEvento;
            _atletaDeLosEventos = atletaEvento;
            _buscarAtletaEnEvento = buscarAtletaEnEvento;
            _registrarPuntaje = regPuntaje;
        }





        // GET: EventoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public IActionResult FiltrarPorFecha()
        {

            if (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Digitador")
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public IActionResult FiltrarPorFecha(DateTime FechaDeInicio)
        {
            return RedirectToAction("ListarEventos", "Evento", new { laFecha = FechaDeInicio });
        }




        
        public ActionResult ListarEventos(DateTime laFecha)
        {
            if (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Digitador")
            {
                if (TempData.ContainsKey("Mensaje"))
            {
                ViewBag.Mensaje = TempData["Mensaje"];
            }
            var ListarEvento = _obtenerEventos.EjecutarListarEventos(laFecha);

            return View(ListarEvento);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        
        }


    public ActionResult ListarAtletasDelEvento(int idEvento)
        {

            if (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Digitador")
            {
                try
                {
                var atletas = _atletaDeLosEventos.EjecutarListarAtletasDeLosEventos(idEvento);

                // Pasar idEvento a la vista usando ViewBag
                ViewBag.IdEvento = idEvento;

                    return View(atletas);
                }
                    catch (Exception ex)
                {
                    return View("Error", ex);
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }



        public ActionResult Puntaje(int idAtleta, int idEvento)
        {
            if (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Digitador")
            {
                try
                {
                    // Buscar el atleta participante usando idAtleta e idEvento
                    ListarAtletasDeLosEventosDto atletaParticipante = _buscarAtletaEnEvento.Ejecutar(idAtleta, idEvento);

                    // Verificar si el objeto es nulo
                    if (atletaParticipante == null)
                    {
                        throw new Exception("Atleta no encontrado.");
                    }

                    // Devolver el atleta encontrado a la vista para mostrar y modificar el puntaje
                    return View(atletaParticipante);
                }
                catch (Exception ex)
                {
                    ViewBag.Advertencia = ex.Message;
                    return View("Error");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Puntaje(ListarAtletasDeLosEventosDto atletaEvento)
        {

            try
            {

                _registrarPuntaje.Ejecutar(atletaEvento);
                return RedirectToAction("Index", "Home");
            }
            catch (PuntosInvalidos ex)
            {
                ViewBag.Advertencia = ex.Message;
                return Puntaje(atletaEvento.idAtleta,atletaEvento.idEvento);
            }   
            catch (Exception ex)
            {
                ViewBag.Advertencia = ex.Message;
                return Puntaje(atletaEvento.idAtleta, atletaEvento.idEvento);
            }

            
          
            


        }








        // GET: PublicacionController/Create
        [HttpGet("Evento/CreateEvento")]
        public ActionResult CreateEvento()
        {

            if (HttpContext.Session.GetString("rol") == "Administrador" || HttpContext.Session.GetString("rol") == "Digitador")
            {

                return View(_altaEvento.HacerAltaEvento());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

   
           
        // POST: PublicacionController/Create
        [HttpPost("Evento/CreateEvento")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvento(EventoAltaDto EventoAltaDto)
        {
            try
            {

                
                _altaEvento.Ejecutar(EventoAltaDto);
                return RedirectToAction("Index", "Home");

            }

            catch (DatosVaciosEvento ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
            catch (FaltanAtletas ex)
            {
                ViewBag.Advertencia = ex.Message;
                return View();
            }
            catch (FechaInvalida ex)
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









        // POST: EventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EventoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventoController/Edit/5
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

        // GET: EventoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventoController/Delete/5
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
