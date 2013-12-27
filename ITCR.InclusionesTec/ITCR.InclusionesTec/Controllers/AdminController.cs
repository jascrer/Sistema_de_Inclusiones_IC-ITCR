using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITCR.InclusionesTec.Controllers
{
    /// <summary>
    /// Propósito: Enrutar las páginas de administración
    /// </summary>
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reglas()
        {
            return View();
        }

        public ActionResult Periodo()
        {
            return View();
        }

        public ActionResult Cupos()
        {
            return View();
        }

        public ActionResult Asignacion()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            return View();
        }

        public ActionResult Notificaciones()
        {
            return View();
        }

        public ActionResult Consultas()
        {
            return View();
        }

    }
}
