using Gatekeeper.DomainModel.Common;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Launchpad;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Gatekeeper.TestPortal.Launchpad
{
    public class LoginUrlCheck
    {
        [Fact(DisplayName = "Url.ChurchCodeUndifined")]
        public void LoginUrl_NoChurchCode()
        {
            string msgNoChurchSignIn = "Login attempt has failed because your church is not identified in the URL. Please contact your church for further assistance.";
            string msgNoChurchSignUp = "Sign up cannot be launched because your church is not identified in the URL. Please contact your church for further assistance.";
            string msgNoChurchGetPassword = "Forgot Password cannot be launched because your church is not identified in the URL. Please contact your church for further assistance.";
          
            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Launchpad_SignIn_ChurchUndefined);            
                      
            var signInPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(manager.Driver);

            //Check Sign In message
            signInPage.Action_SignIn();

            var isExpected1 = signInPage.IsErrorMsgExpected(msgNoChurchSignIn);
            Assert.True(isExpected1, "Message for sign in without church code is incorrect!");

            //Check Sign Up message
            signInPage.Action_SignUp();

            var isExpected2 = signInPage.IsErrorMsgExpectedSignUp(msgNoChurchSignUp);
            Assert.True(isExpected2, "Message for sign up without church code is incorrect!");
            signInPage.Action_Cancel();          

            //Check forgot password page message 
            signInPage.Action_GetPassword();

            var isExpected3 = signInPage.IsErrorMsgExpectedPassword(msgNoChurchGetPassword);
            Assert.True(isExpected3, "Message for Forgot Password without church code is incorrect!");
            signInPage.Action_Cancel();
            
            manager.Driver.Close();
        }

        [Fact(DisplayName = "Url.NonExistedChurchCode")]
        public void LoginUrl_NonExistsChurchCode()
        {
            string msgWrongChurchSignIn = "Your login attempt has failed. Church is not found.";
            string msgWrongChurch = "Church Not Found, ChurchCode: unexistschurchcode";   

            var manager = GatekeeperFactory.CreateDriverManager();
            manager.NavigateTo(PageAlias.Launchpad_SignIn_WrongChurch);

            var signInPage = GatekeeperFactory.CreatePageManager<LaunchpadSignInPage>(manager.Driver);

            //Check Sign In message
            signInPage.Action_SignIn("t1@test.com", "111111");

            var isExpected1 = signInPage.IsErrorMsgExpected(msgWrongChurchSignIn);
            Assert.True(isExpected1, "Message for sign in with non-exists church code is incorrect!");

            //Check Sign Up message
            signInPage.linkSignUp.Click();
            signInPage.Action_SignUp("f1", "l1", "FL@test.com", "111111", "111111");

            var isExpected2 = signInPage.IsErrorMsgExpectedSignUp(msgWrongChurch);
            Assert.True(isExpected2, "Message for sign up with non-exists church code is incorrect!");
            signInPage.Action_Cancel();

            //Check forgot password page message 
            signInPage.linkForgotPassword.Click();
            signInPage.Action_PwdSendEmail("FL@test.com");

            var isExpected3 = signInPage.IsErrorMsgExpectedPassword(msgWrongChurch);
            Assert.True(isExpected3, "Message for Forgot Password with non-exists church code is incorrect!");
            signInPage.Action_Cancel();

            manager.Driver.Close();
        }

        //Non-standard Url will be redirected to https://launchpad.fellowshipone.com/#/login/ or https://launchpad.fellowshipone.com/#/login/dc
        [Fact(DisplayName = "Url.WrongUrl")]
        public void LoginUrl_WrongUrlRedirect()
        {
            var manager = GatekeeperFactory.CreateDriverManager();

            //Url1 is https://launchpad.fellowshipone.com
            manager.NavigateToUnstablePage(PageAlias.Launchpad_SignIn_WrongUrl1);
            Assert.True(manager.IsCurrentPage(PageAlias.Launchpad_SignIn_ChurchUndefined), "The redirected Url is wrong.");

            //manager.Driver.Close();

            //Url2 is https://launchpad.fellowshipone.com/dc
            manager.NavigateToUnstablePage(PageAlias.Launchpad_SignIn_WrongUrl2);
            Assert.True(manager.IsCurrentPage(PageAlias.Launchpad_SignIn), "The redirected Url is wrong.");

            //Url3 is https://launchpad.fellowshipone.com/#/dc
            manager.NavigateToUnstablePage(PageAlias.Launchpad_SignIn_WrongUrl3);
            Assert.True(manager.IsCurrentPage(PageAlias.Launchpad_SignIn), "The redirected Url is wrong.");
            manager.Driver.Close();
        }
    }
}