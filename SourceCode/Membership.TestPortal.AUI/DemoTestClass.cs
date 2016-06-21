using System;
using Xunit;
using Gatekeeper.TestPortal.Dashboard;
using Gatekeeper.Framework.Common;

namespace Membership.TestPortal.AUI
{
    public class DemoTestClass : IClassFixture<MemberShipAuthorizedUserFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Test.Function";

        private IDriverManager _driverManager;
        public DemoTestClass(MemberShipAuthorizedUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            //fixture.CurrentUser
            //check data here;
            //var dv = DataVisitor.Create<ICommonDataVisitor>();

        }
        #endregion Init & check data

        [Fact(DisplayName = cst_DisplayName + "_001")]
        public void DemoTestFunction()
        {
        }
    }
}
