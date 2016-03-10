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
        /// <summary>
        /// get or set 'Street1'
        /// </summary>
        [DataMapping("Street1", DbType.String)]// flag is incorrect, I didn't find the correct one in DB
        public string Street1 { get; set; }
        /// <summary>
        /// get or set 'city'
        /// </summary>
        [DataMapping("City", DbType.String)]// flag is incorrect,
        public string City { get; set; }
        /// <summary>
        /// get or set 'zipcode'
        /// </summary>
        [DataMapping("Zipcode", DbType.String)]// flag is incorrect,
        public string Zipcode { get; set; }

        public override bool Equals(object obj)
        {
            var isEqual = true;
            if (!(obj is UserProfileModel))
            {
                return false;
            }
            var objTemp = obj as UserProfileModel;
            if (objTemp.FirstName != this.FirstName) isEqual = false;
            if (objTemp.LastName != this.LastName) isEqual = false;
            if (objTemp.Street1 != this.Street1) isEqual = false;
            if (objTemp.City != this.City) isEqual = false;
            if (objTemp.Zipcode != this.Zipcode) isEqual = false;
                        
            return isEqual;
        }

        public static bool operator ==(UserProfileModel a, UserProfileModel b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(UserProfileModel a, UserProfileModel b)
        {
            return !a.Equals(b);
        }
        
    }
}
