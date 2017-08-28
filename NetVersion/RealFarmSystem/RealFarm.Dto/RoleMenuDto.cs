using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealFarm.Dto
{
    public class RoleMenuDto
    {
        public string id { get; set; }
        public string menu_name { get; set; }
        public string menu_url { get; set; }
        public int menu_sort{ get; set; }
        public string parent_id { get; set; }
    }
}
