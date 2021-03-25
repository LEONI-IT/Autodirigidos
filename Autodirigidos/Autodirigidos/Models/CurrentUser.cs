using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autodirigidos.Models
{
    public class CurrentUser
    {
        public string PASSWORD { get; set; }
        public string SUBAREA { get; set; }
        public string AREA { get; set; }
        public string NOMBRE { get; set; }
        public int NO_EMPLEADO { get; set; }
        public int IID { get; set; }
    }
}