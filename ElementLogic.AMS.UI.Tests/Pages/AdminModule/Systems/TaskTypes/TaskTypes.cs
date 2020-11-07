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
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, taskTypesPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Task types");
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(FirstSearchResultRow, true);
        }

        public bool IsNewTaskTypeAdded(string taskType)
        {
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, taskType);
        }

        private TaskTypes() { }

        private static readonly Lazy<TaskTypes> Singleton = new Lazy<TaskTypes>(() => new TaskTypes());
    }
}
