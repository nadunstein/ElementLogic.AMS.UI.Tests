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

        private const string ScanCodeField = "#ctl00_ContentPlaceHolder1_ctl00_txtScanCode";

        private const string AddButton = "#ctl00_ContentPlaceHolder1_ctl00_btnAddContainer";

        private const string CloseButton = "#ctl00_ContentPlaceHolder1_ctl00_btnClose";

        private const string UpdateButton = "#ctl00_ContentPlaceHolder1_ctl00_btnUpdate";

        private const string ContainerValidationPopup = ".rwTable";

        private const string ValidationMessage = "#divMessage";

        private const string ValidationOkButton = ".as-btn-center";

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

        public bool IsAddButtonEnable()
        {
            return PageObjectHelper.Instance.IsEnabled(AddButton);
        }

        public bool IsScanCodeFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(AddButton, true);
        }

        public bool IsScanCodeFieldNotDisplayed()
        {
            return PageObjectHelper.Instance.WaitUntilInvisible(ScanCodeField);
        }

        public string GetScanCodeFieldValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ScanCodeField, "value");
        }

        public bool InsertContainerScanCode(string scanCode)
        {
            return PageObjectHelper.Instance.InsertField(ScanCodeField, scanCode);
        }

        public bool IsContainerValidationPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ContainerValidationPopup, true);
        }

        public string GetValidationPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(ValidationMessage);
        }

        public bool ClickValidationPopupOkButton()
        {
            return PageObjectHelper.Instance.Click(ValidationOkButton);
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Add" => ClickAddButton(),
                "Update" => ClickUpdateButton(),
                "Close" => ClickCloseButton(),
                _ => false
            };

            return isButtonClicked;
        }

        private static bool ClickAddButton()
        {
            var isAddButtonClicked = PageObjectHelper.Instance.Click(AddButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isAddButtonClicked;
        }

        private static bool ClickUpdateButton()
        {
            return PageObjectHelper.Instance.Click(UpdateButton);
        }

        private static bool ClickCloseButton()
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
