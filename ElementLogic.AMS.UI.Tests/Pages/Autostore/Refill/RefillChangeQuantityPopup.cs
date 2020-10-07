using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill
{
    public class RefillChangeQuantityPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = "#divMessage .as-popup-title";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        public static RefillChangeQuantityPopup Instance => Singleton.Value;

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

        private RefillChangeQuantityPopup() { }

        private static readonly Lazy<RefillChangeQuantityPopup> Singleton =
            new Lazy<RefillChangeQuantityPopup>(() => new RefillChangeQuantityPopup());
    }
}
