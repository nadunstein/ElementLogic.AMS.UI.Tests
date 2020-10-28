using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ChangedConfirmQuantityPopUp
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#binQuantityHigherThanMaxValue #ctl00_ContentPlaceHolder1_ctl00_lblBinQuantityHigherThanMaxValue";

        private const string YesButton = "#binQuantityHigherThanMaxValue .button-xl-green";

        private const string NoButton = "#binQuantityHigherThanMaxValue #cancelWithHigherQuantity";

        public static ChangedConfirmQuantityPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Iframe, true);
        }

        public string GetPopupMessage()
        {
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
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
