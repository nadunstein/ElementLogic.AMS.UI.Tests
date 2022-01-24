using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory
{
    public class InventoryOrderList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_RadPanelBar1 .rpText";

        private const string PageLoadingPanel = "#ctl00_LoadingPanelMenu";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_rtbGridTopBar > div > div > div > ul > li:nth-child(1) > a > span > span > span > span";

        private const string SearchButton =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_RadPanelBar1_i0_btnSearch";

        private const string AllCheckBox =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00_ctl02_ctl01_headerChkbox";

        private const string FirstInventoryResultBar =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00__0";

        private const string FirstInventoryTaskgroupTable =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00_ctl06_TaskgroupGrid_ctl00 tbody";

        private const string ActionMenuGearIcon =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00_ctl04_ctl01";

        private const string ActionMenuSlide =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00_ctl04_ctl01 > ul > li > div";

        public static InventoryOrderList Instance => Singleton.Value;

        public void Navigate()
        {
            const string generateInventoryDetailsPageUrl = "/Pages/Activity/Inventory/InventoryOrderList.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + generateInventoryDetailsPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Inventory order list");
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool ClickSearchButton()
        {
            return FluentElement.Instance
                .WaitForElement(SearchButton)
                .Click();
        }

        public bool IsFirstInventoryResultBarDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(FirstInventoryResultBar)
                .IsVisible();
        }

        public int GetFirstInventoryTaskgroupCount()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(PageLoadingPanel)
                .WaitForElement(FirstInventoryTaskgroupTable)
                .GetTableElements()
                .GetRowCount();
        }

        public bool SelectAllCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(AllCheckBox)
                .Click();
        }

        public bool SelectActionMenuOption(string option)
        {
            return FluentElement.Instance
                .WaitForElement(ActionMenuGearIcon)
                .SelectDropDown( ActionMenuSlide,
                "li", option);
        }

        private InventoryOrderList() { }

        private static readonly Lazy<InventoryOrderList> Singleton =
            new Lazy<InventoryOrderList>(() => new InventoryOrderList());
    }
}
