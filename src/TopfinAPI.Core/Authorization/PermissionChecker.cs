using Abp.Authorization;
using TopfinAPI.Authorization.Roles;
using TopfinAPI.Authorization.Users;

namespace TopfinAPI.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
