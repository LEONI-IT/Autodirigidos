using Autodirigidos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autodirigidos.Controllers
{
    public class AccesoController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Acceso");
        }



        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            login InstanciaLogin = new login();
            Conexion InstanciaConexion = new Conexion();

            try
            {

                string pass = "";
                pass = password.Replace("'", "").Replace("-", "").Replace("’", "");


                if (InstanciaLogin.Login(user, pass))
                {


                    DataTable dt = InstanciaConexion.Select("select * from usuarios where no_empleado='" + user + "' and pass='" + pass + "'").Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        //CREO EL OBJETO USUARIO CONSTRUIDO POR LAS CREDENCIALES DEL USUARIO ACEPTADO
                        var usuario = new CurrentUser
                        {
                            PASSWORD = pass,
                            SUBAREA = Convert.ToString(row["subarea"]),
                            AREA = Convert.ToString(row["area"]),
                            NOMBRE = Convert.ToString(row["nombre"]),
                            NO_EMPLEADO = Convert.ToInt32(user),
                            IID = Convert.ToInt32(row["id"])

                        };
                        HomeController.usuarioHome.PASSWORD = pass;
                        HomeController.usuarioHome.SUBAREA = Convert.ToString(row["subarea"]);
                        HomeController.usuarioHome.AREA = Convert.ToString(row["area"]);
                        HomeController.usuarioHome.NOMBRE = Convert.ToString(row["nombre"]);
                        HomeController.usuarioHome.NO_EMPLEADO = Convert.ToInt32(user);
                        HomeController.usuarioHome.IID = Convert.ToInt32(row["id"]);


                        Session["user"] = usuario;
                        //REDIRECCIONO AL INDEX SI LAS CREDENCIALES ESTAN CORRECTAS
                    }
                    ViewBag.Credenciales = false;
                    if (HomeController.usuarioHome.SUBAREA == "Produccion")
                    {
                        return RedirectToAction("General", "Production");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Credenciales = "Credenciales malas";

                    return View();

                }
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View();
            }
        }


    }
}