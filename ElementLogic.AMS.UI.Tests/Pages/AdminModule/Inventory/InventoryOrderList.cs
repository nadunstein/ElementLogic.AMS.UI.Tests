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

        private const string ActionMenuGearIcon =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00_ctl04_ctl01";

        private const string ActionMenuSlide =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_resultGrid_ctl00_ctl04_ctl01 > ul > li > div";

        public static InventoryOrderList Instance => Singleton.Value;

        public void Navigate()
        {
            const string generateInventoryDetailsPageUrl = "/Pages/Activity/Inventory/InventoryOrderList.aspx";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, generateInventoryDetailsPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Inventory order list");
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool ClickSearchButton()
        {
            return PageObjectHelper.Instance.Click(SearchButton);
        }

        public bool IsFirstInventoryResultBarDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(PageLoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(FirstInventoryResultBar, true);
        }

        public bool SelectAllCheckBox()
        {
            return PageObjectHelper.Instance.Click(AllCheckBox);
        }

        public bool SelectActionMenuOption(string option)
        {
            return PageObjectHelper.Instance.SelectDropDown(ActionMenuGearIcon, ActionMenuSlide,
                "li", option);
        }

        private InventoryOrderList() { }

        private static readonly Lazy<InventoryOrderList> Singleton =
            new Lazy<InventoryOrderList>(() => new InventoryOrderList());
    }
}
