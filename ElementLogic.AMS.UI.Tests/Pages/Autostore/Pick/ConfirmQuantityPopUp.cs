using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ConfirmQuantityPopUp
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#ctl00_ContentPlaceHolder1_ctl00_BinQtyMessageLabel";

        private const string QuantityField = "#ctl00_ContentPlaceHolder1_ctl00_txtQuantity";

        private const string ConfirmButton = "#ctl00_ContentPlaceHolder1_ctl00_btnConfirm";

        public static ConfirmQuantityPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Iframe, true);
        }

        public string GetPopupMessage()
        {
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return PageObjectHelper.Instance.GetTextValue(PopUpMessage);
        }

        public bool InsertQuantity(string quantity)
        {
            return PageObjectHelper.Instance.InsertField(QuantityField, quantity);
        }

        public bool ClickConfirmButton()
        {
            var isConfirmButtonClicked = PageObjectHelper.Instance.Click(ConfirmButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isConfirmButtonClicked;
        }

        private ConfirmQuantityPopUp() { }

        private static readonly Lazy<ConfirmQuantityPopUp> Singleton =
            new Lazy<ConfirmQuantityPopUp>(() => new ConfirmQuantityPopUp());
    }
}
