using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class AddNewContainerPopup
    {
        private const string Iframe = "iframe";

        private const string Popup = "#RadWindowWrapper_ctl00_RWPopupContainer";

        private const string BoxTypeDropDown = "#ctl00_ContentPlaceHolder1_ctl00_boxTypesComboBox_Input";

        private const string BoxTypeDropDownList = "#ctl00_ContentPlaceHolder1_ctl00_boxTypesComboBox_DropDown";

        private const string ContainersListPanel = "#ctl00_ContentPlaceHolder1_ctl00_lstContainers";

        private const string AddButton = "#ctl00_ContentPlaceHolder1_ctl00_btnAddContainer";

        private const string CloseButton = "#ctl00_ContentPlaceHolder1_ctl00_btnClose";

        private const string UpdateButton = "#ctl00_ContentPlaceHolder1_ctl00_btnUpdate";

        public static AddNewContainerPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            var isPopupDisplayed = PageObjectHelper.Instance.IsDisplayed(Popup, true);
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return isPopupDisplayed;
        }

        public bool SelectBoxType(string boxType)
        {
            return PageObjectHelper.Instance.SelectDropDown(BoxTypeDropDown, BoxTypeDropDownList, 
                "li", boxType);
        }

        public bool SelectContainerFromTheList(string boxType)
        {
            return PageObjectHelper.Instance.SelectDropDown(null, ContainersListPanel, 
                "option", boxType);
        }

        public bool ClickUpdateButton()
        {
            return PageObjectHelper.Instance.Click(UpdateButton);
        }

        public bool ClickAddButton()
        {
            var isAddButtonClicked = PageObjectHelper.Instance.Click(AddButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isAddButtonClicked;
        }

        public bool ClickCloseButton()
        {
            var isCloseButtonClicked = PageObjectHelper.Instance.Click(CloseButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isCloseButtonClicked;
        }

        private AddNewContainerPopup() { }

        private static readonly Lazy<AddNewContainerPopup> Singleton =
            new Lazy<AddNewContainerPopup>(() => new AddNewContainerPopup());
    }
}
