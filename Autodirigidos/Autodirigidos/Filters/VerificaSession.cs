using Autodirigidos.Controllers;
using Autodirigidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autodirigidos.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private CurrentUser currentUser;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            currentUser = (CurrentUser)HttpContext.Current.Session["user"];
            if (currentUser == null)
            {
                if (filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                }
            }
        }
    }
}
    
