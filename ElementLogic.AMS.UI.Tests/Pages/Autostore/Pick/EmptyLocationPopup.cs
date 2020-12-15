using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class EmptyLocationPopup
    {
        private const string Popup = ".rwTable";

        private const string PopUpMessage = ".rwTable .as-popup-title";

        private const string YesButton = ".rwTable #asMasterRadConfirmYesButton";

        private const string NoButton = ".rwTable #asMasterRadConfirmNoButton";

        public static EmptyLocationPopup Instance => Singleton.Value;

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

        private EmptyLocationPopup() { }

        private static readonly Lazy<EmptyLocationPopup> Singleton =
            new Lazy<EmptyLocationPopup>(() => new EmptyLocationPopup());
    }
}
