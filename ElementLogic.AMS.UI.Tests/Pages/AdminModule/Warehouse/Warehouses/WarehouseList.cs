using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Warehouses
{
    public class WarehouseList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_WarehousePageView1_lblHeader";
        
        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_WarehousePageView1_radgridWarehouse_ctl00_ctl02_ctl00_rtbGridTopBar .rtbText";
        
        private const string AddEditRow = ".rgMasterTable .rgEditRow";
        
        private const string CodeField =
            "#ctl00_ContentPlaceHolderContent_WarehousePageView1_radgridWarehouse_ctl00_ctl02_ctl03_txtCode";

        private const string DescriptionField =
            "#ctl00_ContentPlaceHolderContent_WarehousePageView1_radgridWarehouse_ctl00_ctl02_ctl03_txtDes";
        
        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_WarehousePageView1_radgridWarehouse_ctl00_ctl02_ctl03_PerformInsertButton";
        
        private const string FirstSearchResultRow =
            "#ctl00_ContentPlaceHolderContent_WarehousePageView1_radgridWarehouse_ctl00__0";

        public static WarehouseList Instance => Singleton.Value;

        public void Navigate()
        {
            const string warehouseListPageUrl = "/Pages/Warehouse/WarehousePage.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + warehouseListPageUrl;
            FluentElement.Instance.Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Warehouse list");
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsAddEditRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(AddEditRow)
                .IsVisible();
        }

        public bool InsertCode(string code)
        {
            return FluentElement.Instance
                .WaitForElement(CodeField)
                .Insert(code);
        }

        public bool InsertDescription(string description)
        {
            return FluentElement.Instance
                .WaitForElement(DescriptionField)
                .Insert(description);
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(FirstSearchResultRow)
                .IsVisible();
        }

        private WarehouseList() { }

        private static readonly Lazy<WarehouseList> Singleton = new Lazy<WarehouseList>(() => new WarehouseList());
    }
}
