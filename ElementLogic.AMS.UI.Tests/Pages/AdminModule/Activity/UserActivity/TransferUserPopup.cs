using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.UserActivity
{
    public class TransferUserPopup
    {
        private const string Iframe = "iframe";

        private const string TransferUserField =
            "#ctl00_content_TransferUserView1_FlbTransferUser_InputTemplateItem_TransferUser_Input";

        private const string TransferUserDropdownSlide =
            "#ctl00_content_TransferUserView1_FlbTransferUser_InputTemplateItem_TransferUser_DropDown .rcbList";

        private const string ConfirmButton = "#ctl00_content_TransferUserView1_BtnConfirm";

        private const string CancelButton = "#ctl00_content_TransferUserView1_BtnCancel";

        public static TransferUserPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public bool SelectTransferUser(string userName)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(TransferUserField)
                .SelectSearchDropDown(TransferUserDropdownSlide, "li", userName);
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            return buttonToBeClicked switch
            {
                "Confirm" => ClickConfirmButton(),
                "Cancel" => ClickCancelButton(),
                _ => false
            };
        }

        private static bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private static bool ClickCancelButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(CancelButton)
                .Click();
        }

        private TransferUserPopup() { }

        private static readonly Lazy<TransferUserPopup> Singleton =
            new Lazy<TransferUserPopup>(() => new TransferUserPopup());
    }
}
