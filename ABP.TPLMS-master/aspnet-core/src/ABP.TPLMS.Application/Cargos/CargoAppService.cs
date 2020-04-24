using Abp.Application.Services;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.Cargos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ABP.TPLMS.Cargos
{
    public class CargoAppService : AsyncCrudAppService<Cargo, CargoDto, int, PagedCargoResultRequestDto,
                             CreateUpdateCargoDto, CreateUpdateCargoDto>, ICargoAppService

    {
        public CargoAppService(IRepository<Cargo, int> repository)//构造函数继承自基类
            : base(repository)

        {

        }
        /// <summary>
        /// 实现按条件查询（重写），输出的是实体的全部信息。CrudAppServiceBase中的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<Cargo> CreateFilteredQuery(PagedCargoResultRequestDto input)
        {
            //从基类中获取的信息再进行筛选
            return base.CreateFilteredQuery(input)
                 .Where(t => t.CargoName.Contains(input.CargoName))
                 .Where(t => t.CargoCode.Contains(input.CargoCode))
                 .Where(t => t.HSCode.Contains(input.HsCode))
                 ;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">所有要删除数据的Id</param>
        /// <returns>是否删除成功</returns>
        public string DeleteBatch(string ids)
        {

            string result = "NO";
            var idList = ids.Split(',');
            foreach (var item in idList)//一个一个删除
            {
                var id = 0;
                int.TryParse(item, out id);//转换类型，字符串类型转换成int
                var cargoList = base.GetEntityByIdAsync(id);//通过Id获取实体信息
                //将实体映射到实体DTO中
                var cargo = MapToEntityDto(cargoList.GetAwaiter().GetResult());//MapToEntityDto是CrudAppServiceBase中的方法

                var obj= base.DeleteAsync(cargo);//异步删除实体信息

                obj.GetAwaiter().GetResult();//获取obj中的信息
                if (obj != null)//不为空
                {
                    result = "OK";
                }
            }
            return result;
        }

    }
}