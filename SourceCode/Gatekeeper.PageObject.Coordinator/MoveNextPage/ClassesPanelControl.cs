using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class ClassesPanelControl: PageControlBase
    {
        public ClassesPanelControl (IWebDriver driver, string rootXpath): base(driver, rootXpath)
        {
            cst_classes = string.Format("{0}/selection-cell/div/label", rootXpath);
            cst_classesPanelTitle = string.Format("{0}/h3", rootXpath);

        }

        #region DOM elment Xpath
        protected readonly string cst_classes;
        protected readonly string cst_classesPanelTitle;
        #endregion


        #region DOM element objects

        protected List<ClassControl> _classes;
        public List<ClassControl> Classes
        {
            get
            {
                var items = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this._driver, By.XPath(cst_classes));
                _classes = new List<ClassControl>();
                for (var i=1; i <= items.Count; i++)
                {
                    _classes.Add(new ClassControl(this._driver, string.Format("({0})[{1}]", cst_classes, i)));
                }

                return _classes;
            } 
        }

        protected IWebElement _classesPanelTitle;
        public string Title
        {
            get
            {
                _classesPanelTitle = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_classesPanelTitle));
                return _classesPanelTitle.Text;
                   
            }
        }

        #endregion



        #region Actions

        #endregion

    }


}
