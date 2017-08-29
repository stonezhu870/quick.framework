using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Quik.Framework.DbContext
{
    public interface IMySqlSugarDbContext
    {
        SqlSugarClient GetInstance();
    }
}
