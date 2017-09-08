using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Quik.Framework.Models
{
    public class ResultJson
    {
        /// 状态代码
        /// </summary>
        public bool Status { get; set; }
        //public JuiJsonEnum statusCode { get; set; }
        public object Data { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorNo { get; set; }

        /// <summary>
        /// 状态消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 自定义数据
        /// </summary>
        public object MyObject { get; set; }

        /// <summary>
        /// 自定义数据
        /// </summary>
        public object UMyObject { get; set; }
        /// <summary>
        /// 自定义数据
        /// </summary>
        public object VMyObject { get; set; }
        /// <summary>
        /// 自定义数据
        /// </summary>
        public object WMyObject { get; set; }
        /// <summary>
        /// 自定义数据
        /// </summary>
        public object AMyObject { get; set; }


    }
}