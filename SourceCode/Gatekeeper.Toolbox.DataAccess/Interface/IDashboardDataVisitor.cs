using Gatekeeper.DomainModel.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    public interface IDashboardDataVisitor : IDataVisitor
    {
        /// <summary>
        /// Fetch Giving Data
        /// </summary>
        /// <param name="churchId">church Id</param>
        /// <param name="startDate">start Date</param>
        /// <param name="endDate">end Date</param>
        /// <param name="widgetItemIds">widget item id list</param>
        /// <returns>Report data</returns>
        List<ReportDataModel> FetchGivingData(int churchId, DateTime startDate, DateTime endDate, List<int> widgetItemIds);
        /// <summary>
        /// Fetch Attribute Data
        /// </summary>
        /// <param name="churchId">church Id</param>
        /// <param name="startDate">start Date</param>
        /// <param name="endDate">end Date</param>
        /// <param name="widgetItemIds">widget item id list</param>
        /// <returns>Report data</returns>
        List<ReportDataModel> FetchAttributeData(int churchId, DateTime startDate, DateTime endDate, List<int> widgetItemIds);
        /// <summary>
        /// Fetch Attribute Data
        /// </summary>
        /// <param name="churchId">church Id</param>
        /// <param name="startDate">start Date</param>
        /// <param name="endDate">end Date</param>
        /// <param name="mnList">ministry list</param>
        /// <param name="gtList">giving type list</param>
        /// <returns>Report data</returns>
        List<ReportDataModel> FetchAttendanceData(int churchId, DateTime startDate, DateTime endDate, List<int> mnList, List<int> gtList);
    }
}
