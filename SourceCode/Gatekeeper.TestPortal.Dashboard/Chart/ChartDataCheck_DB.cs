using Gatekeeper.DomainModel.Common;
using Gatekeeper.DomainModel.Dashboard;
using Gatekeeper.Framework.Common;
using Gatekeeper.PageObject.Dashboard;
using Gatekeeper.Toolbox.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Gatekeeper.TestPortal.Dashboard.Chart
{
    [Trait("Dashboard", "ChartDataCheckForDB")]
    public partial class ChartDataCheck : IClassFixture<InitialConfigurationFixture>
    {
        #region Init & check data
        private const string cst_DisplayName = "Chart.DataCheck.DB";

        private IDriverManager _driverManager;
        public CurrentUserModel _currentUser;
        public ChartDataCheck(InitialConfigurationFixture fixture)
        {
            this._driverManager = fixture.DriverManager;
            this._currentUser = fixture.CurrentUser;
            //check data here;
        }
        #endregion

        #region Test-Driver Data
        /// <summary>
        /// input data for "VerifiedTopBar"
        /// </summary>
        public static IEnumerable<object[]> VerifiedChartView_Data
        {
            get
            {
                return new[]
                {
                    //Giving
                    new object[]{0, "Giving", "$", ChartView.Quarter, null},
                    new object[]{0, "Giving", "$", ChartView.Month, null},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Sunday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Monday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Tuesday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Wednesday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Thursday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Friday},
                    new object[]{0, "Giving", "$", ChartView.Week, DayOfWeek.Saturday},
                    //Attendance
                    new object[]{2, "Attendance", "", ChartView.Quarter, null},
                    new object[]{2, "Attendance", "", ChartView.Month, null},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Sunday},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Monday},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Tuesday},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Wednesday},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Thursday},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Friday},
                    new object[]{2, "Attendance", "", ChartView.Week, DayOfWeek.Saturday},
                    //Attribute
                    new object[]{3, "", "", ChartView.Quarter, null},
                    new object[]{3, "", "", ChartView.Month, null},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Sunday},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Monday},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Tuesday},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Wednesday},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Thursday},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Friday},
                    new object[]{3, "", "", ChartView.Week, DayOfWeek.Saturday},
                };
            }
        }
        #endregion

        #region Test-Case
        [Theory(DisplayName = cst_DisplayName + ".ChartViewData_Year")]
        [InlineData(0, WidgetType.Giving, ChartView.Year, "Giving")]
        [InlineData(2, WidgetType.Attendance, ChartView.Year, "Attendance")]
        [InlineData(3, WidgetType.Attribute, ChartView.Year, "")]

        [InlineData(0, WidgetType.Giving, ChartView.Quarter, "Giving")]
        [InlineData(2, WidgetType.Attendance, ChartView.Quarter, "Attendance")]
        [InlineData(3, WidgetType.Attribute, ChartView.Quarter, "")]

        [InlineData(0, WidgetType.Giving, ChartView.Month, "Giving")]
        [InlineData(2, WidgetType.Attendance, ChartView.Month, "Attendance")]
        [InlineData(3, WidgetType.Attribute, ChartView.Month, "")]
        public void VerifiedChartViewData_Year(int index, WidgetType type, ChartView view, string title)
        {
            //#01. Get data from UI.
            _driverManager.NavigateTo(PageAlias.Dashboard_Home);
            var homePage = GatekeeperFactory.CreatePageManager<HomePage>(_driverManager.Driver);
            var toolBar = homePage.ToolBar;
            //toolBar.Action_SelectView(ChartView.Year);
            toolBar.Action_SelectView(view);

            homePage.ChartSections.ForEach(x => x.Expand = false);
            var chartSection = homePage.ChartSections[index];
            chartSection.Expand = true;
            if (!string.IsNullOrEmpty(title))
            {
                Assert.Equal(title, chartSection.DetailBar.Name);
            }
            var widgetItems = chartSection.MetricItems.Where(x => x.Selected);
            var widgetItemIds = new List<string>();
            foreach (var item in widgetItems)
            {
                widgetItemIds.Add(item.Id);
            }
            var chartView = chartSection.ChartView;

            //#02. Get data from DB.
            var dbDataDic = new Dictionary<string, List<ReportDataModel>>();
            switch (view)
            { 
                case ChartView.Year:
                    dbDataDic = GetDataFromDB_Year(widgetItemIds, type);
                    break;
                case ChartView.Quarter:
                    dbDataDic = GetDataFromDB_Quarter(widgetItemIds, type);
                    break;
                case ChartView.Month:
                    dbDataDic = GetDataFromDB_Month(widgetItemIds, type);
                    break;
                case ChartView.Week:
                    break;
            }
            
            //#03. Compare data.
            foreach (var dbData in dbDataDic)
            {
                var year = dbData.Key;
                foreach(var item in dbData.Value)
                {
                    Assert.Equal(item.Value, chartView[item.X_Axis, item.Year] ?? 0);
                }
            }
            //foreach (var dbData in dbDataList)
            //{
            //    Assert.Equal(dbData.Value, chartView[dbData.Key]);
            //}
        }

        private Dictionary<string, List<ReportDataModel>> GetDataFromDB_Year(List<string> widgetItemIds, WidgetType type)
        {
            
            var startYear = DateTime.Now.Year - 24;
            var endYear = DateTime.Now.Year;

            var churchId = _currentUser.ChurchId;
            var startDate = DateTime.Parse(string.Format("{0}-01-01", startYear));
            var endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            var originalData = GetDataList(widgetItemIds, type, churchId, startDate, endDate);

            var groupList = originalData.GroupBy(x => string.Format("{0}-Years", x.Date.Year))
                .OrderBy(g => g.Key).Select(g => new ReportDataModel
            {
                Key = g.Key.ToString(),
                Value = g.Sum(i => i.Value),
                Count = g.Sum(i => i.Count)
            }).ToList();

            var dbDataList = new List<ReportDataModel>(25);
            for (var iYear = startYear; iYear <= endYear; iYear++)
            {
                var tempData = new ReportDataModel { Key = string.Format("{0}-Years", iYear), Value = 0.00m, Count = 0 };
                var data = groupList.FirstOrDefault(x => x.Key == string.Format("{0}-Years", iYear));
                if (data != null)
                {
                    tempData.Value = data.Value;
                    tempData.Count = data.Count;
                }
                dbDataList.Add(tempData);
            }

            var dicData = new Dictionary<string, List<ReportDataModel>>();
            dicData.Add("Years", dbDataList);
            return dicData;
        }

        private Dictionary<string, List<ReportDataModel>> GetDataFromDB_Month(List<string> widgetItemIds, WidgetType type)
        {
            var startYear = DateTime.Now.Year - 1;
            var endYear = DateTime.Now.Year;

            var churchId = _currentUser.ChurchId;
            var startDate = DateTime.Parse(string.Format("{0}-01-01", startYear));
            var endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            var originalData = GetDataList(widgetItemIds, type, churchId, startDate, endDate);

            var groupList = originalData.GroupBy(x => string.Format("{0}-{1}", x.Date.ToString("MMM"), x.Date.Year))
                .OrderBy(g => g.Key).Select(g =>new ReportDataModel
            {
                Key = g.Key,
                Value = g.Sum(i => i.Value),
                Count = g.Sum(i => i.Count)
            }).ToList();

            var dicData = new Dictionary<string, List<ReportDataModel>>();
            var monthArray = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            for (var iYear = startYear; iYear <= endYear; iYear++)
            {
                var yearDataList = groupList.FindAll(x => x.Year == iYear.ToString());
                var dbDataList = new List<ReportDataModel>(12);
                foreach (var strMonth in monthArray)
                {
                    var tempData = new ReportDataModel { Key = string.Format("{0}-{1}", strMonth, iYear), Value = 0.00m, Count = 0 };
                    var data = yearDataList.FirstOrDefault(x => x.X_Axis == strMonth);
                    if (data != null)
                    {
                        tempData.Value = data.Value;
                        tempData.Count = data.Count;
                    }
                    dbDataList.Add(tempData);
                }
                dicData.Add(iYear.ToString(), dbDataList);
            }
            return dicData;
        }

        private Dictionary<string, List<ReportDataModel>> GetDataFromDB_Quarter(List<string> widgetItemIds, WidgetType type)
        {
            var startYear = DateTime.Now.Year - 1;
            var endYear = DateTime.Now.Year;

            var churchId = _currentUser.ChurchId;
            var startDate = DateTime.Parse(string.Format("{0}-01-01", startYear));
            var endDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            var originalData = GetDataList(widgetItemIds, type, churchId, startDate, endDate);

            var groupList = originalData.GroupBy(x => string.Format("Q{0}-{1}", ((x.Date.Month - 1) / 3 + 1), x.Date.Year))
                .OrderBy(g => g.Key).Select(g =>new ReportDataModel
            {
                Key = g.Key,
                Value = g.Sum(i => i.Value),
                Count = g.Sum(i => i.Count)
            }).ToList();

            var dicData = new Dictionary<string, List<ReportDataModel>>();
            var quarterArray = new string[] { "Q1", "Q2", "Q3", "Q4" };
            for (var iYear = startYear; iYear <= endYear; iYear++)
            {
                var yearDataList = groupList.FindAll(x => x.Year == iYear.ToString());
                var dbDataList = new List<ReportDataModel>(4);
                foreach (var strQuarter in quarterArray)
                {
                    var tempData = new ReportDataModel { Key = string.Format("{0}-{1}", strQuarter, iYear), Value = 0.00m, Count = 0 };
                    var data = yearDataList.FirstOrDefault(x => x.X_Axis == strQuarter);
                    if (data != null)
                    {
                        tempData.Value = data.Value;
                        tempData.Count = data.Count;
                    }
                    dbDataList.Add(tempData);
                }
                dicData.Add(iYear.ToString(), dbDataList);
            }
            return dicData;
        }

        private List<ReportDataModel> GetDataList(List<string> widgetItemIds, WidgetType type, int churchId, DateTime startDate, DateTime endDate)
        {
            var dvDashboard = DataVisitor.Create<IDashboardDataVisitor>();

            var dataList = new List<ReportDataModel>();
            switch (type)
            {
                case WidgetType.Giving:
                    var fdList = BuildWidgetItemIdList(widgetItemIds, "fd");
                    dataList = dvDashboard.FetchGivingData(churchId, startDate, endDate, fdList);
                    break;
                case WidgetType.Attendance:
                    var mnList = BuildWidgetItemIdList(widgetItemIds, "mn");
                    var gtList = BuildWidgetItemIdList(widgetItemIds, "gt");
                    dataList = dvDashboard.FetchAttendanceData(churchId, startDate, endDate, mnList, gtList);
                    break;
                case WidgetType.Attribute:
                    var atList = BuildWidgetItemIdList(widgetItemIds, "at");
                    dataList = dvDashboard.FetchAttributeData(churchId, startDate, endDate, atList);
                    break;
            }
            return dataList;
        }
        private List<int> BuildWidgetItemIdList(List<string> widgetItemIds, string prefix)
        {
            var dataList = new List<int>();
            foreach (var item in widgetItemIds)
            {
                var arry = item.Split('-');
                if (arry == null || arry.Length != 2) throw new Exception("Id format error!");
                if (arry[0] == prefix) dataList.Add(int.Parse(arry[1]));
            }
            //prefix
            return dataList;
        }
        #endregion Test-Case
    }
}
