using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class DeleteMissionsPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = ".rwTable .as-popup-title";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        private const string NoButton = "#asMasterRadConfirmNoButton";

        public static DeleteMissionsPopup Instance => Singleton.Value;

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

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ClickYesButton(),
                "No" => ClickNoButton(),
                _ => false
            };

            return isButtonClicked;
        }

        private static bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private static bool ClickNoButton()
        {
            return FluentElement.Instance
                .WaitForElement(NoButton)
                .Click();
        }

        private DeleteMissionsPopup() { }

        private static readonly Lazy<DeleteMissionsPopup> Singleton =
            new Lazy<DeleteMissionsPopup>(() => new DeleteMissionsPopup());
    }
}
