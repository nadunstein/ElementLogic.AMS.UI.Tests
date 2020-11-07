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
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Refill", LoadingPanel);
        }

        public string GetTaskQueueLabelValue()
        {
            return PageObjectHelper.Instance.GetTextValue(TaskQueueLabel);
        }

        public string GetLocationNameLabelValue()
        {
            return PageObjectHelper.Instance.GetTextValue(LocationNameLabel);
        }

        public string GetRefillProductId()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ProductIdLabel, "value");
        }

        public int GetRefillQuantityFieldValue()
        {
            var refillQuantity = PageObjectHelper.Instance.GetAttributeValue(QuantityField, "value");
            return Convert.ToInt32(refillQuantity);
        }

        public bool ChangeValueOfQuantityField(string quantity)
        {
            return PageObjectHelper.Instance.InsertField(QuantityField, quantity);
        }

        public bool IsRefillEmptyBinLabelDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(EmptyBinLabel);
        }

        public string GetRefillEmptyBinLabelValue()
        {
            return PageObjectHelper.Instance.GetTextValue(EmptyBinLabel);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        public bool ClickExitButton()
        {
            return PageObjectHelper.Instance.Click(ExitButton);
        }

        private RefillMission() { }

        private static readonly Lazy<RefillMission> Singleton =
            new Lazy<RefillMission>(() => new RefillMission());
    }
}
