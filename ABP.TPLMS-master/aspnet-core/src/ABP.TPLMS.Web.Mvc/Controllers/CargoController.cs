using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Validation;
using ABP.TPLMS.Controllers;
using ABP.TPLMS.Cargos;
using ABP.TPLMS.Cargos.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abp.Web.Models;
using AutoMapper;

namespace ABP.TPLMS.Web.Controllers
{
    //检查当前用户是否登录，如果没有登录，则控制器不能被使用
    [AbpMvcAuthorize]
    public class CargoController : TPLMSControllerBase//继承这个项目的控制器基类，这个基类是继承的AbpController，继承自AbpController就自动实现了一些方法，审计日志会自动开启
    {
        const int MaxNum = 10;

        private readonly ICargoAppService _cargoAppService;//依赖注入

        public CargoController(ICargoAppService cargoAppService)
        {
            _cargoAppService = cargoAppService;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewData是字典类型，赋值方式用字典方式，通过key值读取对应的value，ViewData[“myName”]
            ViewData["SupplierId"] = "100001";//在视图中使用，固定了供应商的Id，添加的时候只能添加这一个供应商的信息
            return View();
        }

       
        //ABP不对json字符串进行封装
        [DontWrapResult]
        public string List()
        {

            var page = Request.Form["page"].ToString();
            var size = Request.Form["rows"].ToString();
            int pageIndex = page == null ? 1 : int.Parse(page);
            int pageSize = size == null ? 20 : int.Parse(size);
            PagedCargoResultRequestDto paged = new PagedCargoResultRequestDto();
            paged.MaxResultCount = pageSize;
            paged.SkipCount = ((pageIndex - 1) < 0 ? 0 : pageIndex - 1) * pageSize;
            paged.CargoName = Request.Form["Name"].ToString();
            paged.CargoCode = Request.Form["Code"].ToString();
            paged.HsCode = Request.Form["HsCode"].ToString();

            var cargoList = _cargoAppService.GetAllAsync(paged).GetAwaiter().GetResult().Items;
            int total = _cargoAppService.GetAllAsync(paged).GetAwaiter().GetResult().TotalCount; //1000;
            var json = JsonEasyUI(cargoList, total);
            return json;

        }

        //使用post方法，禁止验证
        [HttpPost]
        [DisableValidation]
        public ActionResult Add(CargoDto createDto)
        {
            var json = string.Empty;
            string result = "NO";
            if (createDto == null)
            {
                json = JsonEasyUIResult(0, result);
                return Content(json);

            }
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CargoDto, CreateUpdateCargoDto>());
                var mapper = config.CreateMapper();
                var cargo = mapper.Map<CreateUpdateCargoDto>(createDto);


                var obj = _cargoAppService.CreateAsync(cargo);
                int id = obj.GetAwaiter().GetResult().Id;
                if (obj != null)
                {
                    json = JsonEasyUIResult(id, "OK");

                }
                else

                {
                    json = JsonEasyUIResult(0, result);

                }
            }
            catch (Exception ex)
            {
            }
            return Content(json);

        }

        [HttpPost]
        [DisableValidation]
        public ActionResult Update(CreateUpdateCargoDto updateDto)
        {
            var json = string.Empty;
            string result = "NO";

            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CargoDto, CreateUpdateCargoDto>());
                var mapper = config.CreateMapper();
                var cargo = mapper.Map<CreateUpdateCargoDto>(updateDto);

                var obj = _cargoAppService.UpdateAsync(updateDto);
                int id = obj.GetAwaiter().GetResult().Id;

                if (obj != null)
                {
                    json = JsonEasyUIResult(id, "OK");

                }
                else

                {
                    json = JsonEasyUIResult(0, result);

                }
            }
            catch (Exception ex)
            {

            }

            return Content(json);

        }

        public ActionResult Delete(string ids)
        {
            string result = "NO";

            try
            {
                result = _cargoAppService.DeleteBatch(ids);
            }
            catch
            {

            }

            return Content(result);
        }
    }
}