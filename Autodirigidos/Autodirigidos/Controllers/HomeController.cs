using Autodirigidos.Filters;
using Autodirigidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autodirigidos.Controllers
{
    public class HomeController : Controller
    {
        public static CurrentUser usuarioHome = new CurrentUser
        {
            PASSWORD = "",
            SUBAREA = "",
            AREA = "",
            NOMBRE = "",
            NO_EMPLEADO = 0,
            IID = 0

        };
        [AuthorizeUser]
        public ActionResult Index()
        {
            // VerificarAcceso();
            return View();
        }

        //[AuthorizeUser(idOperation: 2)]
        [AuthorizeUser]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //[AuthorizeUser(idOperation: 3)]
        [AuthorizeUser]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public void VerificarAcceso()
        {
            if (usuarioHome.SUBAREA == "Produccion")
            {
                RedirectToAction("LogOff", "Acceso");
            }

        }
    }
}