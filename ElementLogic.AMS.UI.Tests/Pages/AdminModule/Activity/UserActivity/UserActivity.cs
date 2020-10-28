﻿using System;
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

        private const string SearchButton =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_RadPanelBar1_i0_btnSearch";

        private const string FirstUserActivityResultBar =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00__0";

        private const string FirstUserActivityMissionGrid =
            "#ctl00_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00_ctl06_missionGrid tbody";

        private const string MissionActionMenuSlide = ".rmSlide";

        private const string FirstUserActivityActionMenuGearIcon =
            "#ctl00_ctl00_ContentPlaceHolderContent_ContentPlaceHolderContent_UserActivityView_userGrid_ctl00_ctl04_ctl01";

        public static UserActivity Instance => Singleton.Value;

        public void Navigate()
        {
            const string picklistSearchPageUrl = "/pages/activity/useractivity/useractivitysearch.aspx";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, picklistSearchPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool InsertTaskgroupId(string picklistId)
        {
            return PageObjectHelper.Instance.SelectSearchDropDown(TaskgroupIdField, TaskgroupIdDropdownSlide, "li",
                picklistId);
        }

        public bool ClickSearchButton()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(PageLoadingPanel);
            return PageObjectHelper.Instance.Click(SearchButton);
        }

        public bool IsFirstUserActivityResultBarDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(PageLoadingPanel);
            PageObjectHelper.Instance.WaitUntilInvisible(ResultGridLoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(FirstUserActivityResultBar, true);
        }

        public bool SelectActivityActionMenuOption(string option)
        {
            PageObjectHelper.Instance.WaitUntilInvisible(PageLoadingPanel);
            return PageObjectHelper.Instance.SelectDropDown(FirstUserActivityActionMenuGearIcon,
                MissionActionMenuSlide, "li", option);
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
                select PageObjectHelper.Instance.SelectIWebElementDropDown(missionDetails[12], MissionActionMenuSlide, "li > a > span", option)
                    ? missionDetails[11].Text
                    : null).FirstOrDefault();
        }

        public IList<UserActivityMissionData> GetActivityMissionData()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(PageLoadingPanel);
            PageObjectHelper.Instance.WaitUntilInvisible(ResultGridLoadingPanel);
            var missions = PageObjectHelper.Instance.Finds("tr", FirstUserActivityMissionGrid);

            return missions.Select(mission => PageObjectHelper.Instance.Finds("td", mission)).Select(missionDetails =>
                new UserActivityMissionData {Id = missionDetails[11].Text, Status = missionDetails[10].Text}).ToList();
        }

    private UserActivity() { }

        private static readonly Lazy<UserActivity>
            Singleton = new Lazy<UserActivity>(() => new UserActivity());
    }
}