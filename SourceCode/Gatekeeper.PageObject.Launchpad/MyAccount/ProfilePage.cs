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
    public class ProfilePage : PageObjectBase
    {
        public ProfilePage(IWebDriver driver)
            : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(".//input[@placeholder='First name']"));
        }

        #region Dom elements xpath
        protected const string cst_Header = ".//*[@id='ProfileWrapper']/div[2]/div[2]/div[5]/div/div[1]";
        #endregion Dom elements xpath

        #region Page Elements
        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='First name']")]
        protected IWebElement txtFirstname;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Goes by']")]
        protected IWebElement txtGoseby;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Last name']")]
        protected IWebElement txtLastname;

        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Street1']")]
        protected IWebElement txtStreet1;
        
        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='Zipcode']")]
        protected IWebElement txtZipcode;
        
        [FindsBy(How = How.XPath, Using = ".//input[@placeholder='City']")]
        protected IWebElement txtCity;

        private string _errorMsgXPath = ".//div[contains(@class,'Error--left')]";
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'Error--left')]")]
        protected IWebElement txtErrorMsg;

        private string _SuccessMsgXPath = ".//div[contains(@class,'Success--left')]";
        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'Success--left')]")]
        protected IWebElement txtSuccessMsg;
        
        [FindsBy(How = How.XPath, Using = ".//button[text()='Save']")]
        protected IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = ".//button[text()='Close']")]
        public IWebElement btnClose;

        private string _msgSuccess = ".//span[text()='Updated Successfully!']";
        [FindsBy(How = How.XPath, Using = ".//span[text()='Updated Successfully!']")]
        protected IWebElement msgSuccess;

        private string _spinnerXPath = ".//div[@class='spinner']";
        [FindsBy(How = How.XPath, Using = ".//div[@class='spinner']")]
        protected IWebElement spinnerRose;
        #endregion Page Elements


        #region Actions on Profile setting page

        public void SetBaseProfile(string firstName, string lastName, string street1, string city, string zipcode)
        {
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.XPath(_spinnerXPath));  

            this.txtFirstname.Clear();
            this.txtLastname.Clear();
            this.txtStreet1.Clear();
            this.txtCity.Clear();
            this.txtZipcode.Clear();
            
            this.txtFirstname.SendKeys(firstName);
            this.txtLastname.SendKeys(lastName);
            this.txtStreet1.SendKeys(street1);
            this.txtCity.SendKeys(city);
            this.txtZipcode.SendKeys(zipcode);

            this.btnSave.Click();

            //Wait for refreshing
            WebElementKeeper.WaitingFor_InvisibilityOfElementLocated(this.Driver, By.XPath(_spinnerXPath));
        }

        public void SetBaseProfileSuccessfully(string firstName, string lastName, string street1, string city, string zipcode)
        {
            SetBaseProfile(firstName, lastName, street1, city, zipcode);            
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(_msgSuccess));
        }
        # endregion Actions on Profile setting page

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