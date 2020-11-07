using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList
{
    public class AutostoreEquipmentList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_StatusView1_lblHeader";

        private const string EquipmentListTable =
            "#ctl00_ContentPlaceHolderContent_StatusView1_resultGrid_ctl00 tbody";

        public static AutostoreEquipmentList Instance => Singleton.Value;

        public void Navigate()
        {
            const string autostoreEquipmentListPageUrl = "/Pages/Controller/Status.aspx";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, autostoreEquipmentListPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "AutoStore equipment list");
        }

        public bool SelectAutostoreEquipment(string equipmentName)
        {
            return PageObjectHelper.Instance.SearchAndClickTableCellItem(EquipmentListTable, 2,
                equipmentName, 2, "a");
        }

        private AutostoreEquipmentList() { }

        private static readonly Lazy<AutostoreEquipmentList> Singleton =
            new Lazy<AutostoreEquipmentList>(() => new AutostoreEquipmentList());
    }
}
