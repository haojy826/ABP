using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyPhoneBook.Application.PhoneBooks.Dtos;
using MyPhoneBook.Application.PhoneBooks.PhoneNumbers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneBook.Application.PhoneBooks
{
    public interface IPersonAppService:IApplicationService
    {
        /// <summary>
        /// 获取联系人的相关信息,支持分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);
        /// <summary>
        /// 新增或者更改联系人信息
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);
        /// <summary>
        /// 根据ID获取相关联系人的信息
        /// </summary>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);
        /// <summary>
        /// 删除联系人信息
        /// </summary>
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);
        /// <summary>
        /// 通过Id获取联系人信息进行编辑或修改 
        /// </summary>
        Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input);
        /// <summary>
        /// 编辑联系人基本信息，除电话号码外
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
         Task UpdateBasePersonAsync(UpdateBasePersonInput input);
        Task<GetPersonBaseForEditOutput> GetPersonBaseForEditAsync(PersonBaseEditDto input);

        Task CreatePhoneNumberAsync(CreatePhoneNumberInput input);
        
    }
}
