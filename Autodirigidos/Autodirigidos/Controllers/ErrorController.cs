using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autodirigidos.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnAuthorizedOperation()
        {
            //ViewBag.operacion=operacion;
            //ViewBag.modulo = modulo;
            //ViewBag.msjErrorException = msjErrorException;
            return View();
        }
    }
}