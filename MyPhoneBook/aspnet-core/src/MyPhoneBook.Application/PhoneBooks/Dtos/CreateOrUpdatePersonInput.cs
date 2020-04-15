using Abp.AutoMapper;
using MyPhoneBook.Core.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.Dtos
{
   
    public class CreateOrUpdatePersonInput
    {
        public PersonEditDto PersonEditDto { get; set; }
    }
}
