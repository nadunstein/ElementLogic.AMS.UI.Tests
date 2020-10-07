using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory
{
    public class ConfirmQuantityPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = ".rwTable .as-popup-title";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        private const string NoButton = "#asMasterRadConfirmNoButton";

        public static ConfirmQuantityPopup Instance => Singleton.Value;

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

        public bool ClickNoButton()
        {
            return PageObjectHelper.Instance.Click(NoButton);
        }

        private ConfirmQuantityPopup() { }

        private static readonly Lazy<ConfirmQuantityPopup> Singleton =
            new Lazy<ConfirmQuantityPopup>(() => new ConfirmQuantityPopup());
    }
}
