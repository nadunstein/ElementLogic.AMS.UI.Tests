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

        private const string QuantityField = "#ctl00_MonitorContentPlaceholder_InventoryView_txtBinQuantity";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_InventoryView_btnConfirm";

        public static InventoryMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Inventory");
        }

        public bool IsInventoryMissionLoaded()
        {
            PageObjectHelper.Instance.RefreshWebPage();
            PageObjectHelper.Instance.Wait(2);
            return PageObjectHelper.Instance.IsDisplayed(TaskQueueLabel);
        }

        public string GetTaskQueueLabelValue()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.GetTextValue(TaskQueueLabel);
        }

        public string GetProductNumberLabelValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ProductNumberLabel, "value");
        }

        public string GetAutoStoreLocationLabelValue()
        {
            return PageObjectHelper.Instance.GetTextValue(AutoStoreLocationLabel);
        }

        public string GetReasonFieldValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ReasonField, "value");
        }

        public string GetQuantityFieldValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(QuantityField, "value");
        }

        public bool InsertQuantity(int quantity)
        {
            return PageObjectHelper.Instance.InsertField(QuantityField, quantity.ToString());
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        private InventoryMission() { }

        private static readonly Lazy<InventoryMission> Singleton =
            new Lazy<InventoryMission>(() => new InventoryMission());
    }
}
