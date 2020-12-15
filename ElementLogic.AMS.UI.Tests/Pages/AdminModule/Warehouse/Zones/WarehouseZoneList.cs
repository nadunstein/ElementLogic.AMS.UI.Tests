using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Zones
{
    public class WarehouseZoneList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_warehouseZoneListView1_lblHeader";
        
        private const string ResultTable = ".rgMasterTable > tbody";
        
        private const string FirstSearchResultRow =
            "#ctl00_ContentPlaceHolderContent_warehouseZoneListView1_radgridZones_ctl00__0";
        
        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_warehouseZoneListView1_radgridZones_ctl00_ctl02_ctl00_rtbGridTopBar .rtbText";

        public static WarehouseZoneList Instance => Singleton.Value;

        public void Navigate()
        {
            const string warehouseZoneListPageUrl = "/Pages/Warehouse/WarehouseZoneList.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + warehouseZoneListPageUrl;
            FluentElement.Instance.Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Warehouse zone list");
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(FirstSearchResultRow)
                .IsVisible();
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsNewZoneAdded(string zone)
        {
            return PageObjectHelper.Instance
                .TableDataExists(ResultTable, 2, zone);
        }

        private WarehouseZoneList() { }

        private static readonly Lazy<WarehouseZoneList> Singleton =
            new Lazy<WarehouseZoneList>(() => new WarehouseZoneList());
    }
}
