using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Launchpad
{
    public class PasswordPage : PageObjectBase
    {
        public PasswordPage(IWebDriver driver) : base(driver) 
        {
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(".//input[@placeholder='Current password']"));
        }

        #region Dom elements xpath
        protected const string cst_Header = ".//*[@id='ProfileWrapper']/div[2]/div[2]/div[5]/div/div[1]";
        #endregion Dom elements xpath


        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Current password']")]
        protected IWebElement txtCurrentPwd;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='New password']")]
        protected IWebElement txtNewPwd;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Confirm new password']")]
        protected IWebElement txtConfirmNewPwd;

        private string _errorMsgXPath = ".//div[contains(@class,'Error--left')]";
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'Error--left')]")]
        protected IWebElement txtErrorMsg;

        private string _SuccessMsgXPath = ".//div[contains(@class,'Success--left')]";
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'Success--left')]")]
        protected IWebElement txtSuccessMsg;

        #region Page Elements
        [FindsBy(How = How.XPath, Using =".//button[text()='Save']")] 
        protected IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Close']")]
        public IWebElement btnClose;

        #endregion Page Elements


        #region Actions on Password Settings Page

        public void SetPassword(string currentPwd, string newPwd, string confirmNewPwd)
        {
            this.txtCurrentPwd.Clear();
            this.txtNewPwd.Clear();
            this.txtConfirmNewPwd.Clear();

            this.txtCurrentPwd.SendKeys(currentPwd);
            this.txtNewPwd.SendKeys(newPwd);
            this.txtConfirmNewPwd.SendKeys(confirmNewPwd);

            this.btnSave.Click();
        }
        
        # endregion Actions on Password Settings Page

        #region Check Points

        public bool IsErrorMsgExpected(string expectedErrorMsg)
        {
            var isExpected = false;
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
           
            if (!txtErrorMsg.Displayed)
                return isExpected;

            isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedErrorMsg);
            return isExpected;
        }

        public bool IsSuccessMsgExpected(string expectedSuccessMsg)
        {
            var isExpected = false;
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_SuccessMsgXPath));

            if (!txtSuccessMsg.Displayed)
                return isExpected;

            isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedSuccessMsg);
            return isExpected;
        }   
        #endregion Check Points
    }

}