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
    public class InstancesControl: PageControlBase
    {
        public InstancesControl(IWebDriver driver, string rootXpath) : base(driver, rootXpath) 
        {
            cst_Name = string.Format("{0}/label/span[contains(@class, 'instance-name')]", rootXpath);
            cst_Time = string.Format("{0}/label/span[contains(@class, 'instance-time')]", rootXpath);
            cst_Radio = string.Format("{0}/label/span[contains(@class, 'instance-radio')]", rootXpath);
            cst_RadioInput = string.Format("{0}/label/input", rootXpath);
        }

        # region DOM elements Xpath
        // instance - schedule Name
        protected readonly string cst_Name;
        //Instance - schedule time
        protected readonly string cst_Time;
        // instance - instance radio (selected or not)
        protected readonly string cst_Radio;
        // instance - instance radio input
        protected readonly string cst_RadioInput;

        #endregion DOM elements Xpath


        # region DOM elements object
       

        //[FindsBy(How = How.XPath, Using = cst_Radio)]
        //protected IWebElement _btnSelected;

        //[FindsBy(How = How.XPath, Using = cst_RadioInput)]
        //protected IWebElement _txtRadioInput;

        protected IWebElement _txtName;
        public string Name
        {
            get
            {
                var instanceName = string.Empty;
                var _txtName = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_Name));
                if (_txtName != null)
                {
                    instanceName = _txtName.Text;
                }

                return instanceName;

            }
        }

        protected IWebElement _txtTime;
        public string Time
        {
            get
            {
                var instanceTime = string.Empty;
                var _txtTime = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_Time));
                if (_txtTime != null)
                {
                    instanceTime = _txtTime.Text;

                }

                return instanceTime;
            }
        }


        protected IWebElement _btnRadio;
        protected IWebElement _txtRadioInput;
        public bool Radio
        {
            get
            {
                _txtRadioInput = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RadioInput));

                if (_txtRadioInput == null)
                {
                    throw new Exception(string.Format("Xpath '{0}' does not exist!", cst_RadioInput));
                }

                return _txtRadioInput.Selected;
            }

        }
        
    

        # endregion DOM elements object

        #region Actions
      
        public void SelectInstance ()
        {
            _btnRadio = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_Radio));
            _btnRadio.Click();
        }

        //public bool Selected
        //{
        //    get
        //    {
        //        return this._txtRadioInput.Selected;
        //    }

        //}
        #endregion

    }

}
