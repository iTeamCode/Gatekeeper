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

            string whereStr = string.Empty;
            if (widgetItemIds != null && widgetItemIds.Count > 0)
            {
                whereStr = string.Format("AND widgetItem.[UserWidgetItemID] IN ({0})", string.Join<int>(",", widgetItemIds));
            }
            command.CommandText = command.CommandText.Replace("#WhereStr#", whereStr);

            return command.ExecuteCommandToEntitys<ReportDataModel>();
        }
    }


}
