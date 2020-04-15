using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyPhoneBook.Core.PhoneBooks.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPhoneBook.Application.Dto
{
    
    public class PagedAndSortedInputDto : IPagedResultRequest, ISortedResultRequest
    {
        
        public string Sorting { get; set; }
        [Range(0,int.MaxValue)]
        public int SkipCount { get ; set; }
        [Range(1,500)]
        public int MaxResultCount { get; set; }
    }
}
