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
    public class SysUserAppService:BaseAppService
    {
        public SysUserAppService(IMySqlSugarDbContext sqlContext)
            :base(sqlContext)
        {

        }

        public DataGridEx GetUserList(DataGridEx param)
        {

            int total = 0;
            var query = Sqldb.Queryable<sys_user>()
                .OrderBy(s => s.create_time, OrderByType.Desc)
                .ToPageList(param.pageCurrent, param.pageSize, ref total);

            param.list = query;
            param.total = total;
            return param;
        }


        public void SaveData(sys_user dto)
        {
            if (string.IsNullOrEmpty(dto.id))
            {
                dto.id = Guid.NewGuid().ToString("N");
                dto.create_time = DateTime.Now;
                dto.creator = "app";
                Sqldb.Insertable(dto).ExecuteCommand();
            }
            else
            {
                Sqldb.Updateable(dto).IgnoreColumns(s => new { s.creator, s.create_time }).ExecuteCommand();
            }
        }

        public sys_user GetDataById(string id)
        {
            return Sqldb.Queryable<sys_user>().First();
        }
    }
}
