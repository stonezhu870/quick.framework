using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quik.Framework.DbContext;
using Quik.Framework.Dto;
using Quik.Framework.Entity;
using SqlSugar;

namespace Quik.Framework.AppService
{
    public class SysMenuAppService : BaseAppService
    {
        public SysMenuAppService(IMySqlSugarDbContext sqlContext)
            :base(sqlContext)
        {

        }
        public DataGridEx GetMenuList(DataGridEx param)
        {

            int total = 0;
            var query = Sqldb.Queryable<sys_menu>()
                .OrderBy(s => s.create_time,OrderByType.Desc)
                .ToPageList(param.pageCurrent, param.pageSize, ref total);

            param.list = query;
            param.total = total;
            return param;
        }
        public List<sys_menu> GetMenuList()
        {
             var query = Sqldb.Queryable<sys_menu>()
                .OrderBy(s => s.menu_sort)
                .ToList();

            return query;
        }

        public void AddMenu(sys_menu dto)
        {
            dto.id = Guid.NewGuid().ToString("N");
            dto.create_time=DateTime.Now;
            dto.creator = "admin";
            dto.menu_icon = dto.menu_font;

            Sqldb.Insertable(dto).ExecuteCommand();
        }

        public void UpdateMenu(sys_menu dto)
        {
            Sqldb.Updateable(dto).IgnoreColumns(s => new {s.create_time, s.creator, s.menu_type}).ExecuteCommand();
        }
        public sys_menu GetMenuById(string id)
        {

            return Sqldb.Queryable<sys_menu>().Where(s => s.id == id).First();
        }

        public List<sys_menu> GetTopMenuList()
        {
            return Sqldb.Queryable<sys_menu>().Where(s => SqlFunc.IsNullOrEmpty(s.parent_id)).OrderBy(s => s.menu_sort).ToList();


        }

        public List<RoleMenuDto> GetRoleMenu()
        {
            var list = Sqldb.Queryable<sys_menu>().OrderBy(s => s.menu_sort).Select(s => new RoleMenuDto()
            {
                id = s.id,
                menu_name = s.menu_name,
                menu_sort = s.menu_sort,
                menu_url = s.menu_url,
                parent_id = s.parent_id
            }).ToList();
            return list;
        }
    }
}
