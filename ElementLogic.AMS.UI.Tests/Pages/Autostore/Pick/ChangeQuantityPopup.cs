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
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .WaitForElement(PopUpMessage)
                .GetText();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        public bool ClickNoButton()
        {
            return FluentElement.Instance
                .WaitForElement(NoButton)
                .Click();
        }

        private ChangeQuantityPopup() { }

        private static readonly Lazy<ChangeQuantityPopup> Singleton =
            new Lazy<ChangeQuantityPopup>(() => new ChangeQuantityPopup());
    }
}
