using Abp.AutoMapper;
using Abp.Runtime.Validation;
using MyPhoneBook.Application.Dto;
using MyPhoneBook.Core.PhoneBooks.Persons;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Application.PhoneBooks.Dtos
{
    
    public class GetPersonInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string FilterText{get;set;}

        public void Normalize()
        {
            if(string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
