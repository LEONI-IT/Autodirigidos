using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autodirigidos.Models
{
    public class login
    {

        Conexion InstanciaConexion = new Conexion();
        public Boolean Login(string user, string password)

        {
            return InstanciaConexion.Existe("select * from Usuarios where no_empleado='" + user + "' and pass ='" + password + "'");
        }
    }

}