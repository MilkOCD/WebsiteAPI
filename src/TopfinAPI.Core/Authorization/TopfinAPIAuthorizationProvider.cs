using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TopfinAPI.Authorization
{
    public class TopfinAPIAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Articles, L("Pages.Articles"));
            context.CreatePermission(PermissionNames.Pages_Books, L("Pages.Books"));
            context.CreatePermission(PermissionNames.Pages_Knowledges, L("Pages.Knowledges"));
            context.CreatePermission(PermissionNames.Pages_AnalysisCenters, L("Pages.AnalysisCenters"));
            context.CreatePermission(PermissionNames.Pages_Customers, L("Pages.Customers"));
            //context.CreatePermission(PermissionNames.Pages_Articles, L("Pages.Articles"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TopfinAPIConsts.LocalizationSourceName);
        }
    }
}
