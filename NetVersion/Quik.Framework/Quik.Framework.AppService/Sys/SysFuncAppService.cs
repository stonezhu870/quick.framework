using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quik.Framework.AppService;
using Quik.Framework.DbContext;
using Quik.Framework.Dto;
using Quik.Framework.Entity;
using SqlSugar;

namespace Quik.Framework.Sys
{
    public class SysFuncAppService:BaseAppService
    {
        public SysFuncAppService(IMySqlSugarDbContext sqldb)
            :base(sqldb)
        {

        }


        public DataGridEx GetFuncList(DataGridEx param)
        {
            int total = 0;
            var query = Sqldb.Queryable<sys_func>()
                .OrderBy(s => s.func_sort)
                .ToPageList(param.pageCurrent, param.pageSize, ref total);

            param.list = query;
            param.total = total;
            return param;
        }

        public void SaveData(sys_func dto)
        {
            if (dto.id == 0)
            {
                dto.id = NewLongId();
                dto.create_time = DateTime.Now;
                dto.creator = "admin";

                Sqldb.Insertable(dto).ExecuteCommand();
            }
            else
            {
                Sqldb.Updateable(dto).IgnoreColumns(s => new {s.create_time, s.creator}).ExecuteCommand();
            }
        }

        public sys_func GetFuncById(long id)
        {
            return Sqldb.Queryable<sys_func>().Where(s=>s.id==id).First();
        }
    }
}
