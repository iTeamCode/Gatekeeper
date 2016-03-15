using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class MPeopleControl: PageControlBase
    {
        public MPeopleControl (IWebDriver driver, string rootXpath ): base (driver, rootXpath)
        {
            cst_checkBoxInput = string.Format("{0}/input", rootXpath);
            cst_peopleName = string.Format("{0}/span[contains(@class, 'main-text ng-binding centered')]", rootXpath);
            cst_checkBox = string.Format("{0}/span[contains(@class, 'checkbox-default radio-default-outer-ring')]", rootXpath);
        }

        # region Dom Element XPath
        protected readonly string cst_checkBox;
        protected readonly string cst_checkBoxInput;
        protected readonly string cst_peopleName;

        #endregion

        #region DOM Element object

        protected IWebElement _checkBox;
        protected IWebElement _checkBoxInput;
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
                if (_checkBoxInput.Selected!= value)
                    _checkBox.Click();
                
            }
        }

        protected IWebElement _peopleName;
        public string Name
        {
            get
            {
               _peopleName = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_peopleName));
               return _peopleName.Text;
            }
        }

        #endregion


    }
}
