using Autodirigidos.Controllers;
using Autodirigidos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autodirigidos.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        string subarea = "";



        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // base.OnAuthorization(filterContext);

            //  currentUser = (CurrentUser)HttpContext.Current.Session["user"];
            Conexion connection = new Conexion();

            DataTable dt = connection.Select("SELECT subarea FROM usuarios WHERE no_empleado='" + HomeController.usuarioHome.NO_EMPLEADO + "'").Tables[0];
            if (dt.Rows.Count == 0)
                return;

            foreach (DataRow row in dt.Rows)
            {
                subarea = row["subarea"].ToString();
                if (subarea == "Produccion")
                {
                    //                    filterContext.Result = new RedirectResult("~/Home/Index");
                    filterContext.Result = new RedirectResult("~/Error/UnAuthorizedOperation");
                    //                  break;
                }
            }






        }
    }
}