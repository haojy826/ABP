using Abp.AutoMapper;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.PhoneNumbers.Dto
{
    [AutoMap(typeof(PhoneNumber))]
    public class PhoneNumberEditDto
    {
        [Required]
        [MaxLength(MyPhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
    }
}
