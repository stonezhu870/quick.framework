using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Quik.Framework.Entity
{
    public class sys_user
    {

        /// <summary>
        /// Desc:-
        /// Default:-
        /// Nullable:False
        /// </summary>
         [SugarColumn(IsPrimaryKey = true)]
        public string id {get;set;}

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
        public string tel {get;set;}

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
        /// Default:''
        /// Nullable:False
        /// </summary>
        public string head_photo {get;set;}

        /// <summary>
        /// Desc:-
        /// Default:''
        /// Nullable:False
        /// </summary>
        public string province {get;set;}

        /// <summary>
        /// Desc:-
        /// Default:''
        /// Nullable:False
        /// </summary>
        public string city {get;set;}

        /// <summary>
        /// Desc:-
        /// Default:''
        /// Nullable:False
        /// </summary>
        public string county {get;set;}

        /// <summary>
        /// Desc:-
        /// Default:''
        /// Nullable:False
        /// </summary>
        public string village {get;set;}

        /// <summary>
        /// Desc:-
        /// Default:''
        /// Nullable:False
        /// </summary>
        public string role {get;set;}

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

        public string remark { get; set; }
    }
}
