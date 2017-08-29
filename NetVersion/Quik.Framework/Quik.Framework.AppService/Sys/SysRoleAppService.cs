using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quik.Framework.DbContext;
using Quik.Framework.Dto;
using Quik.Framework.Entity;
using SqlSugar;

namespace Quik.Framework.AppService.Sys
{
    public class SysRoleAppService:BaseAppService
    {
        public SysRoleAppService(IMySqlSugarDbContext sqlContext)
            :base(sqlContext)
        {

        }

        public DataGridEx GetRoleList(DataGridEx param)
        {

            int total = 0;
            var query = Sqldb.Queryable<sys_role>()
                .OrderBy(s => s.create_time, OrderByType.Desc)
                .ToPageList(param.pageCurrent, param.pageSize, ref total);

            param.list = query;
            param.total = total;
            return param;
        }


        public void SaveRoleData(sys_role dto)
        {
            if (string.IsNullOrEmpty(dto.id))
            {
                dto.id = Guid.NewGuid().ToString("N");
                dto.creator = "admin";
                dto.create_time = DateTime.Now;
                Sqldb.Insertable(dto).ExecuteCommand();

            }
            else
            {
                Sqldb.Updateable(dto).IgnoreColumns(s => new {s.create_time, s.creator}).ExecuteCommand();
            }
        }

        public sys_role GetRoleById(string id)
        {
            return Sqldb.Queryable<sys_role>().First();
        }
    }
}
