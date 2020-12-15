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
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public bool SelectProduct(string extProductId)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ProductField)
                .SelectSearchDropDown(ProductDropDownList, "li", extProductId);

        }

        public bool InsertQuantity(int quantity)
        {
            var quantityString = quantity.ToString();
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(QuantityField)
                .Insert(quantityString);
        }

        public bool ClickOkButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(OkButton)
                .Click();
        }

        private RegisterProductPopup() { }

        private static readonly Lazy<RegisterProductPopup> Singleton =
            new Lazy<RegisterProductPopup>(() => new RegisterProductPopup());
    }
}
