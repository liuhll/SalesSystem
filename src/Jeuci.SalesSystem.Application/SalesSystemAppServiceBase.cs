using Abp.Application.Services;

namespace Jeuci.SalesSystem
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SalesSystemAppServiceBase : ApplicationService
    {
        protected SalesSystemAppServiceBase()
        {
            LocalizationSourceName = SalesSystemConsts.LocalizationSourceName;
        }
    }
}