using FellowshipOne.Framework.Entitys;
using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    public class DashboardDataVisitor : IDashboardDataVisitor
    {
        private static DataManager _dataManager = DataManagerFactory.CreateDataManager(DataBaseType.SQLServer);

        public List<ReportDataModel> FetchGivingData(int churchId, DateTime startDate, DateTime endDate, List<int> widgetItemIds)
        {
            CustomerCommand command = _dataManager.CreateCustomerCommand("Dashboard.FetchGivingData");
            command.SetParameterValue("@ChurchId", churchId);
            command.SetParameterValue("@StartDate", startDate);
            command.SetParameterValue("@EndDate", endDate);

            string whereStr = "AND widgetItem.[UserWidgetItemID] IN (-999)";
            if (widgetItemIds != null && widgetItemIds.Count > 0)
            {
                whereStr = string.Format("AND widgetItem.[UserWidgetItemID] IN ({0})", string.Join<int>(",", widgetItemIds));
            }
            command.CommandText = command.CommandText.Replace("#WhereStr#", whereStr);

            return command.ExecuteCommandToEntitys<ReportDataModel>();
        }


        public List<ReportDataModel> FetchAttributeData(int churchId, DateTime startDate, DateTime endDate, List<int> widgetItemIds)
        {
            CustomerCommand command = _dataManager.CreateCustomerCommand("Dashboard.FetchAttributeData");
            command.SetParameterValue("@ChurchId", churchId);
            command.SetParameterValue("@StartDate", startDate);
            command.SetParameterValue("@EndDate", endDate);

            string whereStr = "AND widgetItem.[UserWidgetItemID] IN (-999)";
            if (widgetItemIds != null && widgetItemIds.Count > 0)
            {
                whereStr = string.Format("AND widgetItem.[UserWidgetItemID] IN ({0})", string.Join<int>(",", widgetItemIds));
            }
            command.CommandText = command.CommandText.Replace("#WhereStr#", whereStr);

            return command.ExecuteCommandToEntitys<ReportDataModel>();
        }

        public List<ReportDataModel> FetchAttendanceData(int churchId, DateTime startDate, DateTime endDate, List<int> mnList, List<int> gtList)
        {
            CustomerCommand command = _dataManager.CreateCustomerCommand("Dashboard.FetchAttendanceData");
            command.SetParameterValue("@ChurchId", churchId);
            command.SetParameterValue("@StartDate", startDate);
            command.SetParameterValue("@EndDate", endDate);

            string whereStr_mn = "AND widgetItem.[UserWidgetItemID] IN (-999)";
            string whereStr_gt = "AND widgetItem.[UserWidgetItemID] IN (-999)";
            if (mnList != null && mnList.Count > 0)
            {
                whereStr_mn = string.Format("AND widgetItem.[UserWidgetItemID] IN ({0})", string.Join<int>(",", mnList));
            }
            if (mnList != null && mnList.Count > 0)
            {
                whereStr_gt = string.Format("AND widgetItem.[UserWidgetItemID] IN ({0})", string.Join<int>(",", gtList));
            }

            command.CommandText = command.CommandText.Replace("#WhereStr_mn#", whereStr_mn);
            command.CommandText = command.CommandText.Replace("#WhereStr_gt#", whereStr_gt);

            return command.ExecuteCommandToEntitys<ReportDataModel>();
        }
    }


}
