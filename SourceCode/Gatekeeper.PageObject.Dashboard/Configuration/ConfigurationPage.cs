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
        
        //[WaitingFindBy]
        protected IWebElement _title
        {
            get
            {
                IWebElement element = null;
                if (this.Driver != null)
                {
                    element = WebElementKeeper.WaitingFor_GetElementWhenExists(this.Driver, By.XPath(".//div[@class='ConfiguratorSection']/div[contains(@class,'widgets')]/fieldset/legend"));
                }
                return element;
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
        
        public List<ActiveWidgetControl> _activeWidgets;
        public List<ActiveWidgetControl> ActiveWidgets { get {
            if (this.Driver != null)
            {
                var xPathTemp = ".//div[@class='ConfiguratorSection']/div[contains(@class,'widgets')]/fieldset/div[contains(@class,'ConfiguratorList')]";
                var items = WebElementKeeper.WaitingFor_GetElementsWhenExists(this.Driver, By.XPath(xPathTemp));
                //var items = this.Driver.FindElements(By.XPath(".//div[@class='ConfiguratorSection']/div[contains(@class,'widgets')]/fieldset/div[contains(@class,'ConfiguratorList')]"));

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
        public void Action_EnabledAllActiveWidgets()
        {
            var widgets = this._activeWidgets;
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
