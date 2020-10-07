using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ChangeQuantityPopup
    {
        private const string Popup = ".rwTable";

        private const string PopUpMessage = ".rwTable .as-popup-title";

        private const string YesButton = ".rwTable #asMasterRadConfirmYesButton";

        private const string NoButton = ".rwTable #asMasterRadConfirmNoButton";

        public static ChangeQuantityPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public string GetPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(PopUpMessage);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        public bool ClickNoButton()
        {
            return PageObjectHelper.Instance.Click(NoButton);
        }

        private ChangeQuantityPopup() { }

        private static readonly Lazy<ChangeQuantityPopup> Singleton =
            new Lazy<ChangeQuantityPopup>(() => new ChangeQuantityPopup());
    }
}
