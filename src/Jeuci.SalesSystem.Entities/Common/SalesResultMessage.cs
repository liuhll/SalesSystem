using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Entities.Common
{
    public class SalesResultMessage
    {
        public SalesResultMessage(SalesResultType salesResultType, string message)
        {
            SalesResultType = salesResultType;
            Message = message;
        }

        public SalesResultMessage(SalesResultType salesResultType)
        {
            SalesResultType = salesResultType;
            Message = SetMessageByResultType(salesResultType);
        }

        private string SetMessageByResultType(SalesResultType salesResultType)
        {
            string resultMsg = string.Empty;

            switch (salesResultType)
            {
                case SalesResultType.NullUser:
                    resultMsg = "系统中不存在该用户，请检查输入的通行证[用户名/手机号]是否正确!";
                    break;
                case SalesResultType.InvalidUser:
                    resultMsg = "该用户账号被冻结，该用户无法购买服务产品";
                    break;
                case SalesResultType.ExistHighVersion:
                    resultMsg = "该用户已经购买了更高版本的软件服务,在服务失效截止前，无法购买低版本软件服务";
                    break;
                case SalesResultType.PurchaseCurrentServiceLifelong:
                    resultMsg = "该用户已经购买了当前软件版本的终身版，无法购买当前服务，建议升级更高版本";
                    break;
                case SalesResultType.Success:
                    resultMsg = "购买成功！";
                    break;
                default:
                    resultMsg = "系统异常，购买失败，请与我们联系";
                    break;
            }
            return resultMsg;
        }

        public SalesResultType SalesResultType { private set; get; }

        public string Message { private set; get; }
    }
}
