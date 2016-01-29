using Gatekeeper.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Launchpad
{
    public class UserProfileModel
    { 
        public string Key { get; set; }            
        /// <summary>
        /// get or set 'FirstName'
        /// </summary>
        [DataMapping("FirstName", DbType.String)]
        public string FirstName { get; set; }
        /// <summary>
        /// get or set 'LastName'
        /// </summary>
        [DataMapping("LastName", DbType.String)]
        public string LastName { get; set; }
        ///// <summary>
        ///// get or set 'Street1'
        ///// </summary>
        //[DataMapping("Address1", DbType.String)]// flag is incorrect, I didn't find the correct one in DB
        //public string Street1 { get; set; }
        ///// <summary>
        ///// get or set 'city'
        ///// </summary>
        //[DataMapping("city", DbType.String)]// flag is incorrect,
        //public string City { get; set; }
        ///// <summary>
        ///// get or set 'zipcode'
        ///// </summary>
        //[DataMapping("zipcode", DbType.String)]// flag is incorrect,
        //public string Zipcode { get; set; }
        
    }
}
