using System;
using System.Globalization;
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

        private const string ExtProductIdField =
            "#ctl00_MonitorContentPlaceholder_PutawayView1_FlbPrdNo_InputTemplateItem_TxbPrdNo";

        private const string ScanField = "#ctl00_MonitorContentPlaceholder_PutawayView1_txtScan";

        private const string AutostoreBinId = "#ctl00_MonitorContentPlaceholder_PutawayView1_lblBin";

        private const string ProductImage = "#ctl00_MonitorContentPlaceholder_PutawayView1_productImage";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_PutawayView1_BtnConfirm1";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_PutawayView1_BtnExit";

        private const string PutawayMoreButton = "#ctl00_MonitorContentPlaceholder_PutawayView1_BtnConfirmPlace";

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

        public bool ClickPutawayMoreButton()
        {
            return FluentElement.Instance
                .WaitForElement(PutawayMoreButton)
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

        public double GetQuantityFieldValue()
        {
            return double.Parse(FluentElement.Instance
                .WaitForElement(QuantityField)
                .GetAttribute("Value"));
        }

        public bool InsertQuantityFieldValue(double quantity)
        {
            var quantityString = quantity.ToString(CultureInfo.InvariantCulture);
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .Insert(quantityString);
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

        public string GetAutostoreBinId()
        {
            return FluentElement.Instance
                .WaitForElement(AutostoreBinId)
                .GetText();
        }

        public bool IsProductImageDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(ProductImage);
        }

        public string GetProductImageUrl()
        {
            return FluentElement.Instance
                .WaitForElement(ProductImage)
                .GetAttribute("src");
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

        public bool IsPutawayMoreButtonDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(PutawayMoreButton);
        }

        private PutawayMission() { }

        private static readonly Lazy<PutawayMission> Singleton = new Lazy<PutawayMission>(() => new PutawayMission());
    }
}
