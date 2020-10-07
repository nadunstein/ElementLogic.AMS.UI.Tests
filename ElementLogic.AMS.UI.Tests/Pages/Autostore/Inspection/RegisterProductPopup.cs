using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class RegisterProductPopup
    {
        private const string Iframe = "iframe";

        private const string ProductField = "#ctl00_ContentPlaceHolder1_ctl00_cboProduct_Input";

        private const string ProductDropDownList = "#ctl00_ContentPlaceHolder1_ctl00_cboProduct_DropDown .rcbList";

        private const string QuantityField = "#ctl00_ContentPlaceHolder1_ctl00_txtQuantity";

        private const string OkButton = "#ctl00_ContentPlaceHolder1_ctl00_btnOk";

        public static RegisterProductPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            var popupDisplayed = PageObjectHelper.Instance.IsDisplayed(Iframe, true);
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return popupDisplayed;
        }

        public bool SelectProduct(string extProductId)
        {
            var isInserted = PageObjectHelper.Instance.InsertField(ProductField, extProductId);
            var isSelected = PageObjectHelper.Instance.SelectDropDown(null, ProductDropDownList, 
                "li", extProductId);

            return isInserted && isSelected;
        }

        public bool InsertQuantity(int quantity)
        {
            return PageObjectHelper.Instance.InsertField(QuantityField, quantity.ToString());
        }

        public bool ClickOkButton()
        {
            var isOkButtonClicked = PageObjectHelper.Instance.Click(OkButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isOkButtonClicked;
        }

        private RegisterProductPopup() { }

        private static readonly Lazy<RegisterProductPopup> Singleton =
            new Lazy<RegisterProductPopup>(() => new RegisterProductPopup());
    }
}
