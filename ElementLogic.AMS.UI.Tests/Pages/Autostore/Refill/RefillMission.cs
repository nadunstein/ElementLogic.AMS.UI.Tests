using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill
{
    public class RefillMission
    {
        public const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        public const string ProductIdLabel =
            "#ctl00_MonitorContentPlaceholder_RefillView_FlbPrdNo_InputTemplateItem_TxbPrdNo";

        public const string QuantityField = "#ctl00_MonitorContentPlaceholder_RefillView_txtQuantity";

        public const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_RefillView_btnConfirm";

        public const string ExitButton = "#ctl00_MonitorContentPlaceholder_RefillView_btnExit";

        public const string TaskQueueLabel = "#ctl00_head_HeaderView_LblTaskQueue";

        public const string EmptyBinLabel = "#ctl00_MonitorContentPlaceholder_RefillView_lblEmptyBinNote";

        public const string LocationNameLabel = "#ctl00_MonitorContentPlaceholder_RefillView_txtBin";

        public static RefillMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Refill");
        }

        public string GetTaskQueueLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(TaskQueueLabel)
                .GetText();
        }

        public string GetLocationNameLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(LocationNameLabel)
                .GetText();
        }

        public string GetRefillProductId()
        {
            return FluentElement.Instance
                .WaitForElement(ProductIdLabel)
                .GetAttribute("value");
        }

        public int GetRefillQuantityFieldValue()
        {
            var refillQuantity = FluentElement.Instance
                .WaitForElement(QuantityField)
                .GetAttribute("value");
            return Convert.ToInt32(refillQuantity);
        }

        public bool ChangeValueOfQuantityField(string quantity)
        {
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .Insert(quantity);
        }

        public bool IsRefillEmptyBinLabelDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(EmptyBinLabel);
        }

        public string GetRefillEmptyBinLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(EmptyBinLabel)
                .GetText();
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        public bool ClickExitButton()
        {
            return FluentElement.Instance
                .WaitForElement(ExitButton)
                .Click();
        }

        private RefillMission() { }

        private static readonly Lazy<RefillMission> Singleton =
            new Lazy<RefillMission>(() => new RefillMission());
    }
}
