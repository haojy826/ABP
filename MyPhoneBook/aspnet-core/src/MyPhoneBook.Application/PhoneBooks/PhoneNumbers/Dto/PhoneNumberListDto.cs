using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.PhoneNumbers.Dto
{
    [AutoMapFrom(typeof(PhoneNumber))]
    public class PhoneNumberListDto
    {
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
    }
}
