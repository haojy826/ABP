using Abp.Application.Navigation;
using Abp.Localization;
using ABP.TPLMS.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ABP.TPLMS.Web.Startup
{
    public class DynamicAddMenu
    {
        Modules.IModuleAppService _moduleAppService;
        public DynamicAddMenu(Modules.IModuleAppService moduleApp)//依赖注入

        { 
            _moduleAppService = moduleApp; 
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        public MenuItemDefinition AddMenus()
        {
            #region 动态菜单
            var modules = _moduleAppService.GetAll();//获取所有的模块信息
            var project = new MenuItemDefinition(//定义添加菜单的属性，这是一个主菜单，下面还有子菜单，所以没有URL
                    "Business",
                    L("Business"),

                    icon: "menu",
                    order: 5//顺序
                    );

            var list = modules.ToList();//将模块信息装换成list格式
            FillMenu(project, 0, list);//实现子菜单
            return project;//返回的是菜单
            #endregion
        }

        /// <summary>
        /// 添加子菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="ParentId"></param>
        /// <param name="modules"></param>
        // 递归算法
        private void FillMenu(MenuItemDefinition menu, int ParentId, List<Module> modules)
        {
            List<Module> drs = modules.Where(x => x.ParentId == ParentId).ToList();
            if (drs == null || drs.Count <= 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < drs.Count; i++)
                {
                    Module dr = drs[i];
                    MenuItemDefinition nodeName = new MenuItemDefinition(
                       dr.Name,
                       L(dr.DisplayName),
                       url: dr.Url,
                       icon: "business",
                       requiredPermissionName: dr.RequiredPermissionName,
                       customData: i
                   );
                    menu.AddItem(nodeName);
                    FillMenu(nodeName, dr.Id, modules);
                }
            }
        }
        /// <summary>
        /// 本地化
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TPLMSConsts.LocalizationSourceName);

        }
    }
}