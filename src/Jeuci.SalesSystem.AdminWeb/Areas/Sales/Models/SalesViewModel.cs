using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jeuci.SalesSystem.AdminWeb.Areas.Sales.Models
{
    public class SalesViewModel
    {
        public int SoftwareVersion { get; set; }

        public string UserName { get; set; }

        public decimal Cost { get; set; }

        public string Remarks { get; set; }
    }
}