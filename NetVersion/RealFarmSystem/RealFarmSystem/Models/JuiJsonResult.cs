using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealFarm.Enum;

namespace RealFarmSystem.Models
{
    public class JuiJsonResult
    {
        public JuiJsonResult()
        {
            statusCode = JuiJsonEnum.Ok;
        }
        public JuiJsonEnum statusCode { get; set; }
        public string message { get; set; }

    }
}