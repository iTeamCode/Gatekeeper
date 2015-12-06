using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Launchpad
{
    public class Launchpad_SignIn_Success_Test
    {
        [Fact]
        public void SignIn_Success()
        {
            //Create manager & Navigate page to Login.
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Launchpad_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(manager.Driver);
            signInPage.Action_SignIn("ft.autotester@gmail.com", "FT4life!");

            //Waiting & Check page.
            Assert.True(manager.IsCurrentPage(PageAlias.Launchpad_Home));
            manager.Driver.Close();
        }
    }
    
    public class Launchpad_SignIn_Error_Test : IClassFixture<SingleBrowserFixture>
    {
        private IDriverManager _driverManager { get; set; }
        private readonly ITestOutputHelper _output;
        public Launchpad_SignIn_Error_Test(ITestOutputHelper output, SingleBrowserFixture fixture)
        {
            _driverManager = fixture.DriverManager;
            _output = output;
        }
        [Theory]
        [InlineData("", "", "Login attempt failed. Verify your information and try again.")]
        //[InlineData("ft.tester", "", "", "Password is required.")]
        //[InlineData("ft.tester", "FT4life!", "", "Church code is required.")]
        public void SignIn_Error(string userName, string pwd, string errorMsg)
        {
            //Create manager & Navigate page to Login.
            _driverManager.NavigateTo(PageAlias.Launchpad_SignIn);

            var signInPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(_driverManager.Driver);
            signInPage.Action_SignIn(userName, pwd);

            //Waiting & Check page.
            var isPass = signInPage.Check_ErrorMessage(errorMsg);
            _output.WriteLine("[Info]:Error message '{0}'", signInPage.ErrorMsg);
            Assert.True(isPass, string.Format("error message is not '{0}'", errorMsg));
        }
    }
}
