using Gatekeeper.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Dashboard
{
    public class ReportDataModel
    {
        public string Key { get; set; }
        public string X_Axis
        {
            get
            {
                string xAxis = string.Empty;
                if (!string.IsNullOrEmpty(Key))
                {
                    var arry = this.Key.Split('-');
                    if (arry != null && arry.Length == 2)
                    {
                        xAxis = arry[0];
                    }
                } 
                return xAxis;
            }
        }
        public string Year
        {
            get
            {
                string year = string.Empty;
                if (!string.IsNullOrEmpty(Key))
                {
                    var arry = this.Key.Split('-');
                    if (arry != null && arry.Length == 2)
                    {
                        year = arry[1];
                    }
                }
                return year;
            }
        }
        /// <summary>
        /// get or set 'Date'
        /// </summary>
        [DataMapping("Date", DbType.DateTime)]
        public DateTime Date { get; set; }
        /// <summary>
        /// get or set 'Value'
        /// </summary>
        [DataMapping("SummaryNumber", DbType.Decimal)]
        public decimal Value { get; set; }
        /// <summary>
        /// get or set 'Count'
        /// </summary>
        [DataMapping("CountNumber", DbType.Int64)]
        public long Count { get; set; }
    }
}
