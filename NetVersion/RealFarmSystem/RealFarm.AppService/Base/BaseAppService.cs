using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealFarm.DbContext;
using Snowflake.Net;
using SqlSugar;

namespace RealFarm.AppService
{
    public class BaseAppService
    {
        protected readonly SqlSugarClient Sqldb;
        //private readonly MySqlSugarDb _sqlDbContext = new MySqlSugarDb();
        //public BaseAppService()
        //{
        //    _dbClient = _sqlDbContext.GetInstance();
        //}
        private readonly IMySqlSugarDbContext iSqlContext;
        private readonly IdWorker _idWorker = new IdWorker(1, 1);
        protected BaseAppService(IMySqlSugarDbContext sqlContext)
        {
            iSqlContext = sqlContext;
            Sqldb = iSqlContext.GetInstance();
        }

        protected long NewLongId()
        {
            return _idWorker.NextId();
        }
    }
}
