using Abp.EntityFrameworkCore;
using ABP.TPLMS.Entitys;
using ABP.TPLMS.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ABP.TPLMS.EntityFrameworkCore.Repositories
{
    public class ModuleRepository : TPLMSRepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(IDbContextProvider<TPLMSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(string ids)
        {
            var idList = ids.Split(',');
            Expression<Func<Module, bool>> exp = m => idList.Contains(m.Id.ToString());

            bool result = true;
            Delete(exp);
            return result;

        }
        /// <summary>
        /// 分页查询功能模块
        /// </summary>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">每页多少条</param>
        /// <returns>模块列表</returns>
        public IEnumerable<Module> LoadModules(int pageindex, int pagesize)
        {
            return Context.Modules.OrderBy(u => u.Id).Skip((pageindex - 1) * pagesize).Take(pagesize);

        }
    }
}
