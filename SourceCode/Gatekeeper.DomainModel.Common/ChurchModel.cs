using Gatekeeper.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Common
{
    public class ChurchModel
    {
        /// <summary>
        /// get or set "Church Id"
        /// </summary>
        [DataMapping("ChurchId", DbType.Int32)]
        public int ChurchId { get; set; }
        /// <summary>
        /// get or set "Church Name"
        /// </summary>
        [DataMapping("ChurchName", DbType.String)]
        public string ChurchName { get; set; }
    }
}
