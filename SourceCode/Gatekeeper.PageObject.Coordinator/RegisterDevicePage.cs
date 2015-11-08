using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class CoordinatorRegisterDevicePage : PageObjectBase
    {
        public CoordinatorRegisterDevicePage(IWebDriver driver)
            : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementExists(this.Driver, By.XPath("*//div/main/form/*//input[@placeholder='Username']"));
        }

        # region Page Elements
        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Username']")]
        protected IWebElement txtUserName;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Password']")]
        protected IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Church Code']")]
        protected IWebElement txtChurchCode;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Authenticate Church']")]
        protected IWebElement btnAuthenticateChurch;

        private string _errorMsgXPath = ".//div[@class='message error-message ng-scope']/p";
        [FindsBy(How = How.XPath, Using = ".//div[@class='message error-message ng-scope']/p")]
        protected IWebElement txtErrorMsg;

        public string ErrorMsg
        {
            get
            {
                return txtErrorMsg.Text;
            }
        }

        public bool isVisibleErrorMsg
        {
            get
            {
                WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
                return txtErrorMsg.Displayed;
            }
        }
        
        # endregion Page Elements


        # region Actions on Register Device Page
        public void AuthenticateChurch (string userName, string password, string churchCode)
        {
            this.txtUserName.Clear();
            this.txtPassword.Clear();
            this.txtChurchCode.Clear();

            this.txtUserName.SendKeys(userName);
            this.txtPassword.SendKeys(password);
            this.txtChurchCode.SendKeys(churchCode);
            this.btnAuthenticateChurch.Click();
        }

        # endregion Actions on Register Device Page
    }
}
