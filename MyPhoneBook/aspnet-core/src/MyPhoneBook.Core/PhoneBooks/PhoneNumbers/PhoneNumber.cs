using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyPhoneBook.Core.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Core.PhoneBooks.PhoneNumbers
{
    public class PhoneNumber:Entity<long>,IHasCreationTime
    {
        [Required]
        [MaxLength(MyPhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
        public DateTime CreationTime { get; set; }

        public int PersonId { get; set; }
        public Person Persons { get; set; }
    }
}
