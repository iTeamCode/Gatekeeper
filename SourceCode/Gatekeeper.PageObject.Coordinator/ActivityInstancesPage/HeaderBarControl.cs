﻿using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class HeaderBarControl: PageControlBase
    {
        public HeaderBarControl (IWebDriver driver, string rootXpath): base (driver, rootXpath)
        {
            cst_HeaderText = string.Format("{0}/h1[contains(@class, 'church-name')]", rootXpath);
        }
        # region Dom Elements XPath

        protected readonly string cst_HeaderText;

        #endregion Dom Elements XPath

        # region Dom Elements Object

        //[FindsBy(How = How.XPath, Using = ".//header/h1[contains(@class, 'church-name')]"]
        //protected IWebElement _txtHeader;

        public string ChurchName
        {
            get
            {
                var churchName = string.Empty;
                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_HeaderText));
                if (element != null)
                {
                    var arry = element.Text.Split('|');
                    churchName = arry[0];
                }
                return churchName.TrimEnd();
            }
        }

        public string ActivityName
        {
            get
            {
                var activityName = string.Empty;
                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_HeaderText));
                if (element!=null)
                {
                    var arry = element.Text.Split('|');
                    activityName = arry[1];
                }

                return activityName.TrimStart();
            }
        }

        public string HeaderText
        {
            get
            {
                var headerText = string.Empty;
                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_HeaderText));
                    if (element != null)
                    {
                       headerText = element.Text;
                    }

                return headerText;
            }
        }



        # endregion Dom Elements Object
    }
}
