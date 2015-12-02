using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.Framework.Common;

namespace Gatekeeper.PageObject.Dashboard
{
    public class ChartViewControl : PageControlBase
    {
        protected override void ReloadControls()
        {
            base.ReloadControls();
            this._dicChartData = null;
            this._xAxis = null;
        }
        public ChartViewControl(IWebDriver driver, string rootXPath) : base(driver, rootXPath) {
            //DateRange root:(.//div[@ng-controller='DashboardController']/div[contains(@class,'Metric')])[i]/div[contains(@class,'Metric-detail')]
            cst_ChartViewData = string.Format("{0}/div[contains(@class,'Metric-chart')]", rootXPath);
        }
        #region Dom elements xpath
        protected readonly string cst_ChartViewData;
        protected const string cst_ProgressBar = ".//div[@role='progressbar']/parent::div";
        #endregion Dom elements xpath

        #region Chart Data
        private string _strXAxis;
        private List<string> _xAxis;
        private List<string> xAxis
        {
            get
            {

                var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_ChartViewData));
                var x = element.GetAttribute("x");
                if (_strXAxis != x)
                {
                    _xAxis = BuildData_XAxis(x);
                    _strXAxis = x;
                }
                
                return _xAxis;
            }
        }
        private Dictionary<string, List<decimal?>> _dicChartData;
        private Dictionary<string, List<decimal?>> dicChartData
        { 
            get{
                WebElementKeeper.WaitingFor_WebElementAttributeChangedTo(this._driver, By.XPath(cst_ProgressBar), "class", "ng-hide");
                if (_dicChartData == null)
                {
                    var element = WebElementKeeper.WaitingFor_GetElementWhenIsVisible(this._driver, By.XPath(cst_ChartViewData));
                    var columns = element.GetAttribute("columns");
                    _dicChartData = BuildData_DicChartData(columns);
                }
                return _dicChartData;
            }
        }

        private List<string> BuildData_XAxis(string strData)
        {
            var x_Axis = new List<string>(30);
            var array = JsonToList<string>(strData);
            x_Axis.AddRange(array);
            return x_Axis;
        }
        private Dictionary<string, List<decimal?>> BuildData_DicChartData(string strData)
        {
            var dicChartData = new Dictionary<string, List<decimal?>>();

            var yearArray = JsonToList<object>(strData);
            foreach (var yearDatas in yearArray)
            {
                var objDataList = yearDatas as object[];
                var dataList = new List<decimal?>(30);
                for (var i = 1; i < objDataList.Length; i++)
                {
                    decimal? value = null;
                    try
                    {
                        if (objDataList[i] != null)
                        {
                            value = Convert.ToDecimal(objDataList[i]);
                        }
                    }
                    catch { value = null; }
                    dataList.Add(value);
                }
                dicChartData.Add(objDataList[0].ToString(), dataList);
            }
           
            return dicChartData;
        }

        private List<T> JsonToList<T>(string jsonText)
        {
            List<T> list = new List<T>();

            DataContractJsonSerializer _Json = new DataContractJsonSerializer(list.GetType());
            byte[] _Using = System.Text.Encoding.UTF8.GetBytes(jsonText);
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream(_Using);
            _MemoryStream.Position = 0;

            return (List<T>)_Json.ReadObject(_MemoryStream);
        }
        #endregion Chart Data


        #region Chart Data
        /// <summary>
        /// Get chart data
        /// </summary>
        /// <param name="x_Axis">x-Axis name</param>
        /// <param name="year">year</param>
        /// <returns></returns>
        public decimal? this[string x_Axis, string year]
        {
            get
            {
                //check data.
                if (xAxis == null || xAxis.Count == 0)
                {
                    throw new Exception("x-Axis not exists!");
                }

                if (dicChartData == null || dicChartData.Count == 0)
                {
                    throw new Exception("ChartData not exists!");
                }

                var index = xAxis.IndexOf(x_Axis);
                if (index < 0)
                {
                    throw new Exception(string.Format("Can not find x-Axis is '{0}'!", x_Axis));
                }
                if (!dicChartData.Keys.Contains(year))
                {
                    throw new Exception(string.Format("Can not find year in current chart '{0}'!", year));
                }
                var value = dicChartData[year][index];
                return value;
            }
        }

        public decimal? this[string x_Axis]
        {
            get
            {
                return this[x_Axis, "Years"];
            }
        }

        public ChartPointModel GetEndData(int offset = 0)
        {
            var year  =DateTime.Now.Year;
            var currentYear = year.ToString();
            var lastYear = (year - 1).ToString();

            List<decimal?> dataList;
            if (dicChartData.Keys.Contains("Years"))
            {
                dataList = dicChartData["Years"];
                var tmpIndex = dataList.Count - 1 - offset;
                return new ChartPointModel
                {
                    PointData = dataList[tmpIndex].Value,
                    X_Axis = xAxis[tmpIndex],
                    Year = "Years"
                };
                //return dataList[dataList.Count - 1 - offset].Value;
            }

            if (!dicChartData.Keys.Contains(currentYear))
            {
                throw new Exception(string.Format("Can't find data for year '{0}'", currentYear));
            }

            dataList = dicChartData[currentYear];
            var index = dataList.FindIndex(x => !x.HasValue);
            index = index - 1;
            if (index < 0)
            {
                index = dataList.Count - offset - 1;
                if (index < 0)
                {
                    throw new NotSupportedException("offset too big!");
                }
                //return dataList[].Value;
            }
            else 
            {
                if (index - offset < 0)
                {
                    dataList = dicChartData[lastYear];
                    index = (index - offset) + dataList.Count;
                    //return dataList[index].Value;
                }
                else
                {
                    index = index - offset;
                    //return dataList[index - offset].Value;
                }
            }
            return new ChartPointModel
            {
                PointData = dataList[index].Value,
                X_Axis = xAxis[index],
                Year = currentYear
            };
            //return dataList[index].Value;
        }
        #endregion Chart Data
    }
}
