using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyPhoneBook.Controllers
{
    public abstract class MyPhoneBookControllerBase: AbpController
    {
        protected MyPhoneBookControllerBase()
        {
            LocalizationSourceName = MyPhoneBookConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
