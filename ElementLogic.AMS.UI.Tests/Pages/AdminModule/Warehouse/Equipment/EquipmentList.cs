using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class EquipmentList
    {
        private const string PageHeader = 
            "#ctl00_ContentPlaceHolderContent_equipmentListView1_RadPanelBar1 .rpText";

        private const string ResultTable = ".rgMasterTable > tbody";

        private const string NameField =
            "#ctl00_ContentPlaceHolderContent_equipmentListView1_RadPanelBar1_i0_txtName";

        private const string SearchButton =
            "#ctl00_ContentPlaceHolderContent_equipmentListView1_BtnSearch";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_equipmentListView1_radgridEquipment_ctl00_ctl02_ctl00_rtbGridTopBar .rtbText";
        
        private const string EquipmentViewButton =
            "#ctl00_ContentPlaceHolderContent_equipmentListView1_radgridEquipment_ctl00_ctl04_gbccolumn";

        public static EquipmentList Instance => Singleton.Value;

        public void Navigate()
        {
            const string equipmentListPageUrl = "/Pages/Warehouse/EquipmentList.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + equipmentListPageUrl;
            FluentElement.Instance.Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Equipment list");
        }

        public bool IsResultTableDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(ResultTable)
                .IsVisible();
        }

        public bool InsertName(string value)
        {
            return FluentElement.Instance
                .WaitForElement(NameField)
                .Insert(value);
        }

        public bool ClickSearchButton()
        {
            return FluentElement.Instance
                .WaitForElement(SearchButton)
                .Click();
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsNewEquipmentAdded(string equipment)
        {
            return FluentElement.Instance
                .WaitForElement(ResultTable)
                .GetTableElements()
                .FindRowElements(3, equipment)
                .IsExists();
        }

        public bool ClickEquipmentViewButton()
        {
            return FluentElement.Instance
                .WaitForElement(EquipmentViewButton)
                .Click();
        }

        private EquipmentList() { }

        private static readonly Lazy<EquipmentList> Singleton = new Lazy<EquipmentList>(() => new EquipmentList());
    }
}
