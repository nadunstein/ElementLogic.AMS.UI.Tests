using System;
using ElementLogic.AMS.UI.Tests.Configuration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch
{
    public class PicklistSearch
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1 .rpText";

        private const string PageLoadingPanel = "#ctl00_LoadingPanelMenu";

        private const string ResultGridLoadingPanel =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_GridLoadingPanelct100_ContentPlaceHolderContent_PickListSearchView1_orderGrid";

        private const string PicklistIdField =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1_i0_flbPicklistId_InputTemplateItem_CmbPicklistId_Input";

        private const string OrderStatusField =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1_i0_flbOrderStatus_InputTemplateItem_ddlOrderStatus";

        private const string SearchButton =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1_i0_btnSearch";

        private const string AllCheckBox =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_orderGrid_ctl00_ctl02_ctl01_headerChkbox";

        private const string ActionMenuGearIcon =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_orderGrid_ctl00_ctl04_ctl01";

        private const string ActionMenuSlide =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_orderGrid_ctl00_ctl04_ctl01 > ul > li > div";

        private const string FirstPicklistResultBar =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_orderGrid_ctl00__0";

        private const string NoRecordsToShowLabel =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_orderGrid_ctl00_ctl04_NoRecordsLabel";

        public static PicklistSearch Instance => Singleton.Value;

        public void Navigate()
        {
            PageObjectHelper.Instance.DeleteBrowserCookies();
            const string picklistSearchPageUrl = "/pages/activity/pick/picklistsearch.aspx";
            string baseUrl = ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, picklistSearchPageUrl);
        }

        public void RefreshWebPage()
        { 
            PageObjectHelper.Instance.RefreshWebPage();
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool InsertPicklistId(string picklistId)
        {
            return PageObjectHelper.Instance.InsertField(PicklistIdField, picklistId);
        }

        public bool SelectOrderStatus(int orderStatus)
        {
            var dropdownValue = orderStatus switch
            {
                0 => "Created",
                1 => "Ready",
                2 => "Prepared",
                3 => "Assigned",
                4 => "Retrieved from location",
                5 => "PutInBox",
                6 => "Ready to retrieve from deviation",
                _ => null
            };

            return PageObjectHelper.Instance.SelectDropDown(OrderStatusField, dropdownValue);
        }

        public bool ClickSearchButton()
        {
            return PageObjectHelper.Instance.Click(SearchButton);
        }

        public bool SelectAllCheckBox()
        {
            return PageObjectHelper.Instance.Click(AllCheckBox);
        }

        public bool IsFirstPicklistResultBarDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(PageLoadingPanel);
            PageObjectHelper.Instance.WaitUntilInvisible(ResultGridLoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(FirstPicklistResultBar, true);
        }

        public bool SelectActionMenuOption(string option)
        {
            return PageObjectHelper.Instance.SelectDropDown(ActionMenuGearIcon, ActionMenuSlide,
                "li", option);
        }

        public bool IsNoRecordsToShowLabelDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(ResultGridLoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(NoRecordsToShowLabel);
        }

        public bool IsPickOrderStatusCorrect(string pickOrderStatus)
        {
            var tableColumns = PageObjectHelper.Instance.Finds("td", FirstPicklistResultBar);
            return tableColumns[19].Text.Contains(pickOrderStatus);
        }

        public string GetPickOrderRequestTime()
        {
            var tableColumns = PageObjectHelper.Instance.Finds("td", FirstPicklistResultBar);
            return tableColumns[12].Text;
        }

        private PicklistSearch() { }

        private static readonly Lazy<PicklistSearch>
            Singleton = new Lazy<PicklistSearch>(() => new PicklistSearch());
    }
}
