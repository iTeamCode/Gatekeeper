using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.DomainModel.Dashboard
{
    public class ChartPointModel
    {
        /// <summary>
        /// get or set 'point data value'
        /// </summary>
        public decimal? PointData { get; set; }
        /// <summary>
        /// get or set 'X_Axis'
        /// </summary>
        public string X_Axis { get; set; }
        /// <summary>
        /// get or set 'Year'
        /// </summary>
        public string Year { get; set; }
    }
}
