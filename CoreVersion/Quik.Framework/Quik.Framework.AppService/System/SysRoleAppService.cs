using System;
using System.Collections.Generic;
using System.Text;
using Quik.Framework.Entity;
using Quik.Framework.Entity.DbContext;
using SqlSugar;

namespace Quik.Framework.AppService.System
{
    public class SysRoleAppService
    {
        private readonly SqlSugarClient Sqldb;
        private readonly ISqlSugarDbContext iSqlContext=new SqlSugarDbContext();

        public SysRoleAppService()
        {
            Sqldb = iSqlContext.GetInstance();
        }
        public int GetUserCunt()
        {
            int total = 0;
            
            total = Sqldb.Queryable<sys_role>().Count();
            return total;
        }
    }
}
