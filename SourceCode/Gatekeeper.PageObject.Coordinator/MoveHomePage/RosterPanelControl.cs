using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class RosterPanelControl: PageControlBase
    {
        public RosterPanelControl (IWebDriver driver, string rootXPath): base (driver, rootXPath)
        {
            cst_RosterPanelGroup = string.Format("{0}/li[text()='Roster Grouping']", rootXPath);
            cst_RosterPanelRosters = string.Format("{0}/li[text()='Roster Grouping']/following-sibling::li/ul/li", rootXPath);

        }

        #region Dom element XPath
        protected readonly string cst_RosterPanelGroup;
        protected readonly string cst_RosterPanelRosters;
        #endregion

        #region Dom element object
        protected IWebElement _txtRosterPanelTitle;
        public string Title
        {
            get
            {
                _txtRosterPanelTitle = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_RosterPanelGroup));

                if (_txtRosterPanelTitle == null)
                {
                    throw new Exception(string.Format("Xpath '{0}' does not exist", cst_RosterPanelGroup));
                }
                return _txtRosterPanelTitle.Text;
            }
        }

        protected List<RosterControl> _rosterPanelRosters;
        public List<RosterControl> Rosters
        {
            get
            {
                var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this._driver, By.XPath(cst_RosterPanelRosters));
                _rosterPanelRosters = new List<RosterControl>();

                if (items == null)
                {
                    throw new Exception(string.Format("No available rosters exist"));
                }

                for(var i = 1; i<=items.Count; i++)
                {
                    _rosterPanelRosters.Add(new RosterControl(this._driver, string.Format("({0})[{1}]", cst_RosterPanelRosters, i)));
                }

                return _rosterPanelRosters;
            }
        }
             
        #endregion

        #region Actions

        #endregion
    }
}
