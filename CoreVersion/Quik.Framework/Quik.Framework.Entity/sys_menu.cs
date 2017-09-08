using System;
using System.Linq;
using System.Text;

namespace Quik.Framework.Entity
{
    public class sys_menu
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
        public string menu_name {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string menu_url {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int16 menu_sort {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Boolean menu_type {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string parent_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string menu_font {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string menu_icon {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:'' 
        /// Nullable:True 
        /// </summary>
        public string remark {get;set;}

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
