
using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory
{
    public class HandlingUnitsMissingPopup
    {
        private const string Iframe = "iframe";

        private const string FirstPopupMessage = "#ctl00_ctl00_ContentPlaceHolder1_ctl00_FormDataPanelPanel .as-popup-title";

        private const string SecondPopupMessage = "#ctl00_ctl00_ContentPlaceHolder1_ctl00_FormDataPanelPanel .as-popup-content";

        private const string HandlingUnitsTable = ".rgMasterTable tbody";

        private const string ConfirmMissingButton = "#ctl00_ContentPlaceHolder1_ctl00_btnConfirmMissing";

        private const string CancelButton = "#ctl00_ContentPlaceHolder1_ctl00_btnRemove";

        public static HandlingUnitsMissingPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public string GetFirstPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(FirstPopupMessage)
                .GetText();
        }

        public string GetSecondPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(SecondPopupMessage)
                .GetText();
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            return buttonToBeClicked switch
            {
                "Confirm Missing" => ClickConfirmMissingButton(),
                "Cancel" => ClickCancelButton(),
                _ => false
            };
        }

        public bool IsHandlingUnitRecordExists(string handlingUnitScanCode)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(HandlingUnitsTable)
                .GetTableElements()
                .FindRowElements(1, handlingUnitScanCode)
                .IsExists();
        }

        public int GetHandlingUnitQuantity(string handlingUnitScanCode)
        {
            var quantityText = FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(HandlingUnitsTable)
                .GetTableElements()
                .FindRowElements(1, handlingUnitScanCode)
                .GetRowElement(2)
                .GetText();

            return int.Parse(quantityText.Split('.')[0]);
        }

        private static bool ClickConfirmMissingButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmMissingButton)
                .Click();
        }

        private static bool ClickCancelButton()
        {
            return FluentElement.Instance
                .WaitForElement(CancelButton)
                .Click();
        }

        private HandlingUnitsMissingPopup() { }

        private static readonly Lazy<HandlingUnitsMissingPopup> Singleton =
            new Lazy<HandlingUnitsMissingPopup>(() => new HandlingUnitsMissingPopup());
    }
}
