using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.UserActivity
{
    public class TransferUserPopup
    {
        private const string Iframe = "iframe";

        private const string TransferUserDropdown =
            "#ctl00_content_TransferUserView1_FlbTransferUser_InputTemplateItem_CboTransferUser";

        private const string ConfirmButton = "#ctl00_content_TransferUserView1_BtnConfirm";

        private const string CancelButton = "#ctl00_content_TransferUserView1_BtnCancel";

        public static TransferUserPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Iframe, true);
        }

        public bool SelectTransferUser(string userName)
        {
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return PageObjectHelper.Instance.SelectDropDown(TransferUserDropdown, userName);
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Confirm" => ClickConfirmButton(),
                "Cancel" => ClickCancelButton(),
                _ => false
            };

            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isButtonClicked;
        }

        private static bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        private static bool ClickCancelButton()
        {
            return PageObjectHelper.Instance.Click(CancelButton);
        }

        private TransferUserPopup() { }

        private static readonly Lazy<TransferUserPopup> Singleton =
            new Lazy<TransferUserPopup>(() => new TransferUserPopup());
    }
}
