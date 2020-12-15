using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ConfirmTaskExitPopup
    {
        private const string Popup = ".rwTable";

        private const string PopUpMessage = "#divMessage h2";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        private const string NoButton = "#asMasterRadConfirmNoButton";

        public static ConfirmTaskExitPopup Instance => Singleton.Value;

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

        private ConfirmTaskExitPopup() { }

        private static readonly Lazy<ConfirmTaskExitPopup> Singleton =
            new Lazy<ConfirmTaskExitPopup>(() => new ConfirmTaskExitPopup());
    }
}
