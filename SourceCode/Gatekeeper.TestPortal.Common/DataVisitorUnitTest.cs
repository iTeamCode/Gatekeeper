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
        [Fact]
        public void Demo()
        {
            var dv = DataVisitor.Create<ICommonDataVisitor>();
            var data = dv.FetchChurchInfomation(15);
        }
    }
}
