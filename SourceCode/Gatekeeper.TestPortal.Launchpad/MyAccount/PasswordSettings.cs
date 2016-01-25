using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Launchpad;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
//using Gatekeeper.Toolbox.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Launchpad
{
    public class PasswordSettings : IClassFixture <LaunchpadHighestAuthorityUserFixture>
    {  
        #region Init & check data
        private const string cst_DisplayName = "MyAccount.PasswordSettings";
        
        private IDriverManager _driverManager;
        public PasswordSettings(LaunchpadHighestAuthorityUserFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            _driverManager.NavigateTo(PageAlias.Launchpad_Password);
            //System.Threading.Thread.Sleep(5000);
        }
        #endregion      
 
        [Theory(DisplayName = cst_DisplayName + ".PwdVerificationTest")]
        [InlineData("", "", "", "The current password is required.")]//Sometimes it is failed because page doesn't stop refreshing.
        [InlineData("111111", "", "", "New password is required.")]
        [InlineData("111111", "bb", "", "New confirm password is required.")]
        [InlineData("111111", "bb", "cc", "Password must be at least 6 characters in length.")]
        [InlineData("111111", "bbbbbb", "cc", "Confirm password must be at least 6 characters in length.")]
        [InlineData("111111", "bbbbbb", "cccccc", "Confirm password value is different from new password")]
        [InlineData("123", "bbbbbb", "bbbbbb", "The current password is invalid.")]          
        public void PwdVerifyInput(string currentPwd, string newPwd, string confirmNewPwd, string msg)
        {
            //_driverManager.NavigateTo(PageAlias.Launchpad_Password);         
            var passwordSettingsPage = GatekeeperFactory.CreatePageManager<PasswordPage>(_driverManager.Driver);
            passwordSettingsPage.SetPassword(currentPwd, newPwd, confirmNewPwd);
            
            var isExpected = passwordSettingsPage.IsErrorMsgExpected(msg);
            Assert.True(isExpected, "Message is incorrect");
        }

        [Theory(DisplayName = cst_DisplayName + ".SuccessChange")]
        [InlineData("111111", "111111", "111111", "Updated Successfully!")]
        public void SuccessPwdChange(string currentPwd, string newPwd, string confirmNewPwd, string msg)
        {
            //_driverManager.NavigateTo(PageAlias.Launchpad_Password);         
            var passwordSettingsPage = GatekeeperFactory.CreatePageManager<PasswordPage>(_driverManager.Driver);
            passwordSettingsPage.SetPassword(currentPwd, newPwd, confirmNewPwd);

            var isExpected = passwordSettingsPage.IsSuccessMsgExpected(msg);
            Assert.True(isExpected, "Message is incorrect");
        }

        [Theory(DisplayName = cst_DisplayName + ".ClosePage")]
        //[InlineData("111111", "111111", "111111", "Updated Successfully!")]
        public void ClosePwdPage()
        {
            var passwordSettingsPage = GatekeeperFactory.CreatePageManager<PasswordPage>(_driverManager.Driver);
            passwordSettingsPage.btnClose.Click();

            //need assert if returned to Launchpad_Home page

        }
    }
}