using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Quik.Framework.Entity
{
    public class sys_role
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string role_name {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string role_code {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string creator {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'0000-00-00 00:00:00' 
        /// Nullable:False 
        /// </summary>
        public DateTime create_time {get;set;}

        /// <summary>
        /// Desc:'' 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string remark {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int16 sort {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Boolean role_super {get;set;}

    }
}
