using Gatekeeper.TestPortal.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ConfigurationPage : PageObjectBase
    {
        public ConfigurationPage(IWebDriver driver) : base(driver) { }
        #region Dom elements xpath
        //DateRange
        protected const string cst_ConfiguratorSection = ".//div[@class='ConfiguratorSection']/div[contains(@class,'widgets')]/fieldset";
        protected const string cst_BtnConfiguratorClose = ".//a[contains( @class,'ConfiguratorClose-icon')]";
        #endregion Dom elements xpath
        
        //[WaitingFindBy]
        protected IWebElement _title
        {
            get
            {
                IWebElement element = null;
                if (this.Driver != null)
                {
                    element = WebElementKeeper.WaitingFor_GetElementWhenExists(this.Driver, By.XPath(cst_ConfiguratorSection + "/legend"));
                }
                return element;
            }
        }
        protected IWebElement _btnConfiguratorClose;
        protected IWebElement btnConfiguratorClose
        {
            get
            {
                if (this.Driver != null && _btnConfiguratorClose == null)
                {
                    _btnConfiguratorClose = WebElementKeeper.WaitingFor_GetElementWhenExists(this.Driver, By.XPath(cst_BtnConfiguratorClose));
                }
                return _btnConfiguratorClose;
            }
        }
        #region Page elements

        public string TitleText
        {
            get
            {
                return (_title != null) ? _title.Text : string.Empty;
            }
        }
        
        protected List<ActiveWidgetControl> _activeWidgets;
        public List<ActiveWidgetControl> ActiveWidgets { get {
            if (this.Driver != null && _activeWidgets == null)
            {
                var xPathTemp = cst_ConfiguratorSection + "/div[contains(@class,'ConfiguratorList')]";
                var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this.Driver, By.XPath(xPathTemp));

                _activeWidgets = new List<ActiveWidgetControl>(50);
                for (var i = 1; i <= items.Count;i++ )
                {
                    _activeWidgets.Add(new ActiveWidgetControl(this.Driver, string.Format("({0})[{1}]", xPathTemp, i)));
                }
            }
            return _activeWidgets;
        } }
        #endregion

        #region Action for test case
        public void Action_UnableAllActiveWidgets()
        {
            var widgets = this.ActiveWidgets;
            foreach (var widget in widgets)
            {
                widget.Enabled = false;
            }
        }

        public void Action_CloseModalDialog()
        { 
            var dialog = GatekeeperFactory.CreateModalDialog<ModalDialogControl>(this.Driver, ".//div[@class='modal-dialog']");
            if (dialog != null)
            {
                dialog.Close();
            }
        }

        public void Action_SaveConfiguratorAndClosePage()
        {
            btnConfiguratorClose.Click();
        }
        #endregion

        public bool Check_ModalDialog()
        {
            var isPass = true;
            var dialog = GatekeeperFactory.CreateModalDialog<ModalDialogControl>(this.Driver, ".//div[@class='modal-dialog']");

            if (dialog != null)
            {
                if (dialog.TitleText != "Uh-oh! Further attention is needed here.") { isPass = false; }
                if (dialog.ContentText != "You have selected too many attributes. The maximum visible attributes is 6. Please deselect one to continue to add another.") { isPass = false; }
            }
            else
            {
                isPass = false;
            }
            return isPass;
        }
    }
}
