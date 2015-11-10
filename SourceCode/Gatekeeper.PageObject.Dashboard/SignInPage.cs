using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class SignInPage : PageObjectBase
    {

        public SignInPage(IWebDriver driver)
            : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementExists(this.Driver, By.Id("username"));
        }
        #region Page elements
        [FindsBy(How = How.Id, Using = "username")]
        protected IWebElement txtUserName;

        [FindsBy(How = How.Id, Using = "password")]
        protected IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "church-code")]
        protected IWebElement txtChurchCode;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Sign in']")]
        protected IWebElement btnSignIn;


        private string _errorMsgXPath = ".//div[@ng-show='errorText']";
        [FindsBy(How = How.XPath, Using = ".//div[@ng-show='errorText']")]
        protected IWebElement txtErrorMsg;

        #endregion Page elements

        #region Action for test case
        /// <summary>
        /// Sign In for Dashboard
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="churchCode">Church code</param>
        public void Action_SignIn(string userName, string password, string churchCode)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
            this.txtChurchCode.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);
            this.txtChurchCode.SendKeys(churchCode);

            this.btnSignIn.Click();
        }

        public string ErrorMsg
        {
            get {
                var msg = string.Empty;

                var hasErrorMsg = WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
                if (!hasErrorMsg && !txtErrorMsg.Displayed) return msg;

                return txtErrorMsg.Text;
            }
        }
        #endregion

        #region Check Point
        /// <summary>
        /// Check error message is 'expectedErrorMsg'.
        /// </summary>
        /// <param name="expectedErrorMsg">expected error message.</param>
        /// <returns>is verify success</returns>
        public bool Check_ErrorMessage(string expectedErrorMsg)
        {
            var verifyErrorMsg = false;
            var hasErrorMsg = WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
            if (!hasErrorMsg && !txtErrorMsg.Displayed) return verifyErrorMsg;

            verifyErrorMsg = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedErrorMsg);
            return verifyErrorMsg;
        }
        #endregion
    }
}
