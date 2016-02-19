using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class RosterDetailControl: PageControlBase
    {
        public RosterDetailControl (IWebDriver driver, string rootXPath): base (driver, rootXPath)
        {
            cst_Title = string.Format("{0}/div/h1[contains(@class,'hidden-xs')]", rootXPath);
            //cst_Toggle = string.Format(".//input[@id='open']/following-sibling::div[contains(@class, 'toggle')]", rootXPath);
            cst_Counts = string.Format("{0}/div[2]", rootXPath);
            cst_Participants = string.Format("{0}/div/div/h2[text()='Participants']/following-sibling::div/participant", rootXPath);
            cst_Volunteers = string.Format("{0}/div/div/h2[text()='Volunteers']/following-sibling::div/participant", rootXPath);
            
        }

        #region Dom Element XPath
        protected readonly string cst_Title;
        protected const string cst_Toggle = ".//input[@id='open']/following-sibling::div[contains(@class, 'toggle')]";
        protected readonly string cst_Counts;
        protected readonly string cst_Participants;
        protected readonly string cst_Volunteers;
        #endregion

        #region Dom Element id
        protected const string cst_ToggleInput = "open";
        #endregion



        #region Dom Element object

        protected IWebElement _txtTitle;
        public string Title
        {
            get
            {
                _txtTitle = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_Title));

                if (_txtTitle == null)
                {
                    throw new Exception(string.Format("Title with xpath '{0}' does not exist", cst_Title));
                }
                return _txtTitle.Text;
            }
        }

        protected IWebElement _toggle;
        protected IWebElement _toggleInput;
        public bool Toggle
        {
            get
            {
                _toggleInput = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.Id(cst_ToggleInput));
                return _toggleInput.Selected;
            }

            set
            {
                if (_toggleInput.Selected != value)
                {
                    _toggle = WebElementKeeper.WaitingFor_GetElementWhenExists(this._driver, By.XPath(cst_Toggle));
                    _toggle.Click();
                }
            }
        }

        protected List<PeopleControl> _participants;
        public List<PeopleControl> Participants
        {
          get
            {
                var items = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this._driver, By.XPath(cst_Participants));
                _participants = new List<PeopleControl>();

                for (var i = 1; i <= items.Count; i++)
                {
                    _participants.Add(new PeopleControl(this._driver, string.Format("({0})/[1]", cst_Participants, i)));
                }
                return _participants;              
            }
        }

        protected List<PeopleControl> _volunteers;
        public List<PeopleControl> Volunteers
        {
            get
            {
                var items = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this._driver, By.XPath(cst_Volunteers));
                _volunteers = new List<PeopleControl>();

                for (var i=1; i<=items.Count; i++)
                {
                    _volunteers.Add(new PeopleControl(this._driver, string.Format("({0})/[1]", cst_Volunteers, i)));
                }

                return _volunteers;
            }
        }


  
        #endregion

    }
}
