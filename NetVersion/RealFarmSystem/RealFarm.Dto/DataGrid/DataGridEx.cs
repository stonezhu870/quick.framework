using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealFarm.Dto
{
    public class DataGridEx<T> where T : class
    {
        public DataGridEx()
        {
            this.total = 0;
            this.list = new List<T>();
        }

        public int pageCurrent { get; set; }
        public int total { get; set; }
        public int pageSize { get; set; }
        public List<T> list { get; set; }
        //public string msg { get; set; }
        //public List<T> footer { get; set; }
    }

    public class DataGridEx
    {
        public DataGridEx()
        {
            this.total = 0;
            //this.list = new List<T>();
        }

        public int pageCurrent { get; set; }
        public int total { get; set; }
        public int pageSize { get; set; }
        public object list { get; set; }
    }
    public class GridParams
    {
        public int pageCurrent { get; set; }
        public int pageSize { get; set; }
    }
}