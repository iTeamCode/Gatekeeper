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
    public class Homepage : PageObjectBase
    {
        public Homepage(IWebDriver driver) : base(driver) 
        {
            //WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(".//input[@placeholder='Current password']"));
        }

        #region Dom elements xpath
        protected const string cst_Header = ".//*[@id='ProfileWrapper']/div[2]/div[2]/div[5]/div/div[1]";
        #endregion Dom elements xpath

        #region Page Elements
        [FindsBy(How = How.XPath, Using = ".//i[contains(@class, 'fa-bars')]")]
        protected IWebElement btnSettings;

        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'second')]")]
        public IWebElement btnClose;

        #endregion Page Elements


        #region Actions

        public void SignOut()
        {
            this.btnSettings.Click();
            this.btnClose.Click();
            
        }        
        # endregion Actions on Password Settings Page

        #region Check Points

        //public bool IsErrorMsgExpected(string expectedErrorMsg)
        //{
        //    var isExpected = false;
        //    WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_errorMsgXPath));
           
        //    if (!txtErrorMsg.Displayed)
        //        return isExpected;

        //    isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedErrorMsg);
        //    return isExpected;
        //}

        //public bool IsSuccessMsgExpected(string expectedSuccessMsg)
        //{
        //    var isExpected = false;
        //    WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_SuccessMsgXPath));

        //    if (!txtSuccessMsg.Displayed)
        //        return isExpected;

        //    isExpected = WebElementKeeper.WaitingFor_TextToBePresentInElement(this.Driver, this.txtErrorMsg, expectedSuccessMsg);
        //    return isExpected;
        //}   
        #endregion Check Points
    }

}