using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Sales.Dtos
{
    public class SalesInput
    {
        public int SoftwareVersion { get; set; }

        public string UserName { get; set; }

        public decimal Cost { get; set; }

        public string Remarks { get; set; }
    }
}
