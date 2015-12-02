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
    public class InstancesControl: PageControlBase
    {
        public InstancesControl(IWebDriver driver, string rootXpath) : base(driver, rootXpath) { }

        # region DOM elements Xpath
        // instance - schedule Name
        protected const string cst_Name = "{0}/span[contains(@class, 'instance-name')]";
        //Instance - schedule time
        protected const string cst_Time = "{0}/span[contains(@class, 'instance-time')]";
        // instance - instance radio (selected or not)
        protected const string cst_Radio = "{0}/span[contains(@class, 'instance-radio')]";
        // instance - instance radio input
        protected const string cst_RadioInput = "{0}/input[@type='radio']";

        #endregion DOM elements Xpath


        # region DOM elements object
        [FindsBy(How = How.XPath, Using = cst_Name)]
        protected IWebElement _txtName;

        [FindsBy(How = How.XPath, Using = cst_Time)]
        protected IWebElement _txtTime;

        [FindsBy(How = How.XPath, Using = cst_Radio)]
        protected IWebElement _btnSelected;

        [FindsBy(How = How.XPath, Using = cst_RadioInput)]
        protected IWebElement _txtRadioInput;

        public string Name
        {
            get
            {
                var instanceName = string.Empty;
                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_Name));
                if (element !=null)
                {
                    instanceName = element.Text;
                }

                return instanceName;

            }
        }

        public string Time
        {
            get
            {
                var instanceTime = string.Empty;
                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_Time));
                if (element != null)
                {
                    instanceTime = element.Text;

                }

                return instanceTime;
            }
        }

        public bool Radio
        {
            get
            {
                var element = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RadioInput));

                if (element == null)
                {
                    throw new Exception(string.Format("Xpath '{0}' does not exist!", cst_RadioInput));
                }

                return element.Selected;
            }

        }
        
    

        # endregion DOM elements object

        #region Actions
      
        public void SelectInstance ()
        {
            this._btnSelected.Click();
        }

        public bool Selected
        {
            get
            {
                return this._txtRadioInput.Selected;
            }
            //set
            //{
            //    if (value == true)
            //    {
            //        this._btnSelected.Click();
            //    }
            //}

        }
        #endregion Actions

    }

}
