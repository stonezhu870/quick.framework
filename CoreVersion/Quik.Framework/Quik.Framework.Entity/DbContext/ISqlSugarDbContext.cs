using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Quik.Framework.Entity.DbContext
{
    public interface ISqlSugarDbContext
    {
        SqlSugarClient GetInstance();
    }
}
