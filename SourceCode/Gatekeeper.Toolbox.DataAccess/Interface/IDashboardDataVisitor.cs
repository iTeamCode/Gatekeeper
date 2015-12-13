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
        List<ReportDataModel> FetchGivingData(int churchId, DateTime startDate, DateTime endDate, List<int> widgetItemIds);
    }
}
