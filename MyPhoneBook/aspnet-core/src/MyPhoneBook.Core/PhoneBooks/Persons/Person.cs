using Abp.Domain.Entities.Auditing;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Core.PhoneBooks.Persons
{    
    public class Person:FullAuditedEntity
    {
        [Required]
        [MaxLength(MyPhoneBookConsts.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MyPhoneBookConsts.MaxEmailLength)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [MaxLength(MyPhoneBookConsts.MaxAddressLength)]
        public string Address { get; set; }
        /// <summary>
        /// 电话号码的属性，Person与PhoneNumber进行关联
        /// </summary>
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
