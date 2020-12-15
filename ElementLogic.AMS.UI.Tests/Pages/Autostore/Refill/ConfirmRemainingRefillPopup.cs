using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill
{
    public class ConfirmRemainingRefillPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = "#divMessage .as-popup-title";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        public static ConfirmRemainingRefillPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .WaitForElement(PopupMessage)
                .GetText();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private ConfirmRemainingRefillPopup() { }

        private static readonly Lazy<ConfirmRemainingRefillPopup> Singleton =
            new Lazy<ConfirmRemainingRefillPopup>(() => new ConfirmRemainingRefillPopup());
    }
}
