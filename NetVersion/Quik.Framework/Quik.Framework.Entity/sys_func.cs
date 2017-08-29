using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Quik.Framework.Entity
{
    public class sys_func
    {
        //[SugarColumn(IsPrimaryKey = true)]
        public long id { get; set; }
        public string func_cnname { get; set; }
        public string func_name { get; set; }
        public string func_icon { get; set; }
        public int func_sort { get; set; }
        public string remark { get; set; }
        public DateTime create_time { get; set; }
        public string creator { get; set; }
    }
}
