using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITCR.InclusionesTec.Controllers
{
    /// <summary>
    /// Propósito: Enrutar las páginas públicas para estudiantes
    /// </summary>
    public class EstudianteController : Controller
    {
        //
        // GET: /Estudiante/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario()
        {
            //Uso datos login
            string s_carnetEstudiante = "200966799";
            
            return View();
        }

    }
}
