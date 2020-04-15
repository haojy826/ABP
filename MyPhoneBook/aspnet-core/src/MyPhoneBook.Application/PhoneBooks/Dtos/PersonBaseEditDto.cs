using Abp.AutoMapper;
using MyPhoneBook.Core.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.Dtos
{
   
    [AutoMap(typeof(Person))]
    public class PersonBaseEditDto
    {

        public int? Id { get; set; }
        [Required]
        [MaxLength(MyPhoneBookConsts.MaxNameLength)]
        public string Name { get; set; }

        [EmailAddress]
        [MaxLength(MyPhoneBookConsts.MaxEmailLength)]
        public string EmailAddress { get; set; }

        [MaxLength(MyPhoneBookConsts.MaxAddressLength)]
        public string Address { get; set; }

    }
}
