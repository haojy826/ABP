using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Application.PhoneBooks;
using MyPhoneBook.Application.PhoneBooks.Dtos;
using MyPhoneBook.Controllers;


namespace MyPhoneBook.Web.Controllers
{
    public class PersonsController : MyPhoneBookControllerBase
    {
        private readonly IPersonAppService _personAppService;//依赖注入
        public PersonsController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        //使用了分页，所以形参是分页的输入
        public async Task<IActionResult> Index(GetPersonInput input)
        {
            var dtos = await _personAppService.GetPagedPersonAsync(input);
            return View(dtos);
        }
    }
}