using System;
using System.Linq;
using System.Text;

namespace Quik.Framework.Entity
{
    public class sys_user
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
        public string username {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string password {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string nickname {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string id_number {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string mobile_tel {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public SByte gender {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 sysrole_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Boolean status {get;set;}

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

        /// <summary>
        /// Desc:- 
        /// Default:NULL 
        /// Nullable:True 
        /// </summary>
        public string remark {get;set;}

    }
}
