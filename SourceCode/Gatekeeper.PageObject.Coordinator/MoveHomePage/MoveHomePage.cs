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
    public class MoveHomePage : PageObjectBase
    {
        public MoveHomePage(IWebDriver driver)
            : base(driver)
        {
            WebElementKeeper.WaitingFor_ElementIsVisible(this.Driver, By.XPath(".//classroom-list/ul/li/ul/li[text()='Roster Grouping']"));
        }

        #region Dom Elements Xpath
        protected const string cst_Header = ".//header";
        protected const string cst_RosterPanel = ".//classroom-list/ul/li/ul";
        protected const string cst_RosterDetail = ".//classroom/section[contains(@class,'classroom')]";             
        protected const string cst_Next = ".//classroom/section[contains(@class,'classroom')]/button[text()='Next']";
        #endregion


        #region Dom Elements object
        protected HeaderBarControl _header;
        public HeaderBarControl Header
        {
            get
            {
                _header = new HeaderBarControl(this.Driver, cst_Header);
                return _header;
            }
        }

        protected RosterPanelControl _rosterPanel;
        public RosterPanelControl RosterPanel
        {
            get
            {
                _rosterPanel = new RosterPanelControl(this.Driver, cst_RosterPanel);
                return _rosterPanel;
            }
        }

        protected RosterDetailControl _rosterDetails;
        public RosterDetailControl RosterDetails
        {
            get
            {
                _rosterDetails = new RosterDetailControl(this.Driver, cst_RosterDetail);
                return _rosterDetails;
            }
        }
            
        protected IWebElement btnNext;
                     
        
        #endregion

        #region Actions
       

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
            this.btnNext = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this.Driver, By.XPath(cst_Next));
            if (this.btnNext== null)
            {
                throw new Exception(string.Format("Next button with xpath '{0}' is not available", cst_Next));
            }
            this.btnNext.Click();

        }        

        #endregion


        #region Check Points
        #endregion

    }


}
