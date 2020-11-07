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
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, equipmentListPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Equipment list");
        }

        public bool IsResultTableDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ResultTable, true);
        }

        public bool InsertName(string value)
        {
            return PageObjectHelper.Instance.InsertField(NameField, value);
        }

        public bool ClickSearchButton()
        {
            return PageObjectHelper.Instance.Click(SearchButton);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool IsNewEquipmentAdded(string equipment)
        {
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, equipment);
        }

        public bool ClickEquipmentViewButton()
        {
            return PageObjectHelper.Instance.Click(EquipmentViewButton);
        }

        private EquipmentList() { }

        private static readonly Lazy<EquipmentList> Singleton = new Lazy<EquipmentList>(() => new EquipmentList());
    }
}
