using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MyPhoneBook.Application.Dto;
using MyPhoneBook.Application.PhoneBooks.Dtos;
using MyPhoneBook.Application.PhoneBooks.PhoneNumbers.Dto;
using MyPhoneBook.Core.PhoneBooks.Persons;
using MyPhoneBook.Core.PhoneBooks.PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneBook.Application.PhoneBooks
{
    public class PersonAppService : MyPhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
       

        // private readonly IObjectMapper _objectMapper;
        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
            

        }
        //public PersonAppService(IRepository<Person> personRepository, IObjectMapper objectMapper)
        // {
        //   _personRepository = personRepository;
        //  _objectMapper = objectMapper;
        // }
        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {
            if (input.PersonEditDto.Id.HasValue)
            {
                await UpdatePersonAsync(input.PersonEditDto);

            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
            }
        }
        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            var entity = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(entity);
        }
        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);//先查询一下
            //await _personRepository.UpdateAsync(input.MapTo(entity));
            ObjectMapper.Map(input, entity);
            //await _personRepository.UpdateAsync(ObjectMapper.Map(input, entity));//可以不使用update进行更新，任务也能自动更新
        }


        public async Task CreatePhoneNumberAsync(CreatePhoneNumberInput input)
        {
            await AddPhoneNumberAsync(input.PhoneNumbersEditDto);
        }
        protected async Task AddPhoneNumberAsync(PhoneNumbersEditDto input)
        {
           
             var entity=await _personRepository.GetAsync(input.PersonId);//先查询一下
             ObjectMapper.Map(input, entity);
        }

        public async Task UpdateBasePersonAsync(UpdateBasePersonInput input)
        {


            await BasePersonEditAsync(input.PersonBaseEditDto);



        }
        protected async Task BasePersonEditAsync(PersonBaseEditDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);//先查询一下
                                                                          //await _personRepository.UpdateAsync(input.MapTo(entity));
            ObjectMapper.Map(input, entity);
            //await _personRepository.UpdateAsync(ObjectMapper.Map(input, entity));//可以不使用update进行更新，任务也能自动更新
        }

        public async Task DeletePersonAsync(EntityDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id);//查询这个id是否存在
            if (entity == null)
            {
                throw new UserFriendlyException("该联系人已经消失在数据库中了，无法二次删除！");
            }
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            var query = _personRepository.GetAllIncluding(a => a.PhoneNumbers);//这个只是相当于SQL语句,后面使用的是λ表达式
            var personCount = await query.CountAsync();//统计条数
            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();//Sorting是按Id进行排序的
            // var dtos = persons.MapTo<List<PersonListDto>>();//这个方法过时了
            var dtos = ObjectMapper.Map<List<PersonListDto>>(persons);
            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            var person = await _personRepository.GetAllIncluding(a => a.PhoneNumbers).FirstOrDefaultAsync(a => a.Id == input.Id.Value);
            //  return person.MapTo<PersonListDto>();
            return ObjectMapper.Map<PersonListDto>(person);
        }

        public async Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetPersonForEditOutput();
            PersonEditDto personEditDto;
            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAllIncluding(a => a.PhoneNumbers).FirstOrDefaultAsync(a => a.Id == input.Id.Value);
                // personEditDto = entity.MapTo<PersonEditDto>();
                personEditDto = ObjectMapper.Map<PersonEditDto>(entity);
            }
            else
            {
                personEditDto = new PersonEditDto();
            }
            output.Person = personEditDto;
            return output;
        }

        public async Task<GetPersonBaseForEditOutput> GetPersonBaseForEditAsync(PersonBaseEditDto input)
        {
            var output = new GetPersonBaseForEditOutput();
            PersonBaseEditDto personBaseEditDto;

            var entity = await _personRepository.GetAsync(input.Id.Value);

            personBaseEditDto = ObjectMapper.Map<PersonBaseEditDto>(entity);


            output.Person = personBaseEditDto;
            return output;
        }

    }
}
