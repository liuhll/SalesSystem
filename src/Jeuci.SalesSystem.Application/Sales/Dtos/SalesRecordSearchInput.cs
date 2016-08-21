using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Jeuci.SalesSystem.Sales.Dtos
{
    public class SalesRecordSearchInput : IInputDto
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Brand { get; set; }

        public int ServiceInfo { get; set; }

        public string OrderId { get; set; }

        public string UserPassport { get; set; }

        public string Agent { get; set; }

        public string SalesInfo { get; set; }

        public string Reservation { get; set; }



    }
}
