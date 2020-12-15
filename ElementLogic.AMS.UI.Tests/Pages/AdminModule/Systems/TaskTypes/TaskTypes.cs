using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.TaskTypes
{
    public class TaskTypes
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_TasktypeListView_lblHeader";
        
        private const string ResultTable = ".rgMasterTable > tbody";
        
        private const string FirstSearchResultRow =
            "#ctl00_ContentPlaceHolderContent_TasktypeListView_radgridTasktype_ctl00__0";
        
        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_TasktypeListView_radgridTasktype_ctl00_ctl02_ctl00_rtbTopBar .rtbText";

        public static TaskTypes Instance => Singleton.Value;

        public void Navigate()
        {
            const string taskTypesPageUrl = "/Pages/System/ListTaskTypes.aspx";
            var baseUrl =
                JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + taskTypesPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Task types");
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(FirstSearchResultRow)
                .IsVisible();
        }

        public bool IsNewTaskTypeAdded(string taskType)
        {
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, taskType);
        }

        private TaskTypes() { }

        private static readonly Lazy<TaskTypes> Singleton = new Lazy<TaskTypes>(() => new TaskTypes());
    }
}
