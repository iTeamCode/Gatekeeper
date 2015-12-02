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
    public class MoveHomePage : PageObjectBase
    {
        public MoveHomePage(IWebDriver driver)
            : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(".//classroom-list/ul/li/ul/li[text()='Roster Grouping']"));
        }

        #region Dom Elements Xpath
        protected const string cst_MoveHeader = ".//header/h1[contains(@class, 'church-name')]";
        protected const string cst_Roster = ".//classroom-list/ul//li[text()='Roster Grouping']/following-sibling::li/ul/li";
        protected const string cst_RosterDetail = ".//classroom/section[contains(@class,'classroom')]";
        //protected const string cst_Volunteer = ".//classroom/section[contains(@class,'classroom')]/div/div/h2[text()='Volunteers']/following-sibling::div/participant";
        //protected const string cst_Participant = ".//classroom/section[contains(@class,'classroom')]/div/div/h2[text()='Participants']/following-sibling::div/participant";
        protected const string cst_Toggle = ".//input[@id='open']/following-sibling::div[contains(@class, 'toggle')]";
        //protected const string cst_ToggleInput = ".//input[@id='open']";
                
        protected const string cst_Next = ".//classroom/section[contains(@class,'classroom')]/button[text()='Next']";
        #endregion

        #region Dom Elements Id
        protected const string cst_ToggleInput = "open";
        #endregion

        #region Dom Elements object
        protected HeaderBarControl _header;
        public HeaderBarControl Header
        {
            get
            {
                _header = new HeaderBarControl(this.Driver, cst_MoveHeader);
                return _header;
            }
        }


        //public RosterDetailControl RosterDetail
        //{

        //}

        //public RosterPanelControl RosterPanel
        //{

        //}


        [FindsBy(How = How.XPath, Using = cst_Toggle)]
        protected IWebElement toggle;

        [FindsBy(How = How.Id, Using = cst_ToggleInput)]
        protected IWebElement toggleInput;

        public bool Toggle
        {
            get
            {
                var element = WebElementKeeper.WaitingFor_GetElementWhenExists(this.Driver, By.Id(cst_ToggleInput));
               
                if (element == null)
                {
                    throw new Exception(string.Format("Xpath '{0}' does not exist!", cst_ToggleInput));
                }

                return element.Selected;
            }

            set
            {
                if (this.toggleInput.Selected!= value)
                {
                    this.toggle.Click();
                }
            }
        }


        [FindsBy(How = How.XPath, Using = cst_Next)]
        protected IWebElement btnNext;
                     
        
        #endregion

        #region Actions
        public void SelectRoster ()
        {
           
        }

        //public void ChangeRosterStatus ()
        //{
        //    var element = WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(cst_Toggle));
        //    if (element == null)
        //    {
        //        throw new Exception(string.Format("Element with XPath '{0}' does not exit", cst_Toggle));
        //    }

        //    this.toggle.Click();
        //}


        public void Next()
        {
            var element = WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(cst_Next));
            if (element == null)
            {
                throw new Exception (string.Format("Next button is not available"));
            }
            this.btnNext.Click();

        }        

        #endregion


        #region Check Points
        #endregion

    }


}
