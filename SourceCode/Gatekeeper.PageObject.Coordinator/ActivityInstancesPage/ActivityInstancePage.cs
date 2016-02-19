using Gatekeeper.Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.PageObject.Coordinator
{
    public class CoordinatorActivityInstancePage: PageObjectBase

    {
        public CoordinatorActivityInstancePage (IWebDriver driver): base (driver) 
        {
            WebElementKeeper.WaitingFor_ElementExists(this.Driver, By.XPath(".//button[text()='Start']"));
        }

    
        #region Page Elements XPath
       // protected const string cst_Header = ".//header/h1[contains(@class, 'church-name')]";
        protected const string cst_Header = ".//header";
        protected const string cst_Instances = ".//div/main/form/div[contains(@class, 'activity-instance')]";
        protected const string cst_Start = ".//button[text()='Start']";

        #endregion Page Elements XPath


        #region Page Elements object
        protected HeaderBarControl _header;
        public HeaderBarControl Header
        {
            get 
            {                
                _header = new HeaderBarControl (this.Driver, cst_Header);
                return _header;
            }
        }
        
        protected List<InstancesControl> _activityInstances;
        public List<InstancesControl> ActivityInstances
        {
            get
            {
                var items = WebElementKeeper.WaitingFor_GetElementsWhenIsVisible(this.Driver, By.XPath(cst_Instances));
                _activityInstances = new List<InstancesControl>();

                for (var i = 1; i <= items.Count; i++)
                {
                    _activityInstances.Add(new InstancesControl(this.Driver, string.Format("({0})[{1}]", cst_Instances, i)));
                }
                return _activityInstances;
            }
        }

        [FindsBy(How = How.XPath, Using = cst_Start)]
        protected IWebElement btnStart;
                
        #endregion Page Elements object

        #region Actions

        public void StartWithInstanceSelected(int i)
        {
            if (this.ActivityInstances[i] == null)
            {
                throw new Exception(string.Format("ActivityInstances[{0}] does not exist", i));
            }

            this.ActivityInstances[i].SelectInstance();

            this.btnStart.Click();

        }

        public void StartWithoutInstancesSelected ()
        {
            //if(!this.Check_AreAllInstancesUnselected())
            //{
            //    throw new Exception("There is one activity instance selected already!");
            //}

            this.btnStart.Click();
        }

        #endregion Actions

        #region Check Points
        public bool Check_AreAllInstancesUnselected()
        {
            bool isUnSelected = true;
            for (int i = 1; i <= this.ActivityInstances.Count; i++ )
            {
                if (this.ActivityInstances[i].Radio==true)
                {
                    isUnSelected = false;
                    break;
                }
            }

                return isUnSelected;
        }
        #endregion Check Points

    }
}
