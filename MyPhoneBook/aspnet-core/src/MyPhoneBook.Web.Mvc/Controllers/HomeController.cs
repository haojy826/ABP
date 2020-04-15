using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyPhoneBook.Controllers;

namespace MyPhoneBook.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyPhoneBookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
