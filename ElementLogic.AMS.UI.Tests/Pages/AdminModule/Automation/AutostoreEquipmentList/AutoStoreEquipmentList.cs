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
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + autostoreEquipmentListPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("AutoStore equipment list");
        }

        public bool SelectAutostoreEquipment(string equipmentName)
        {
            return FluentElement.Instance
                .SearchAndClickTableCellItem(EquipmentListTable, 2,
                equipmentName, 2, "a");
        }

        private AutostoreEquipmentList() { }

        private static readonly Lazy<AutostoreEquipmentList> Singleton =
            new Lazy<AutostoreEquipmentList>(() => new AutostoreEquipmentList());
    }
}
