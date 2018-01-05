using System;
using System.Linq;
using System.Text;

namespace Quik.Framework.Entity
{
    public class sys_role_authorize
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
        public Guid role_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid menu_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Guid menu_pid {get;set;}

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

    }
}
