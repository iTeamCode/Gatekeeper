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
    public class DashboardSignInPage : PageObjectBase
    {

        public DashboardSignInPage(IWebDriver driver)
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
        public IWebElement btnSignIn;
        #endregion Page elements

        #region Action for test case
        public void SignIn(string userName, string password, string churchCode)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
            this.txtChurchCode.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);
            this.txtChurchCode.SendKeys(churchCode);

            this.btnSignIn.Click();
        }
        #endregion

    }
}
