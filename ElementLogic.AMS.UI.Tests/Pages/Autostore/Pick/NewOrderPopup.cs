using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class NewOrderPopup
    {
        private const string Iframe = ".rwTable > tbody > .rwContentRow > .rwWindowContent > iframe";

        private const string PopUpMessage = "#divMessage .as-txt-center";

        private const string OkButton = "#ctl00_ContentPlaceHolder1_ctl00_btnExit";

        public static NewOrderPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            var isPopupDisplayed = PageObjectHelper.Instance.IsDisplayed(Iframe);
            //var isPopupMessageCorrect = PageObjectHelper.Instance.GetTextValue(PopUpMessage)
                //.Contains("You are starting a new order");
            return isPopupDisplayed;
        }

        public bool ClickOkButton()
        {
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            var isOkButtonClicked = PageObjectHelper.Instance.Click(OkButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isOkButtonClicked;
        }

        private NewOrderPopup() { }

        private static readonly Lazy<NewOrderPopup> Singleton =
            new Lazy<NewOrderPopup>(() => new NewOrderPopup());
    }
}
