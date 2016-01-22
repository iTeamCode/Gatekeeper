using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class ClassControl:PageControlBase
    {
        public ClassControl(IWebDriver driver, string rootXpath): base(driver, rootXpath)
        {
           // cst_checkBox = string.Format("{0}/span[contains(@class, 'checkbox-default radio-default-outer-ring')]", rootXpath);
            cst_checkBoxInput = string.Format("{0}/input[contains(@class, 'default')]", rootXpath);
            cst_className = string.Format("{0}/span[contains(@class, 'main-text ng-binding')]", rootXpath);
            cst_classCountsInfo = string.Format("{0}/span[contains(@class, 'sub-text ng-binding')]", rootXpath);
            cst_classColor = string.Format("{0}/div[contains(@class, 'child')]/ng-transclude/div[contains(@class, 'circle capacity ng-scope high')]", rootXpath);
        }

        # region Dom element Xpath
        //protected readonly string cst_checkBox;
        protected readonly string cst_checkBoxInput;
        protected readonly string cst_className;
        protected readonly string cst_classCountsInfo;
        protected readonly string cst_classColor;
        
        #endregion

        #region Dom element object
        protected IWebElement _checkBoxInput;
        public bool CheckBox
        {
            get
            {
                _checkBoxInput = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_checkBoxInput));
                return _checkBoxInput.Selected;
            
            }
        }

        protected IWebElement _className;
        public string Name
        {
            get
            {
                _className = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_className));
                return _className.Text;
            }
        }

        protected IWebElement _classCountsInfo;
        public string CountsInfo
        {
            get
            {
                _classCountsInfo = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_classCountsInfo));
                return _classCountsInfo.Text;
            }
        }

        protected IWebElement _classStatus;
        public string Color
        {
            get
            {
                _classStatus = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_classColor));
                return _classStatus.GetAttribute(Color);
            }
        }
      

        #endregion

    }
}
