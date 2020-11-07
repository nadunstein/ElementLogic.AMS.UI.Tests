using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class PlaceInContainer
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string BoxField = "#ctl00_MonitorContentPlaceholder_PickView_txtBoxInfo";

        private const string QuantityField = "#ctl00_MonitorContentPlaceholder_PickView_txtQuantity";

        private const string ScanField = "#ctl00_MonitorContentPlaceholder_PickView_txtPlacingScanField";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_PickView_btnConfirm";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_PickView_btnExit";

        public static PlaceInContainer Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Place in Container", LoadingPanel);
        }

        public string GetBoxNumber()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.GetAttributeValue(BoxField, "Value");
        }

        public int GetQuantityFieldValue()
        {
            return int.Parse(PageObjectHelper.Instance.GetAttributeValue(QuantityField, "Value"));
        }

        public bool InsertQuantity(int quantity)
        {
            return PageObjectHelper.Instance.InsertField(QuantityField, quantity.ToString());
        }

        public bool IsScanFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ScanField, true);
        }

        public bool IsScanFieldFocused()
        {
            return PageObjectHelper.Instance.IsFocused(ScanField);
        }

        public bool InsertScanValue(string scanValue)
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            PageObjectHelper.Instance.ScrollToTheElement(ScanField);
            return PageObjectHelper.Instance.InsertField(ScanField, scanValue);
        }

        public bool ClickConfirmButton()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            var isButtonClicked = PageObjectHelper.Instance.Click(ConfirmButton);
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return isButtonClicked;
        }

        public bool ClickExitButton()
        {
            return PageObjectHelper.Instance.Click(ExitButton);
        }

        private PlaceInContainer() { }

        private static readonly Lazy<PlaceInContainer> Singleton =
            new Lazy<PlaceInContainer>(() => new PlaceInContainer());
    }
}
