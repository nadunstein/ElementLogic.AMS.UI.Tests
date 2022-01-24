using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory
{
    public class InventoryMission
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string TaskQueueLabel = "#ctl00_head_HeaderView_LblTaskQueue";

        private const string ProductNumberLabel =
            "#ctl00_MonitorContentPlaceholder_InventoryView_flbProdNo_InputTemplateItem_txtProdNo";

        private const string AutoStoreLocationLabel = "#ctl00_MonitorContentPlaceholder_InventoryView_txtBin";

        private const string ReasonField = "#ctl00_MonitorContentPlaceholder_InventoryView_cboReasons_Input";

        private const string HandlingUnitScanCodeField =
            "#ctl00_MonitorContentPlaceholder_InventoryView_txtHandlingUnitScanCode";

        private const string HandlingUnitScanCodeConfirmedText =
            "#ctl00_MonitorContentPlaceholder_InventoryView_lblHandlingUnitScannedValue";

        private const string QuantityField = "#ctl00_MonitorContentPlaceholder_InventoryView_txtBinQuantity";

        private const string HandlingUnitQuantityField = "#ctl00_MonitorContentPlaceholder_InventoryView_txtHandlingUnitQuantity";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_InventoryView_btnConfirm";

        private const string LocationCompleteButton = "#ctl00_MonitorContentPlaceholder_InventoryView_btnLocationComplete";

        public static InventoryMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Inventory");
        }

        public bool IsInventoryMissionLoaded()
        {
            return FluentElement.Instance
                .IsVisible(TaskQueueLabel);
        }

        public string GetTaskQueueLabelValue()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(TaskQueueLabel)
                .GetText();
        }

        public string GetProductNumberLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(ProductNumberLabel)
                .GetAttribute("value");
        }

        public string GetAutoStoreLocationLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(AutoStoreLocationLabel)
                .GetText();
        }

        public string GetReasonFieldValue()
        {
            return FluentElement.Instance
                .WaitForElement(ReasonField)
                .GetAttribute("value");
        }

        public string GetQuantityFieldValue()
        {
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .GetAttribute("value");
        }

        public bool InsertHandlingUnitScanCode(string handlingUnitScanCode)
        {
            return FluentElement.Instance
                .WaitForElement(HandlingUnitScanCodeField)
                .Insert(handlingUnitScanCode);
        }

        public string GetHandlingUnitScanCodeConfirmedText()
        {
            return FluentElement.Instance
                .WaitForElement(HandlingUnitScanCodeConfirmedText)
                .GetText();
        }

        public bool IsQuantityFieldDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .IsVisible();
        }

        public bool IsHandlingUnitQuantityFieldDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(HandlingUnitQuantityField)
                .IsVisible();
        }

        public bool InsertQuantity(int quantity)
        {
            var quantityString = quantity.ToString();
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .Insert(quantityString);
        }

        public bool InsertHandlingUnitQuantity(int quantity)
        {
            var quantityString = quantity.ToString();
            return FluentElement.Instance
                .WaitForElement(HandlingUnitQuantityField)
                .Insert(quantityString);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        public bool IsLocationCompleteButtonDisable()
        {
            return !FluentElement.Instance
                .WaitForElement(LocationCompleteButton)
                .IsEnable();
        }

        public bool ClickLocationCompleteButton()
        {
            return FluentElement.Instance
                .WaitForElement(LocationCompleteButton)
                .Click();
        }

        private InventoryMission() { }

        private static readonly Lazy<InventoryMission> Singleton =
            new Lazy<InventoryMission>(() => new InventoryMission());
    }
}
