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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public string GetPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(PopupMessage);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        private ConfirmRemainingRefillPopup() { }

        private static readonly Lazy<ConfirmRemainingRefillPopup> Singleton =
            new Lazy<ConfirmRemainingRefillPopup>(() => new ConfirmRemainingRefillPopup());
    }
}
