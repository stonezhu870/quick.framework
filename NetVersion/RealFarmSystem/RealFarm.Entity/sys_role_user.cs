using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace RealFarm.Entity
{
    public class sys_role_user
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
         [SugarColumn(IsPrimaryKey = true)]
        public int id {get;set;}

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
        public Guid user_id {get;set;}

    }
}
