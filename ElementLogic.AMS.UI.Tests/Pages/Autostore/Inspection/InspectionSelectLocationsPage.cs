using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class InspectionSelectLocationsPage
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_LoadingPanel1";

        private const string LocationTable = ".rgMasterTable tbody";

        private const string SelectAllLocationButton = ".headSwitch";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_inspectionSelectBinsView_btnConfirm";

        public static InspectionSelectLocationsPage Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Inspection - Select locations");
        }

        public int GetLocationCount()
        {
             return FluentElement.Instance
                .WaitForElement(LocationTable)
                .GetTableElements()
                .GetRowCount();
        }

        public bool ClickSelectAllLocationButton()
        {
            return FluentElement.Instance
                .WaitForElement(SelectAllLocationButton)
                .Click();
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private InspectionSelectLocationsPage() { }

        private static readonly Lazy<InspectionSelectLocationsPage> Singleton =
            new Lazy<InspectionSelectLocationsPage>(() => new InspectionSelectLocationsPage());
    }
}

