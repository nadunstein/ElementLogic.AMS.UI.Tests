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

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_PutawayView1_BtnExit";

        private const string ProductImage = "#ctl00_MonitorContentPlaceholder_PutawayView1_productImage";

        public static PutawayMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Putaway");
        }

        public bool ClickExitButton()
        {
            return PageObjectHelper.Instance.Click(ExitButton);
        }

        public string GetTaskQueueLabelValue()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.GetTextValue(TaskQueueLabel);
        }

        public string GetExtProductIdFieldValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ExtProductIdField, "Value");
        }

        public string GetLocationNameLabelValue()
        {
            return PageObjectHelper.Instance.GetTextValue(LocationNameLabel);
        }

        public bool IsQuantityFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(QuantityField);
        }

        public bool IsQuantityFieldFocused()
        {
            return PageObjectHelper.Instance.IsFocused(QuantityField);
        }

        public int GetQuantityFieldValue()
        {
            var putawayQuantity = PageObjectHelper.Instance.GetAttributeValue(QuantityField, "Value");
            return Convert.ToInt32(putawayQuantity);
        }

        public bool IsScanFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ScanField);
        }

        public bool IsScanFieldFocused()
        {
            return PageObjectHelper.Instance.IsFocused(ScanField);
        }

        public bool IsProductImageDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ProductImage);
        }

        public string GetProductImageUrl()
        {
            var imageSrcUrlValue = PageObjectHelper.Instance.GetAttributeValue(ProductImage, "src");
            return imageSrcUrlValue;
        }

        public bool IncludeScanValue(string scanValue)
        {
            return PageObjectHelper.Instance.InsertField(ScanField, scanValue);
        }

        public void ClickEnterButtonOnQuantityField()
        {
            PageObjectHelper.Instance.ClickEnterButton(QuantityField);
        }

        private PutawayMission() { }

        private static readonly Lazy<PutawayMission> Singleton = new Lazy<PutawayMission>(() => new PutawayMission());
    }
}
