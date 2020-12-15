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
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Place in Container");
        }

        public string GetBoxNumber()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(BoxField)
                .GetAttribute("Value");
        }

        public int GetQuantityFieldValue()
        {
            return int.Parse(FluentElement.Instance
                .WaitForElement(QuantityField)
                .GetAttribute("Value"));
        }

        public bool InsertQuantity(int quantity)
        {
            var quantityString = quantity.ToString();
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .Insert(quantityString);
        }

        public bool IsScanFieldDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .IsVisible();
        }

        public bool IsScanFieldFocused()
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .IsFocused();
        }

        public bool InsertScanValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ScanField)
                .ScrollToTheElement()
                .Insert(scanValue);
        }

        public bool ClickConfirmButton()
        {
            var isButtonClicked = FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ConfirmButton)
                .Click();
            FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel);
            return isButtonClicked;
        }

        public bool ClickExitButton()
        {
            return FluentElement.Instance
                .WaitForElement(ExitButton)
                .Click();
        }

        private PlaceInContainer() { }

        private static readonly Lazy<PlaceInContainer> Singleton =
            new Lazy<PlaceInContainer>(() => new PlaceInContainer());
    }
}
