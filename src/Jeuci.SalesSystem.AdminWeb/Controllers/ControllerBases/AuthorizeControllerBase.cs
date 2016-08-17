using Abp.Web.Mvc.Authorization;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Events.EventData;

namespace Jeuci.SalesSystem.AdminWeb.Controllers.ControllerBases
{
    [AbpMvcAuthorize]
    public class AuthorizeControllerBase : SalesSystemControllerBase
    {

        protected AdministratorInfo CurrentUserInfo
        {
            get
            {
                if (Session[SalesSystemConsts.CurrentUserSessionName] == null)
                {
                    var currentUserEventData = new CurrentUserEventData((int)AbpSession.UserId);
                    EventBus.Trigger(currentUserEventData);
                    Session[SalesSystemConsts.CurrentUserSessionName] = currentUserEventData.CurrentUser;
                }
                return (AdministratorInfo) Session[SalesSystemConsts.CurrentUserSessionName];
            }
        }
    }
}