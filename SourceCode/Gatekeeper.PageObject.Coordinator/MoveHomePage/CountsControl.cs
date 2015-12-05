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
    public class CountsControl : PageControlBase
    {
        public CountsControl(IWebDriver driver, string rootXPath): base(driver, rootXPath)
        {
            cst_VolunteersCount = string.Format("{0}/div/div/div[contains(@class, 'circle volunteer-detail')]", rootXPath);
            cst_ParticipantsCount = string.Format("{0}/div/div/div[contains(@class, 'circle participant-detail')]", rootXPath);
            cst_Capacity = string.Format("{0} /div/div/div[contains(@class, 'circle capacity-detail')]", rootXPath);
            
        }

        #region Dom Element xpath
        protected readonly string cst_VolunteersCount;
        protected readonly string cst_ParticipantsCount;
        protected readonly string cst_Capacity;
        #endregion

        #region Dom Element id
        protected const string cst_Plus= "increase-capacity";
        protected const string cst_Minus = "decrease-capacity";
        #endregion

        #region Dom Element object
        protected IWebElement _volunteersCount;
        public string VolunteersCount
        {
            get
            {
                _volunteersCount = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_VolunteersCount));
                if (_volunteersCount == null)
                {
                    throw new Exception(string.Format("xpath '{0}' for volunteer count cannot be located", cst_VolunteersCount));
                }
                return _volunteersCount.Text;
            }
        }

        protected IWebElement _participantsCount;
        public string ParticipantsCount
        {
            get
            {
                _participantsCount = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_ParticipantsCount));
                if (_participantsCount==null)
                {
                    throw new Exception(string.Format("xpath '{0}' for participant count cannot be located", cst_ParticipantsCount));
                }
                return _participantsCount.Text;
            }
        }

        protected IWebElement _txtCapacity;
        public string Capacity
        {
            get
            {
                _txtCapacity = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_Capacity));
                if (_txtCapacity == null)
                {
                    throw new Exception(string.Format("xpath '{0}' for roster's capacity cannot be located", cst_Capacity));
                }
                return _txtCapacity.Text;
            }
        }

        [FindsBy(How = How.Id, Using = cst_Plus)]
        protected IWebElement _btnPlus;

        [FindsBy(How = How.Id, Using = cst_Minus)]
        protected IWebElement _btnMinus;

        #endregion


        #region Actions
        /// <summary>
        /// user can pass a num he wants to increase for the capacity
        /// </summary>
        /// <param name="num"></param>
        public void IncreaseCap (int num)
        {
            for (int i=1; i<= num; i++)
            {
                this._btnPlus.Click();
            }
        }

        /// <summary>
        /// user can pass a num he wants to decrease for the capacity
        /// </summary>
        /// <param name="num"></param>
        public void DecreaseCap (int num)
        {
            for (int i = 1; i <= num; i++)
            {
                this._btnMinus.Click();
            }
        }

        #endregion
    }
}
