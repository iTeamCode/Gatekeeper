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
    public class PeopleControl: PageControlBase
    {
        public PeopleControl (IWebDriver driver, string rootXPath): base (driver, rootXPath)
        {
            cst_checkBoxInput = string.Format("{0}/div/label/input", rootXPath);
            cst_checkBox = string.Format("{0}/div/label/span[contains(@class, 'checkbox-default')]", rootXPath);
            cst_peopleName = string.Format("{0}/div/label/span[contains(@class, 'name')]", rootXPath);
            cst_peoplePhoto = string.Format("{0}/div/label/img", rootXPath);
        }
        #region Dom Element XPath
        protected readonly string cst_checkBox;
        protected readonly string cst_checkBoxInput;
        protected readonly string cst_peopleName;
        protected readonly string cst_peoplePhoto;
        #endregion


        #region Dom Element object
        protected IWebElement _peopleName;
        public string Name
        {
            get
            {
                _peopleName = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_peopleName));
                if (_peopleName == null)
                {
                    throw new Exception(string.Format("People name with xpath '{0}' does not exist", cst_peopleName));
                }

                return _peopleName.Text;
            }
        }


        protected IWebElement _checkBoxInput;
        protected IWebElement _checkBox;
        public bool CheckBox
        {
            get
            {
                _checkBoxInput = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_checkBoxInput));
                return _checkBoxInput.Selected;
            }

            set
            {
                _checkBox = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_checkBox));
                if (_checkBoxInput.Selected != value)
                {
                    _checkBox.Click();
                }
            }
        }


        protected IWebElement _peoplePhoto;
        public string PhotoURL
        {
            get
            {
                _peoplePhoto = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_peoplePhoto));
                return _peoplePhoto.GetAttribute("src");
            }
        }
       
        #endregion

        #region Actions
        #endregion

    }
}
