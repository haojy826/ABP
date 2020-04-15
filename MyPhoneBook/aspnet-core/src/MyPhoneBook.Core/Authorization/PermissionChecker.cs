using Abp.Authorization;
using MyPhoneBook.Authorization.Roles;
using MyPhoneBook.Authorization.Users;

namespace MyPhoneBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
