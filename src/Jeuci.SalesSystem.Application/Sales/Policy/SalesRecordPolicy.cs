using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Domain.Sales.Models;
using Jeuci.SalesSystem.Sales.Dtos;

namespace Jeuci.SalesSystem.Sales.Policy
{
    internal class SalesRecordPolicy
    {
        private IList<SalesRecordModel> _salesServiceRecordList;

   
        public SalesRecordPolicy(IList<SalesRecordModel> salesServiceRecordList)
        {
            this._salesServiceRecordList = salesServiceRecordList;
        }

        public IList<SalesRecordModel> SearchSalesServiceRecord(SalesRecordSearchInput searchInput)
        {
            //单号查询 忽略掉其他条件
            if (!string.IsNullOrEmpty(searchInput.OrderId))
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(p =>p.Id.Trim().Equals(searchInput.OrderId.Trim())).ToList();

                return _salesServiceRecordList;
            }

            if (searchInput.Brand != -1)
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(p => p.BrandId == searchInput.Brand).ToList();
            }
            if (searchInput.ServiceInfo != -1)
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(p => p.ServerInfoId == searchInput.ServiceInfo).ToList();
            }
            if (!string.IsNullOrEmpty(searchInput.Agent))
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(p => p.AgentUserName.Contains(searchInput.Agent)).ToList();
            }
            if (!string.IsNullOrEmpty(searchInput.SalesAdmin))
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(p => p.AdminUserName.Contains(searchInput.SalesAdmin)).ToList();
            }
            if (!string.IsNullOrEmpty(searchInput.UserPassport))
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(
                    p =>
                    {
                        var isUserNameEqual = false;
                        var isUserPhoneEqual = false;
                        var isUserIdEqual = false;
                        if (p.UserName != null)
                        {
                            isUserNameEqual = p.UserName.Contains(searchInput.UserPassport);
                        }
                        if (p.UserPhone != null)
                        {
                            isUserPhoneEqual = p.UserPhone.Equals(searchInput.UserPassport);
                        }
                        isUserIdEqual = p.UserId.ToString().Equals(searchInput.UserPassport);

                        return
                            isUserNameEqual ||
                            isUserPhoneEqual ||
                            isUserIdEqual;
                    }).ToList();
            }

            if (!string.IsNullOrEmpty(searchInput.Reservation))
            {
                _salesServiceRecordList = _salesServiceRecordList.Where(
                    p => p.SalesDateTime >= searchInput.StartSalesDate && p.SalesDateTime <= searchInput.EndSalesDate).ToList();
            }

            return _salesServiceRecordList;
        }
    }
}
