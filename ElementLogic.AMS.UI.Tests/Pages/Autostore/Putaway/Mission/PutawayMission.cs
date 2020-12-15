using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission
{
    public class PutawayMission
    {
        private const string PageHeader = "#ctl00_head_HeaderView1_lblCurrentOperation"; 

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string TaskQueueLabel = "#ctl00_head_HeaderView1_LblTaskQueue";

        private const string QuantityField =
            "#ctl00_MonitorContentPlaceholder_PutawayView1_FlbQty_InputTemplateItem_TxbQty";

        private const string LocationNameLabel = "#ctl00_MonitorContentPlaceholder_PutawayView1_lblBin";

        private const string ExtProductIdField =
            "#ctl00_MonitorContentPlaceholder_PutawayView1_FlbPrdNo_InputTemplateItem_TxbPrdNo";

        private const string ScanField = "#ctl00_MonitorContentPlaceholder_PutawayView1_txtScan";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_PutawayView1_BtnConfirm1";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_PutawayView1_BtnExit";

        private const string ProductImage = "#ctl00_MonitorContentPlaceholder_PutawayView1_productImage";

        public static PutawayMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Putaway");
        }

        public bool ClickExitButton()
        {
            return FluentElement.Instance
                .WaitForElement(ExitButton)
                .Click();
        }

        public string GetTaskQueueLabelValue()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(TaskQueueLabel)
                .GetText();
        }

        public string GetExtProductIdFieldValue()
        {
            return FluentElement.Instance
                .WaitForElement(ExtProductIdField)
                .GetAttribute("Value");
        }

        public string GetLocationNameLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(LocationNameLabel)
                .GetText();
        }

        public bool IsQuantityFieldDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(QuantityField);
        }

        public bool IsQuantityFieldFocused()
        {
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .IsFocused();
        }

        public int GetQuantityFieldValue()
        {
            var putawayQuantity = FluentElement.Instance
                .WaitForElement(QuantityField)
                .GetAttribute("Value");
            return Convert.ToInt32(putawayQuantity);
        }

        public bool IsScanFieldDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(ScanField);
        }

        public bool IsScanFieldFocused()
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .IsFocused();
        }

        public bool IsProductImageDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(ProductImage);
        }

        public string GetProductImageUrl()
        {
            var imageSrcUrlValue = FluentElement.Instance
                .WaitForElement(ProductImage)
                .GetAttribute("src");
            return imageSrcUrlValue;
        }

        public bool IncludeScanValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .Insert(scanValue);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private PutawayMission() { }

        private static readonly Lazy<PutawayMission> Singleton = new Lazy<PutawayMission>(() => new PutawayMission());
    }
}
