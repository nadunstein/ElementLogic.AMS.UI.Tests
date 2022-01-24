
using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory
{
    public class HandlingUnitEnterQuantityPopup
    {
        private const string Iframe = "iframe";

        private const string PopupMessage = "#ctl00_ctl00_ContentPlaceHolder1_ctl00_FormDataPanelPanel .as-popup-title";

        private const string QuantityField = "#ctl00_ContentPlaceHolder1_ctl00_txtQuantity";

        private const string ConfirmButton = "#ctl00_ContentPlaceHolder1_ctl00_btnConfirmRegistration";

        public static HandlingUnitEnterQuantityPopup Instance => Singleton.Value;
        
        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(PopupMessage)
                .GetText();
        }

        public bool InsertHandlingUnitQuantity(int quantity)
        {
            return FluentElement.Instance
                .WaitForElement(QuantityField)
                .Insert(quantity.ToString());
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private HandlingUnitEnterQuantityPopup() { }

        private static readonly Lazy<HandlingUnitEnterQuantityPopup> Singleton =
            new Lazy<HandlingUnitEnterQuantityPopup>(() => new HandlingUnitEnterQuantityPopup());
    }
}
