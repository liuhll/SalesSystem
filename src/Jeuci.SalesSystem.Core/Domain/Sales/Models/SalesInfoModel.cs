using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Domain.Sales.Models
{
    public class SalesInfoModel
    {
        public int ServiceId { get; set; }

        public int ServicePriceId { get; set; }

        public string Passport { get; set; }

        public decimal Cost { get; set; }

        public string Remarks { get; set; }
    }
}
