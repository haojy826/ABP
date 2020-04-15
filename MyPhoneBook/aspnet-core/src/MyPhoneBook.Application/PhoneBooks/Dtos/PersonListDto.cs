using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MyPhoneBook.Core.PhoneBooks.Persons;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.Dtos
{
     [AutoMapFrom(typeof(Person))]
    public class PersonListDto:FullAuditedEntityDto
    {
        
        public string Name { get; set; }

        
        public string EmailAddress { get; set; }

        
        public string Address { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
