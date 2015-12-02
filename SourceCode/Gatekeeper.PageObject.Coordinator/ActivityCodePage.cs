using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class CoordinatorActivityCodePage: PageObjectBase
    {
        public CoordinatorActivityCodePage (IWebDriver driver): base (driver)
        {
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(".//h2[text()='Enter four digit activity code here']"));
        }

        #region Page Elements

        [FindsBy(How = How.XPath, Using = ".//h2[text()='Enter four digit activity code here']")]
        protected IWebElement txtPromptText;

        private string _headerChurchNameXPath = ".//header/h1[contains(@class, 'church-name')]";
        //[FindsBy(How = How.XPath, Using = ".//header/h1[contains(@class, 'church-name')]")]
        //protected IWebElement txtHeaderChurchName;
                
        public string HeaderChurchName
        {
            get
            {
                var churchName = string.Empty;

                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this.Driver, By.XPath(this._headerChurchNameXPath));
                if (element!= null)
                {
                    churchName = element.Text;
                }
                return churchName;                
            }
        }

        [FindsBy(How = How.XPath, Using = ".//input[@type='password']")]
        protected IWebElement txtActivityCode;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Done']")]
        protected IWebElement btnDone;

        private string _errorMsgXPath = ".//div[contains(@class,'error-message')]/p";
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'error-message')]/p")]
        protected IWebElement txtErrorMsg;
      
        //public string ErrorMsg
        //{
        //    get
        //    {
        //        var msg = string.Empty;
        //        var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this.Driver, By.XPath(this._errorMsgXPath));
        //        if (element != null)
        //        {
        //            msg = element.Text;
        //        }
        //        return msg;
        //    }
        //}

        
        
        #endregion Page Elements


        #region Actions on ActivityCode page

        public void AuthenticateActivityCode (string activityCode)
        {
            this.txtActivityCode.Clear();

            this.txtActivityCode.SendKeys(activityCode);
            this.btnDone.Click();

        }

        #endregion Actions on ActivityCode Page

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
                
        #endregion Check Points
    }
}
