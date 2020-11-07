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
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Serial number registration", 
                LoadingPanel);
        }

        public string GetScanFieldLabelValue()
        {
            return PageObjectHelper.Instance.GetTextValue(ScanFieldLabel);
        }

        public bool IsQuantityFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(QuantityField);
        }

        public bool IsAutostoreBinLayoutDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(AutostoreBinLayout);
        }

        public bool IsScanFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ScanField);
        }

        public bool InsertScanValue(string scanValue)
        {
            return PageObjectHelper.Instance.InsertField(ScanField, scanValue);
        }

        public bool IsPreviousSerialNumberScanFieldDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(PreviousScanField, true, true);
        }

        public bool InsertPreviousScanValue(string scanValue)
        {
            return PageObjectHelper.Instance.InsertField(PreviousScanField, scanValue);
        }

        public bool ClickUpdateButton()
        {
            return PageObjectHelper.Instance.Click(UpdateButton);
        }

        public bool IstUpdateSuccessNotificationDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(UpdateSuccessNotification, true);
        }

        public string GetUpdateSuccessNotificationMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(UpdateSuccessNotificationMessage);
        }

        public bool IsLastSerialNumberConfirmLabelDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(LastSerialNumberConfirmLabel);
        }

        public string GetLastSerialNumberConfirmLabelTextValue()
        {
            return PageObjectHelper.Instance.GetTextValue(LastSerialNumberConfirmLabel);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        private SerialNumberRegistration() { }

        private static readonly Lazy<SerialNumberRegistration> Singleton =
            new Lazy<SerialNumberRegistration>(() => new SerialNumberRegistration());
    }
}
