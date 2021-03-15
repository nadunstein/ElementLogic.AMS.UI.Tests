using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class SerialNumberRegistration
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string QuantityField = "#ctl00_MonitorContentPlaceholder_PickView_txtQuantity";

        private const string ScanFieldLabel = "#ctl00_MonitorContentPlaceholder_PickView_lblSerialNumberScanField";

        private const string AutostoreBinLayout = "#ctl00_MonitorContentPlaceholder_PickView_ShelfLayoutControl_ContainerDiv";

        private const string ScanField = "#ctl00_MonitorContentPlaceholder_PickView_txtSerialNumberScanField";

        private const string PreviousScanField = "#txtPreviousSerialNumber";

        private const string UpdateButton = "#btnUpdatePreviousSerialNumber";

        private const string LastSerialNumberConfirmLabel = "#divConfirmSerialNumber";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_PickView_btnConfirm";

        private const string UpdateSuccessNotification = "#noty_layout__topRight";

        private const string UpdateSuccessNotificationMessage = "#noty_layout__topRight .noty_body";

        public static SerialNumberRegistration Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Serial number registration");
        }

        public string GetScanFieldLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(ScanFieldLabel)
                .GetText();
        }

        public bool IsQuantityFieldDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(QuantityField);
        }

        public bool InsertQuantity(string quantity)
        {
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .Insert(quantity);
        }

        public bool IsAutostoreBinLayoutDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(AutostoreBinLayout);
        }

        public bool IsScanFieldNotDisplayed()
        {
            return !FluentElement.Instance
                .WaitUntilInvisible(ScanField)
                .IsVisible(ScanField);
        }

        public bool InsertScanValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .Wait(1)
                .Insert(scanValue);
        }

        public bool IsPreviousSerialNumberScanFieldDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PreviousScanField)
                .IsVisible();
        }

        public bool InsertPreviousScanValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitForElement(PreviousScanField)
                .Insert(scanValue);
        }

        public bool ClickUpdateButton()
        {
            return FluentElement.Instance
                .WaitForElement(UpdateButton)
                .Click();
        }

        public bool IstUpdateSuccessNotificationDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(UpdateSuccessNotification)
                .IsVisible();
        }

        public string GetUpdateSuccessNotificationMessage()
        {
            return FluentElement.Instance
                .WaitForElement(UpdateSuccessNotificationMessage)
                .GetText();
        }

        public bool IsLastSerialNumberConfirmLabelDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(LastSerialNumberConfirmLabel)
                .IsVisible();
        }

        public string GetLastSerialNumberConfirmLabelTextValue()
        {
            return FluentElement.Instance
                .WaitForElement(LastSerialNumberConfirmLabel)
                .GetText();
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private SerialNumberRegistration() { }

        private static readonly Lazy<SerialNumberRegistration> Singleton =
            new Lazy<SerialNumberRegistration>(() => new SerialNumberRegistration());
    }
}
