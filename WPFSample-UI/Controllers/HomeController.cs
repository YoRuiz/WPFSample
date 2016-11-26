using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WPFSample_UI.Models;

namespace WPFSample
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// método index que abre la vista index mostrando el listado de personas en la BBDD, en caso de error se muestra la vista de error
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            VMclsListado lista = new VMclsListado();
            try
            {
                
                return View(lista);
            }
            catch (Exception)
            {
                return View("paginaError");
            }
        }
        /// <summary>
        /// método create que solo manda la vista de vuelta
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();            
        }
        /// <summary>
        /// este método se llama cuando se pulsa el botón "crear" de la vista index, recoge los datos de los inputs de texto y llama a insertaPeronaBL,
        /// en caso de error se muestra la vista paginaError
        /// </summary>
        /// <param name="p"> una persona </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(clsPersona p)
        {

            int i;
            //mira si los campos [Required] son válidos
            if (!ModelState.IsValid)
            {
                return View(p);
            }else
            {
                try
                {
                    
                    //clsListadosBL miListado = new clsListadosBL();
                    clsManejadoraPersonaBL manejaBL = new clsManejadoraPersonaBL(); 
                    int filas = manejaBL.insertaPersonaBL(p);
                    VMclsListado lista = new VMclsListado();
                    return View("Index",lista);
                }
                catch (Exception)
                {
                    return View("paginaError");
                }
            }
        }
        /// <summary>
        /// este método muestra la vista de la persona seleccionada concordante con el id que recibe por parámetros,
        /// este id es el id de la ruta seleccionada, en caso de error recibiremos la vista paginaError
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {

            try
            {
                clsManejadoraPersonaBL maneja = new clsManejadoraPersonaBL();
                return View(maneja.getPersonaBL(id));
            }
            catch (Exception)
            {
                return View("paginaError");
            }
        }
        /// <summary>
        /// este método es llamado cuando se pulsa el boton delete en la vista con la persona seleccionada,
        /// llama el método borraPersonaBL, recibe una persona (en caso de que la persona no sea válida devuelve la vista de la persona, en caso de error de borrado manda la vista paginaError)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        //[HttpPost,ActionName("Delete")]
        public ActionResult Delete(clsPersona p)
        {
            int i;
            if (!ModelState.IsValid)
            {
                return View(p);
            }else
            {
                try
                {
                    clsManejadoraPersonaBL maneja = new clsManejadoraPersonaBL();
                    i = maneja.borraPersonaBL(p.id);
                    VMclsListado lista = new VMclsListado();
                    return View("Index",lista);
                }
                catch (Exception)
                {
                    return View("paginaError");
                    //  return View("paginaError");
                }
            }
        }
        /// <summary>
        /// método que devuelve una vista con los datos de la persona seleccionada en la ruta de web.config, en caso de error en el método getPersonaBL devuelve la vista paginaError
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {

            try
            {
                clsManejadoraPersonaBL maneja = new clsManejadoraPersonaBL();
                return View(maneja.getPersonaBL(id));
            }
            catch (Exception)
            {
                return View("paginaError");
            }
        }
        /// <summary>
        /// método que llama a getPersonaBL, devuelve la vista con la persona correspondiente al id de la ruta de web.config, en caso de error llama a la vista paginaError
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {
                clsManejadoraPersonaBL maneja = new clsManejadoraPersonaBL();
                return View(maneja.getPersonaBL(id));
            }
            catch (Exception)
            {
                return View("paginaError");
            }
        }
        /// <summary>
        /// este método es llamado cuando se pulsa el boton edit en la vista con la persona seleccionada,
        /// llama el método actualizaPersonaBL con los datos de la persona que se pasa por parámetros (esta persona recibe los datos mediante inputs de texto), en caso de que la persona no sea válida devuelve la vista de la persona, en caso de error de borrado manda la vista paginaError
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(clsPersona p)
        {

            int i;
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                try
                {
                    clsManejadoraPersonaBL maneja = new clsManejadoraPersonaBL();
                    i = maneja.actualizaPersonaBL(p);
                    VMclsListado lista = new VMclsListado();
                    return View("Index", lista);
                }
                catch (Exception)
                {
                    return View("paginaError");
                }
            }
        }
    }
}