using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Coordinator;
using Gatekeeper.PageObject.Dashboard;
using Gatekeeper.PageObject.Launchpad;
using Gatekeeper.PageObject.Teacher;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Common
{
    public class SignInPerformance : IDisposable//: IClassFixture<SingleBrowserFixture>
    {

        private const string cst_DisplayName = "Common.Performance";

        private IDriverManager _driverManager { get; set; }
        private readonly ITestOutputHelper _output;
        public SignInPerformance(ITestOutputHelper output)
        {
            //Create Browser driver.
            this._driverManager = GatekeeperFactory.CreateDriverManager();
            _output = output;
        }
        public void Dispose()
        {            
            //Close browser driver.
            if (this._driverManager != null && this._driverManager.Driver != null)
            {
                this._driverManager.Driver.Close();
            }
        }


        [Fact(DisplayName = cst_DisplayName + ".SignTimeTeacher")]
        public void SimpleSignIn_Teacher()
        {
            Stopwatch stopwatch = new Stopwatch();
            
            _driverManager.NavigateTo(PageAlias.Teacher_SignIn);
            var signInPage = GatekeeperFactory.CreatePageManager<TeacherSignInPage>(_driverManager.Driver);
            signInPage.Action_SignIn("winnie.wang@activenetwork.com", "111111", "dc");
            stopwatch.Start();
            _driverManager.IsCurrentPage(PageAlias.Teacher_Roster);
            stopwatch.Stop();

            _output.WriteLine("time : {0} ms", stopwatch.ElapsedMilliseconds);
        }
        [Fact(DisplayName = cst_DisplayName + ".SignTimeLaunchpad")]
        public void SimpleSignIn_Launchpad()
        {
            Stopwatch stopwatch = new Stopwatch();

            _driverManager.NavigateTo(PageAlias.Launchpad_SignIn);
            var signInPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(_driverManager.Driver);
            signInPage.Action_SignIn("winnie.wang@activenetwork.com", "111111", "dc");
            stopwatch.Start();
            _driverManager.IsCurrentPage(PageAlias.Launchpad_Home);
            stopwatch.Stop();

            _output.WriteLine("time : {0} ms", stopwatch.ElapsedMilliseconds);
        }
        [Fact(DisplayName = cst_DisplayName + ".SignTimeDashboard")]
        public void SimpleSignIn_Dashboard()
        {
            Stopwatch stopwatch = new Stopwatch();

            _driverManager.NavigateTo(PageAlias.Dashboard_SignIn);
            var teacherSignInPage = GatekeeperFactory.CreatePageManager<DashboardSignInPage>(_driverManager.Driver);
            teacherSignInPage.Action_SignIn("ft.tester", "FT4life!", "DC");
            stopwatch.Start();
            _driverManager.IsCurrentPage(PageAlias.Dashboard_Home);
            stopwatch.Stop();

            _output.WriteLine("time : {0} ms", stopwatch.ElapsedMilliseconds);
        }
        [Fact(DisplayName = cst_DisplayName + ".SignTimeCoordinator")]
        public void SimpleSignIn_Coordinator()
        {
            Stopwatch stopwatch = new Stopwatch();

            _driverManager.NavigateTo(PageAlias.Coordinator_RegisterDevice);
            var teacherSignInPage = GatekeeperFactory.CreatePageManager<CoordinatorRegisterDevicePage>(_driverManager.Driver);
            teacherSignInPage.Action_SignIn("ft.tester", "FT4life!", "DC");
            stopwatch.Start();
            _driverManager.IsCurrentPage(PageAlias.Coordinator_ActivityCode);
            stopwatch.Stop();

            _output.WriteLine("time : {0} ms", stopwatch.ElapsedMilliseconds);
        }

        //[Theory(DisplayName = cst_DisplayName + ".SignInTime")]
        //[InlineData(AppAlias.Launchpad, "winnie.wang@activenetwork.com", "111111", "DC")]
        //[InlineData(AppAlias.Dashboard, "ft.tester", "FT4life!", "DC")]
        //[InlineData(AppAlias.Coordinator, "ft.tester", "FT4life!", "DC")]
        //[InlineData(AppAlias.Teacher, "winnie.wang@activenetwork.com", "111111", "DC")]
        //public void SimpleSignIn(AppAlias app, string userName, string password, string churchCode)
        //{
        //    var stopwatch = new Stopwatch();
        //    var signInPageAlias = GetSignInPageAlias(app);
        //    var homePageAlias = GetHomePageAlias(app);

        //    _driverManager.NavigateTo(signInPageAlias);
        //    var signInPage = GetPageObject(app);
        //    signInPage.Action_SignIn(userName, password, churchCode);
        //    stopwatch.Start();
        //    _driverManager.IsCurrentPage(homePageAlias);
        //    stopwatch.Stop();

        //    _output.WriteLine("time : {0} ms", stopwatch.ElapsedMilliseconds);
        //}

        //private PageAlias GetSignInPageAlias(AppAlias app)
        //{
        //    var alias = PageAlias.Empty_Page;
        //    switch (app)
        //    {
        //        case AppAlias.Launchpad:
        //            alias = PageAlias.Launchpad_SignIn;
        //            break;
        //        case AppAlias.Dashboard:
        //            alias = PageAlias.Dashboard_SignIn;
        //            break;
        //        case AppAlias.Coordinator:
        //            alias = PageAlias.Coordinator_RegisterDevice;
        //            break;
        //        case AppAlias.Teacher:
        //            alias = PageAlias.Teacher_SignIn;
        //            break;
        //        default:
        //            break;
        //    }
        //    return alias;
        //}
        //private PageAlias GetHomePageAlias(AppAlias app)
        //{
        //    var alias = PageAlias.Empty_Page;
        //    switch (app)
        //    {
        //        case AppAlias.Launchpad:
        //            alias = PageAlias.Launchpad_Home;
        //            break;
        //        case AppAlias.Dashboard:
        //            alias = PageAlias.Dashboard_Home;
        //            break;
        //        case AppAlias.Coordinator:
        //            alias = PageAlias.Coordinator_ActivityCode;
        //            break;
        //        case AppAlias.Teacher:
        //            alias = PageAlias.Teacher_Roster;
        //            break;
        //        default:
        //            break;
        //    }
        //    return alias;
        //}
        //private ISignInPage GetPageObject(AppAlias app)
        //{
        //    ISignInPage objPage = null;
        //    switch (app)
        //    {
        //        case AppAlias.Launchpad:
        //            objPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(_driverManager.Driver);
        //            break;
        //        case AppAlias.Dashboard:
        //            objPage = GatekeeperFactory.CreatePageManager<DashboardSignInPage>(_driverManager.Driver);
        //            break;
        //        case AppAlias.Coordinator:
        //            objPage = GatekeeperFactory.CreatePageManager<CoordinatorRegisterDevicePage>(_driverManager.Driver);
        //            break;
        //        case AppAlias.Teacher:
        //            objPage = GatekeeperFactory.CreatePageManager<TeacherSignInPage>(_driverManager.Driver);
        //            break;
        //        default:
        //            break;
        //    }
        //    return objPage;
        //}
    }
}
