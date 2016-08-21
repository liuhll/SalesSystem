using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Jeuci.SalesSystem.Domain.Sales.Models;

namespace Jeuci.SalesSystem.Sales.Dtos
{
    [AutoMap(typeof(SalesRecordModel))]
    public class SalesRecordOutput : EntityRequestInput<string>, IOutputDto
    {
    //    public string Id { get; set; }

        public string ServiceName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserPhone { get; set; }

        public decimal Cost { get; set; }

        public decimal Profit { get; set; }

        public DateTime SalesDateTime { get; set; }

        public DateTime AuthExpiration { get; set; }

        public string AgentUserName { get; set; }

        public string AdminUserName { get; set; }

        public string Remarks { get; set; }

        public string UserPassport
        {
            get {
                return string.Format("{0} | {1} | {2}",this.UserId,
                string.IsNullOrEmpty(this.UserName)?"-": this.UserName,
                string.IsNullOrEmpty(this.UserPhone)?"-":this.UserPhone);
            }
        }

    }
}
