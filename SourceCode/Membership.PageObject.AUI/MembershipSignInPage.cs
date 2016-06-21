using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.PageObject.AUI
{
    public class MembershipSignInPage : PageObjectBase
    {
        public MembershipSignInPage(IWebDriver driver) : base(driver) { }
        

        #region Page elements
        [FindsBy(How = How.Id, Using = "username")]
        protected IWebElement txtUserName;

        [FindsBy(How = How.Id, Using = "password")]
        protected IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = ".//button[@id='btn-login']")]
        protected IWebElement btnSignIn;


        //private string _errorMsgXPath = ".//div[@ng-show='errorText']";
        //[FindsBy(How = How.XPath, Using = ".//div[@ng-show='errorText']")]
        //protected IWebElement txtErrorMsg;

        #endregion Page elements

        #region Action for test case
        /// <summary>
        /// Sign In for Member AUI
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        public void Action_SignIn(string userName, string password)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);

            this.btnSignIn.Click();
        }
        #endregion Action for test case
    }
}
