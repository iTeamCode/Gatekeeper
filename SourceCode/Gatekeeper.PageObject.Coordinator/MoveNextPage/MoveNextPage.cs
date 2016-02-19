using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class MoveNextPage: PageObjectBase
    {

        public MoveNextPage(IWebDriver driver): base(driver)
        {

        }

        #region DOM Elements Xpath
        protected const string cst_Header = ".//header";
        protected const string cst_MPeoppleList = ".//pageslide[2]/move/section/div[1]/div/selection-cell/div[contains(@class, 'selectioncell selected')]/label";
        protected const string cst_MPeoplePanelTitle = ".//pageslide[2]/move/section/div[1]/div[contains(@class, 'col-xs-12 selectioncell-title')]/h3";
        protected const string cst_OpenClassesPanel =".//pageslide[2]/move/section/div[2]/div[ contains(@class, 'selectioncell')]";
        protected const string cst_ClosedClassesPanel = ".//pageslide[2]/move/section/div[3]/div[contains(@class, 'selectioncell')]";
        protected const string cst_Move=".//pageslide[2]/move/section/div[contains(@class, 'row footer-padding')]/button";
        #endregion

        #region DOM Elements Object
        protected HeaderBarControl _header;
        public HeaderBarControl Header
        {
            get
            {
                _header = new HeaderBarControl(this.Driver, cst_Header);
                return _header;
            }
        }

        public string MPeopleTitle
        {
            get
            {
                var _mPeoplePanelTitle = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this.Driver, By.XPath(cst_MPeoplePanelTitle));
                return _mPeoplePanelTitle.Text;
            }
        }

        protected List<MPeopleControl> _mPeople;
        public List<MPeopleControl> MPeople
        {
            get
            {
                var items = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this.Driver, By.XPath(cst_MPeoppleList));
               _mPeople = new List<MPeopleControl>();

               for (int i = 1; i <= items.Count; i++ )
               {
                   _mPeople.Add(new MPeopleControl(this.Driver, string.Format("({0})[{1}]", cst_MPeoppleList, i)));

               }
                   return _mPeople;
            }
        }

        protected ClassesPanelControl _openClassedPanel;
        public ClassesPanelControl OpenClassesPanel
        {
            get
            {
                _openClassedPanel = new ClassesPanelControl(this.Driver, cst_OpenClassesPanel);
                return _openClassedPanel;
            }
        }

        protected ClassesPanelControl _closedClassesPanel;
        public ClassesPanelControl ClosedClassesPanel
        {
            get
            {
                _closedClassesPanel = new ClassesPanelControl(this.Driver, cst_ClosedClassesPanel);
                return _closedClassesPanel;
            }
        }

        protected IWebElement _btnMove;
        
        #endregion


        #region Actions
        public void Move ()
        {
            this._btnMove = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this.Driver, By.XPath(cst_Move));
            if (this._btnMove == null)
            {
                throw new Exception(string.Format("Move button with xpath '{0}' is not available", cst_Move));
            }
            this._btnMove.Click();
        }


        #endregion

        #region Check Points

        public bool IsMoveVisible ()
        {
            bool isVisible = false;
            var isMPeopleExists = this.MPeople.Exists(x => x.CheckBox == true);
            var isOpenClassSelected = this.OpenClassesPanel.Classes.Exists(x => x.Radio == true);
            var isClosedClassSelected = this.ClosedClassesPanel.Classes.Exists(x => x.Radio == true);

            if ((isMPeopleExists && !isOpenClassSelected && isClosedClassSelected) || (isMPeopleExists && isOpenClassSelected && !isClosedClassSelected))
            {
                isVisible = true;
            }
            
            return isVisible;
        }

        #endregion


    }
}
