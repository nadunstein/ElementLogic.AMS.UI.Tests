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
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public bool SelectBoxType(string boxType)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(BoxTypeDropDown)
                .Wait(1)
                .SelectDropDown(BoxTypeDropDownList, 
                    "li", boxType);
        }

        public bool SelectContainerFromTheList(string boxType)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ContainersListPanel)
                .FindElements("option")
                .SearchElementByText(boxType)
                .Click();
        }

        public bool IsAddButtonEnable()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(AddButton)
                .IsEnable();
        }

        public bool IsScanCodeFieldDisplayed()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(AddButton)
                .IsVisible();
        }

        public bool IsScanCodeFieldNotDisplayed()
        {
            return !FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitUntilInvisible(ScanCodeField)
                .IsVisible(ScanCodeField);
        }

        public string GetScanCodeFieldValue()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ScanCodeField)
                .GetAttribute("value");
        }

        public string GetScanCodeFieldPlaceholderValue()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ScanCodeField)
                .GetAttribute("placeholder");
        }

        public bool InsertContainerScanCode(string scanCode)
        {
            return FluentElement.Instance
                .Wait(1)
                .SwitchToIframe(Iframe)
                .WaitForElement(ScanCodeField)
                .Insert(scanCode);
        }

        public bool IsContainerValidationPopupDisplayed()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ContainerValidationPopup)
                .IsVisible();
        }

        public string GetValidationPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ValidationMessage)
                .GetText();
        }

        public bool ClickValidationPopupOkButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ValidationOkButton)
                .Click();
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            return buttonToBeClicked switch
            {
                "Add" => ClickAddButton(),
                "Update" => ClickUpdateButton(),
                "Close" => ClickCloseButton(),
                _ => false
            };
        }

        private static bool ClickAddButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(AddButton)
                .Click();
        }

        private static bool ClickUpdateButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(UpdateButton)
                .Click();
        }

        private static bool ClickCloseButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(CloseButton)
                .Click();
        }

        private AddNewContainerPopup() { }

        private static readonly Lazy<AddNewContainerPopup> Singleton =
            new Lazy<AddNewContainerPopup>(() => new AddNewContainerPopup());
    }
}
