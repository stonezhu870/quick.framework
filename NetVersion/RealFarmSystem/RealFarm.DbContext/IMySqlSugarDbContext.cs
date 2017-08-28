using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace RealFarm.DbContext
{
    public interface IMySqlSugarDbContext
    {
        SqlSugarClient GetInstance();
    }
}
