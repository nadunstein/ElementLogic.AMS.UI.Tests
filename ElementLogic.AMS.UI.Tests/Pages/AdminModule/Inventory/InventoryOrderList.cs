using System;
using ElementLogic.AMS.UI.Tests.Configuration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory
{
    public class InventoryOrderList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_RadPanelBar1 .rpText";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_InventoryOrderListView1_rtbGridTopBar > div > div > div > ul > li:nth-child(1) > a > span > span > span > span";

        public static InventoryOrderList Instance => Singleton.Value;

        public void Navigate()
        {
            const string generateInventoryDetailsPageUrl = "/Pages/Activity/Inventory/InventoryOrderList.aspx";
            string baseUrl = ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, generateInventoryDetailsPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        private InventoryOrderList() { }

        private static readonly Lazy<InventoryOrderList> Singleton =
            new Lazy<InventoryOrderList>(() => new InventoryOrderList());
    }
}
