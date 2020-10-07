using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ChangedConfirmQuantityPopUp
    {
        private const string Iframe = "iframe";

        private const string Popup = ".rwTable";

        private const string PopUpMessage = ".rwTable #divMessage";

        private const string YesButton = ".rwTable #popupMasterRadConfirmYesButton";

        private const string NoButton = ".rwTable #popupMasterRadConfirmNoButton";

        public static ChangedConfirmQuantityPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
            
        }

        public string GetPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(PopUpMessage);
        }

        public bool ClickYesButton()
        {
            var isYesButtonClicked = PageObjectHelper.Instance.Click(YesButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isYesButtonClicked;
        }

        public bool IsNoButtonFocused()
        {
            var isNoButtonFocused = PageObjectHelper.Instance.IsFocused(NoButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isNoButtonFocused;
        }

        public bool ClickNoButton()
        {
            var isNoButtonClicked = PageObjectHelper.Instance.Click(NoButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isNoButtonClicked;
        }

        private ChangedConfirmQuantityPopUp() { }

        private static readonly Lazy<ChangedConfirmQuantityPopUp> Singleton =
            new Lazy<ChangedConfirmQuantityPopUp>(() => new ChangedConfirmQuantityPopUp());
    }
}
