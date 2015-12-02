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
    public class RosterControl : PageControlBase
    {
        public RosterControl (IWebDriver driver, string rootXPath): base(driver, rootXPath)
        {
            cst_RosterName = string.Format("{0}/button/div/strong[contains(@class, 'classroom-name')]", rootXPath);
            cst_RosterTime = string.Format("{0}/button/div/span[contains(@class, 'classroom-time')]", rootXPath);
            cst_RosterCapacity = string.Format("{0} /button//div[contains(@class, 'circle capacity')]", rootXPath);
            cst_RosterParticipantsCount = string.Format("{0}/button//div[contains(@class, 'circle participants')]", rootXPath);
            cst_RosterVolunteersCount = string.Format("{0}/button//div[contains(@class, 'circle volunteers')]", rootXPath);
                       
        }

        #region Dom Element Xpath
        protected readonly string cst_RosterName;
        protected readonly string cst_RosterTime;
        protected readonly string cst_RosterParticipantsCount;
        protected readonly string cst_RosterVolunteersCount;
        protected readonly string cst_RosterCapacity;
        #endregion

        #region Dom Element object

        //[FindsBy(How = How.XPath, Using = cst_RosterName)]

        protected IWebElement txtName;
        public string Name
        {
            get
            {
                txtName = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterName));
                if (txtName == null)
                {
                    throw new Exception (string.Format("XPath'{0}' does not exist", this.cst_RosterName));
                }
                return txtName.Text;
            }
        }

        protected IWebElement txtTime;
        public string Time
        {
            get
            {
                txtTime = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterTime));
                if (txtTime == null)
                {
                    throw new Exception(string.Format("XPath'{0}' does not exist", this.cst_RosterTime));
                }

                return txtTime.Text;
            }
        }

        protected IWebElement txtpartipantsCount;
        public string ParticipantsCount
        {
            get
            {
                txtpartipantsCount = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterParticipantsCount));
                if (txtpartipantsCount == null)
                {
                    throw new Exception(string.Format("XPath'{0}' does not exist", this.cst_RosterParticipantsCount));
                }

                return txtpartipantsCount.Text;
            }
        }

        protected IWebElement txtVolunteersCount;
        public string VolunteersCount
        {
            get
            {
                txtVolunteersCount = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterVolunteersCount));
                if (txtVolunteersCount == null)
                {
                    throw new Exception(string.Format("XPath'{0}' does not exist", this.cst_RosterVolunteersCount));
                }

                return txtVolunteersCount.Text;
            }
        }

        protected IWebElement txtCapacity;
        public string Capacity
        {
            get
            {
                txtCapacity = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterCapacity));
                if (txtCapacity == null)
                {
                    throw new Exception(string.Format("XPath'{0}' does not exist", this.cst_RosterCapacity));
                }
                return txtCapacity.Text;
            }
        }

        public string Color
        {
            get
            {
                txtCapacity = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterCapacity));
                if (txtCapacity == null)
                {
                    throw new Exception(string.Format("XPath'{0}' does not exist", this.cst_RosterCapacity));
                }
                return txtCapacity.GetCssValue("background-color");

            }

        }

        #endregion

    }
}
