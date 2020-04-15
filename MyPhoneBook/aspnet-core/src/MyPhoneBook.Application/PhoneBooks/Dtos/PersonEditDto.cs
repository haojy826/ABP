using Abp.AutoMapper;
using MyPhoneBook.Application.PhoneBooks.PhoneNumbers.Dto;
using MyPhoneBook.Core.PhoneBooks.Persons;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.Dtos
{
    [AutoMap(typeof(Person))]
    public class PersonEditDto
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

        public List<PhoneNumberEditDto> PhoneNumbers { get; set; }
    }
}
