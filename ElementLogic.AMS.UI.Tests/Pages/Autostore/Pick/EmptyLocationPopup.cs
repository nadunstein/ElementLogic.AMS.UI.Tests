using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class EmptyLocationPopup
    {
        private const string Popup = ".rwTable";

        private const string LoadingPanel = ".TelerikModalOverlay";

        private const string PopUpMessage = ".rwTable .as-popup-title";

        private const string YesButton = ".rwTable #asMasterRadConfirmYesButton";

        private const string NoButton = ".rwTable #asMasterRadConfirmNoButton";

        public static EmptyLocationPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            PageObjectHelper.Instance.IsDisplayed(LoadingPanel, true);
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

        private EmptyLocationPopup() { }

        private static readonly Lazy<EmptyLocationPopup> Singleton =
            new Lazy<EmptyLocationPopup>(() => new EmptyLocationPopup());
    }
}
