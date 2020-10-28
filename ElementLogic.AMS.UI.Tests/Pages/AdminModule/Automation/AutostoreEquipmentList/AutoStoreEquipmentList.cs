using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList
{
    public class AutoStoreEquipmentList
    {
        private const string PageHeader =
            "#ctl00_ctl00_ContentPlaceHolderContent_ContentPlaceHolderContent_StatusView1_lblHeader";

        private const string EquipmentListTable =
            "#ctl00_ctl00_ContentPlaceHolderContent_ContentPlaceHolderContent_StatusView1_resultGrid_ctl00";

        public static AutoStoreEquipmentList Instance => Singleton.Value;

        public void Navigate()
        {
            const string autostoreEquipmentListPageUrl = "/Pages/Controller/Status.aspx";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url"); ; 
            PageObjectHelper.Instance.Navigate(baseUrl, autostoreEquipmentListPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool ClickAutostoreEquipmentLink(string autostoreEquipment)
        {
            var attempts = 0;
            while (attempts < 20)
            {
                try
                {
                    var equipments = PageObjectHelper.Instance.Finds("[class*=Row]",
                        EquipmentListTable);
                    foreach (var equipment in equipments)
                    {
                        var equipmentDetails = PageObjectHelper.Instance.Finds("td", equipment);
                        var equipmentNameElement = PageObjectHelper.Instance.Finds("a", equipmentDetails[1]);
                        if (!equipmentNameElement[1].Text.Contains(autostoreEquipment))
                        {
                            continue;
                        }

                        return PageObjectHelper.Instance.Click(equipmentNameElement[1]);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                PageObjectHelper.Instance.Wait(0.5);
                attempts++;
            }

            return false;
        }

        private AutoStoreEquipmentList() { }

        private static readonly Lazy<AutoStoreEquipmentList> Singleton =
            new Lazy<AutoStoreEquipmentList>(() => new AutoStoreEquipmentList());
    }
}
