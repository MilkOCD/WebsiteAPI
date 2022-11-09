using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TopfinAPI.Controllers
{
    public abstract class TopfinAPIControllerBase: AbpController
    {
        protected TopfinAPIControllerBase()
        {
            LocalizationSourceName = TopfinAPIConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
