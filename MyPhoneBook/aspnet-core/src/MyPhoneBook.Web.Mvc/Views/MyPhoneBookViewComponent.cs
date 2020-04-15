using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyPhoneBook.Web.Views
{
    public abstract class MyPhoneBookViewComponent : AbpViewComponent
    {
        protected MyPhoneBookViewComponent()
        {
            LocalizationSourceName = MyPhoneBookConsts.LocalizationSourceName;
        }
    }
}
