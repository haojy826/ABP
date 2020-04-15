using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MyPhoneBook.Web.Views
{
    public abstract class MyPhoneBookRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyPhoneBookRazorPage()
        {
            LocalizationSourceName = MyPhoneBookConsts.LocalizationSourceName;
        }
    }
}
