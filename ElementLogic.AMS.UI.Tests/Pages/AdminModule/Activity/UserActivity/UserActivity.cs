using System;
using System.Collections.Generic;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Integration;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.UserActivity
{
    public class UserActivity
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1 .rpText";

        private const string PageLoadingPanel = "#ctl00_LoadingPanelMenu";

        private const string ResultGridLoadingPanel =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_GridLoadingPanelct100_ContentPlaceHolderContent_UserActivityView_userGrid";

        private const string TaskgroupIdField =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_flbTaskGroupId_InputTemplateItem_CmbTaskGroupId_Input";

        private const string TaskgroupIdDropdownSlide =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_flbTaskGroupId_InputTemplateItem_CmbTaskGroupId_DropDown .rcbList";

        private const string PicklistIdField =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_flbPicklistId_InputTemplateItem_CmbPicklistId_Input";

        private const string PicklistIdDropdownSlide =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_flbPicklistId_InputTemplateItem_CmbPicklistId_DropDown .rcbList";

        private const string StatusDropdown =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_flbStatus_InputTemplateItem_ddlStatus";

        private const string SearchButton =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_btnSearch";

        private const string FirstUserActivityResultBar =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00__0";

        private const string FirstUserActivityActionMenuGearIcon =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00_ctl04_ctl01";

        private const string FirstUserActivityActionMenuSlide =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00_ctl04_ctl01 .rmSlide";

        private const string FirstUserActivityMissionGrid =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00_ctl06_missionGrid tbody";

        private const string MissionActionMenuSlide = ".rmSlide";

        public static UserActivity Instance => Singleton.Value;

        public void Navigate()
        {
            const string picklistSearchPageUrl = "/pages/activity/useractivity/useractivitysearch.aspx";
            var baseUrl = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + picklistSearchPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("User activity search");
        }

        public bool InsertTaskgroupId(string taskgroupId)
        {
            return FluentElement.Instance
                .WaitForElement(TaskgroupIdField)
                .SelectSearchDropDown(TaskgroupIdDropdownSlide, "li", taskgroupId);
        }

        public bool InsertPicklistId(string picklistId)
        {
            return FluentElement.Instance
                .WaitForElement(PicklistIdField)
                .SelectSearchDropDown(PicklistIdDropdownSlide, "li", picklistId);
        }

        public bool SelectStatus(string statusToBeSelected)
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(StatusDropdown)
                .SelectDropDown(statusToBeSelected);
        }

        public bool ClickSearchButton()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(SearchButton)
                .Click();
        }

        public bool IsFirstUserActivityResultBarDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(FirstUserActivityResultBar)
                .IsVisible();
        }

        public bool SelectActivityActionMenuOption(string option)
        {
            return FluentElement.Instance
                .WaitForElement(FirstUserActivityActionMenuGearIcon)
                .SelectDropDown(FirstUserActivityActionMenuSlide,
                    "li > a > span", option);
        }

        public string GetFirstActivityUserCode()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(FirstUserActivityResultBar)
                .FindElements("td")
                .SearchElementByIndex(5)
                .GetText();
        }

        public string SelectActivityMissionActionMenuOptionAndGetMissionId(string missionStatus, string option)
        {
            PageObjectHelper.Instance.WaitUntilInvisible(ResultGridLoadingPanel);

            var missions = PageObjectHelper.Instance.Finds("tr", 
                FirstUserActivityMissionGrid);

            return (from mission in missions
                select PageObjectHelper.Instance.Finds("td", mission)
                into missionDetails
                where missionDetails[10].Text.Contains(missionStatus)
                select PageObjectHelper.Instance
                    .SelectIWebElementDropDown(missionDetails[12], MissionActionMenuSlide, 
                    "li > a > span", option)
                    ? missionDetails[11].Text
                    : null).FirstOrDefault();
        }

        public IList<UserActivityMissionData> GetActivityMissionData()
        {
            PageObjectHelper.Instance
                .WaitUntilInvisible(PageLoadingPanel);
            PageObjectHelper.Instance
                .WaitUntilInvisible(ResultGridLoadingPanel);
            var missions = PageObjectHelper.Instance
                .Finds("tr", FirstUserActivityMissionGrid);

            return missions.Select(mission => PageObjectHelper.Instance
                .Finds("td", mission)).Select(missionDetails =>
                new UserActivityMissionData
                {
                    Id = missionDetails[11].Text, 
                    Status = missionDetails[10].Text
                }).ToList();
        }

        private UserActivity() { }

        private static readonly Lazy<UserActivity>
            Singleton = new Lazy<UserActivity>(() => new UserActivity());
    }
}
