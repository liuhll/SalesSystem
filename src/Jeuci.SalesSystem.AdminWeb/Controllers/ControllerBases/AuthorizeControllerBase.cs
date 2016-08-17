using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.Events.EventData;
using Jeuci.SalesSystem.Events.EventHandler;


namespace Jeuci.SalesSystem.AdminWeb.Controllers
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