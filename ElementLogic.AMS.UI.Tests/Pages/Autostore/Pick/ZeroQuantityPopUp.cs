using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ZeroQuantityPopUp
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#ctl00_ContentPlaceHolder1_ctl00_BinQtyIsEmptyLocation";

        private const string YesButton = "#locationEmpty";

        private const string NoButton = "#locationNotEmpty";

        public static ZeroQuantityPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            var isPopupDisplayed = PageObjectHelper.Instance.IsDisplayed(Iframe ,true);
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return isPopupDisplayed;
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

        public bool ClickNoButton()
        {
            var isNoButtonClicked = PageObjectHelper.Instance.Click(NoButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isNoButtonClicked;
        }

        private ZeroQuantityPopUp() { }

        private static readonly Lazy<ZeroQuantityPopUp> Singleton =
            new Lazy<ZeroQuantityPopUp>(() => new ZeroQuantityPopUp());
    }
}
