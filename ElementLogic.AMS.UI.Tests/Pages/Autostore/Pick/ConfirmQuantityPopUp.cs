using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ConfirmQuantityPopUp
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#ctl00_ContentPlaceHolder1_ctl00_BinQtyMessageLabel";

        private const string QuantityField = "#ctl00_ContentPlaceHolder1_ctl00_txtQuantity";

        private const string ConfirmButton = "#ctl00_ContentPlaceHolder1_ctl00_btnConfirm";

        public static ConfirmQuantityPopUp Instance => Singleton.Value;

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
                .WaitForElement(PopUpMessage)
                .GetText();
        }

        public bool InsertQuantity(string quantity)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(QuantityField)
                .Insert(quantity);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private ConfirmQuantityPopUp() { }

        private static readonly Lazy<ConfirmQuantityPopUp> Singleton =
            new Lazy<ConfirmQuantityPopUp>(() => new ConfirmQuantityPopUp());
    }
}
