﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Domain.Sales.Models
{
    public class SalesRecordModel
    {
        public string Id { get; set; }

        public string ServiceName { get; set; }

        public string UserName { get; set; }

        public string UserPhone { get; set; }

        public decimal Cost { get; set; }

        public decimal Profit { get; set; }

        public DateTime SalesDateTime { get; set; }

        public DateTime? AuthExpiration { get; set; }

        public string AgentUserName { get; set; }

        public string AdminUserName { get; set; }

        public string Remarks { get; set; }
    }
}
