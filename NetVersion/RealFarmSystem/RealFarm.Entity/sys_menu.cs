using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlSugar;

namespace RealFarm.Entity
{
    public class sys_menu
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string id { get; set; }
        public string menu_name { get; set; }
        public string menu_url { get; set; }
        public int menu_sort { get; set; }
        public int menu_type { get; set; }
        public string parent_id { get; set; }
        public string menu_font { get; set; }
        public string menu_icon { get; set; }
        public string remark { get; set; }
        public string creator { get; set; }
        public DateTime create_time { get; set; }
    }
}