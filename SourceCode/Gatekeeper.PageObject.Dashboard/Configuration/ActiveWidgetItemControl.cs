using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    /// <summary>
    /// Active widget item control.
    /// </summary>
    public class ActiveWidgetItemControl
    {
        public ActiveWidgetItemControl(IWebElement rootElement)
        {
            InitControl(rootElement);
        }
        public void InitControl(IWebElement rootElement)
        {
            this._rootElement = rootElement;
        }

        /// <summary>
        /// get 'ActiveWidgetItemControl' selected .
        /// </summary>
        public bool Selected { get { return _checkbox.Selected; } }
        /// <summary>
        /// get 'ActiveWidgetItemControl' Text .
        /// </summary>
        public string Text { get { return _text.Text; } }


        #region Web Element
        protected IWebElement _rootElement;
        protected IWebElement _checkbox
        {
            get
            {
                IWebElement element = null;
                if (_rootElement != null)
                {
                    element = _rootElement.FindElement(By.XPath("./input[@type='checkbox']"));
                }
                return element;
            }
        }
        protected IWebElement _text
        {
            get
            {
                IWebElement element = null;
                if (_rootElement != null)
                {
                    element = _rootElement.FindElement(By.XPath("./label"));
                }
                return element;
            }
        }
        #endregion
    }
}
