using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch
{
    public class PicklistSearch
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1 .rpText";

        private const string PageLoadingPanel = "#ctl00_LoadingPanelMenu";

        private const string ResultGridLoadingPanel =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_GridLoadingPanelctl00_ContentPlaceHolderContent_PickListSearchView1_orderGrid";

        private const string PicklistIdField =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1_i0_flbPicklistId_InputTemplateItem_CmbPicklistId_Input";

        private const string PicklistIdDropdownSlide =
            "#ctl00_ContentPlaceHolderContent_PickListSearchView1_RadPanelBar1_i0_flbPicklistId_InputTemplateItem_CmbPicklistId_DropDown .rcbList";

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
            const string picklistSearchPageUrl = "/pages/activity/pick/picklistsearch.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + picklistSearchPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public void RefreshWebPage()
        {
            FluentElement.Instance
                .RefreshWebPage();
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Pick list search");
        }

        public bool InsertPicklistId(string picklistId)
        {
            return FluentElement.Instance
                .WaitForElement(PicklistIdField)
                .SelectSearchDropDown(PicklistIdDropdownSlide, "li", picklistId);
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

            return FluentElement.Instance
                .WaitForElement(OrderStatusField)
                .SelectDropDown(dropdownValue);
        }

        public bool ClickSearchButton()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(SearchButton)
                .Click();
        }

        public bool SelectAllCheckBox()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(AllCheckBox)
                .Click();
        }

        public bool IsFirstPicklistResultBarDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitUntilInvisible(ResultGridLoadingPanel)
                .WaitForElement(FirstPicklistResultBar)
                .IsVisible();
        }

        public bool SelectActionMenuOption(string option)
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(ActionMenuGearIcon)
                .SelectDropDown(ActionMenuSlide,
                    "li", option);
        }

        public bool IsNoRecordsToShowLabelDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(ResultGridLoadingPanel)
                .IsVisible(NoRecordsToShowLabel);
        }

        public string GetPickOrderStatus()
        {
            return FluentElement.Instance
                .Wait(1)
                .WaitUntilInvisible(ResultGridLoadingPanel)
                .WaitForElement(FirstPicklistResultBar)
                .FindElements("td")
                .SearchElementByIndex(20)
                .GetText();
        }

        public string GetPickOrderRequestTime()
        {
            return FluentElement.Instance
                .Wait(1)
                .WaitUntilInvisible(ResultGridLoadingPanel)
                .WaitForElement(FirstPicklistResultBar)
                .FindElements("td")
                .SearchElementByIndex(13)
                .GetText();
        }

        private PicklistSearch() { }

        private static readonly Lazy<PicklistSearch>
            Singleton = new Lazy<PicklistSearch>(() => new PicklistSearch());
    }
}
