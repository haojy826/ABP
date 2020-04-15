using Microsoft.AspNetCore.Antiforgery;
using MyPhoneBook.Controllers;

namespace MyPhoneBook.Web.Host.Controllers
{
    public class AntiForgeryController : MyPhoneBookControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
