using Abp.AutoMapper;
using MyPhoneBook.Core.PhoneBooks.Persons;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.PhoneNumbers.Dto
{
    [AutoMap(typeof(Person))]
    public class PhoneNumbersEditDto
    {
        public int PersonId { get; set; }

        [Required]
        [MaxLength(MyPhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
    }
}
