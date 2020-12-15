using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu
{
    public class DuplicateLoginConfirmationPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = "#divMessage .as-popup-title";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        private const string NoButton = "#asMasterRadConfirmNoButton";

        public static DuplicateLoginConfirmationPopup Instance => Singleton.Value;

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

        public bool ClickNoButton()
        {
            return FluentElement.Instance
                .WaitForElement(NoButton)
                .Click();
        }

        private DuplicateLoginConfirmationPopup() { }

        private static readonly Lazy<DuplicateLoginConfirmationPopup> Singleton =
            new Lazy<DuplicateLoginConfirmationPopup>(() => new DuplicateLoginConfirmationPopup());
    }
}
