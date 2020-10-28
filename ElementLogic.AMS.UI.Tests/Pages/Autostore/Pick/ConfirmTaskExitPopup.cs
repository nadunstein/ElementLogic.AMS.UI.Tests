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

        private ConfirmTaskExitPopup() { }

        private static readonly Lazy<ConfirmTaskExitPopup> Singleton =
            new Lazy<ConfirmTaskExitPopup>(() => new ConfirmTaskExitPopup());
    }
}
