using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill
{
    public class RefillTaskgroupExitPopup
    {
        private const string Popup = ".rwTable";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string PopupMessage = "#divMessage .as-popup-title";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        public static RefillTaskgroupExitPopup Instance => Singleton.Value;

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
            var isClicked = FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
            FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel);
            return isClicked;
        }

        private RefillTaskgroupExitPopup() { }

        private static readonly Lazy<RefillTaskgroupExitPopup> Singleton =
            new Lazy<RefillTaskgroupExitPopup>(() => new RefillTaskgroupExitPopup());
    }
}
