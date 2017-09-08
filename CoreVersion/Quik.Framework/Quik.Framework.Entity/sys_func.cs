using System;
using System.Linq;
using System.Text;

namespace Quik.Framework.Entity
{
    public class sys_func
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string func_cnname {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string func_name {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:NULL 
        /// Nullable:True 
        /// </summary>
        public string func_icon {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:NULL 
        /// Nullable:True 
        /// </summary>
        public string func_class {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int16 func_sort {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:NULL 
        /// Nullable:True 
        /// </summary>
        public string remark {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'0000-00-00 00:00:00' 
        /// Nullable:False 
        /// </summary>
        public DateTime create_time {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string creator {get;set;}

    }
}
