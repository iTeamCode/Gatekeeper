using Gatekeeper.DomainModel.Common;
using Gatekeeper.Toolbox.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Common
{
    public class DataVisitorUnitTest
    {
        [Fact(DisplayName = "DataVisitor.ICommonDataVisitor")]
        public void Demo()
        {
            var dv = DataVisitor.Create<ICommonDataVisitor>();
            var data = dv.FetchChurchInfomation(15);
        }

        [Fact(DisplayName = "DataVisitor.IDashboardDataVisitor")]
        public void Demo00()
        {
            var dv = DataVisitor.Create<IDashboardDataVisitor>();
            var data = dv.FetchGivingData(15, DateTime.Parse("2015-06-11"), DateTime.Now.Date, new List<int> { 45, 3926, 4284 });
        }
        
    }

}
