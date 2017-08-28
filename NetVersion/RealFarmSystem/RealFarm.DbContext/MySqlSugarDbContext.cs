using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using RealFarm.Utils;
using SqlSugar;

namespace RealFarm.DbContext
{
    public class MySqlSugarDbContext : IMySqlSugarDbContext,IDisposable
    {
        public SqlSugarClient _db;
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["mysqlDbConn"].ConnectionString;
        public SqlSugarClient GetInstance()
        {
            if (_db == null)
            {
                _db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConnectionString,
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = false,
                    InitKeyType = InitKeyType.SystemTable,
                });//获SqlSugarClient对象

            }
            return _db;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                // LogNHelper.Exception("释放了资源");
            }
        }
    }
}