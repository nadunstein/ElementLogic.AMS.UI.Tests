using System;
using ElementLogic.AMS.UI.Tests.Configuration;
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
            string baseUrl = ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, warehouseListPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool IsAddEditRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(AddEditRow, true);
        }

        public bool InsertCode(string code)
        {
            return PageObjectHelper.Instance.InsertField(CodeField, code);
        }

        public bool InsertDescription(string description)
        {
            return PageObjectHelper.Instance.InsertField(DescriptionField, description);
        }

        public bool ClickSaveButton()
        {
            return PageObjectHelper.Instance.Click(SaveButton);
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(FirstSearchResultRow, true);
        }

        private WarehouseList() { }

        private static readonly Lazy<WarehouseList> Singleton = new Lazy<WarehouseList>(() => new WarehouseList());
    }
}
