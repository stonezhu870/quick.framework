using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Chloe.Infrastructure;
using Chloe.MySql;
using MySql.Data.MySqlClient;

namespace RealFarm.DbContext
{
    public class MySqlChloeDbContext : IDbConnectionFactory
    {
        private string _connString = ConfigurationManager.ConnectionStrings["mysqlDbConn"].ConnectionString;

        public MySqlChloeDbContext()
        {

        }
        //public MySqlChloeDbContext(string connString)
        //{
        //    this._connString = connString;
        //}
        public IDbConnection CreateConnection()
        {
            MySqlConnection conn = new MySqlConnection(this._connString);
            return conn;
        }

        private MySqlContext _context;
        public MySqlContext MySqlChloeContextInstance()
        {
            if (_context == null)
            {
                _context = new MySqlContext(new MySqlChloeDbContext());
            }

            return _context;
        }
    }
}