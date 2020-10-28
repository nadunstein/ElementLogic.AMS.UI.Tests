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

        private DuplicateLoginConfirmationPopup() { }

        private static readonly Lazy<DuplicateLoginConfirmationPopup> Singleton =
            new Lazy<DuplicateLoginConfirmationPopup>(() => new DuplicateLoginConfirmationPopup());
    }
}
