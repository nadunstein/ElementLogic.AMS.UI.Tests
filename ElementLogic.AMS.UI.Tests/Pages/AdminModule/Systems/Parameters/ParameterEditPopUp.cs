using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.Parameters
{
    public class ParameterEditPopup
    {
        private const string Iframe = "iframe";

        private const string ValueCheckBox =
            "#ctl00_content_AddEditParameterView1_BooleanFieldBox_InputTemplateItem_BooleanCheckBox";

        private const string ValueDropDown = 
            "#ctl00_content_AddEditParameterView1_EnumFieldBox_InputTemplateItem_EnumDropDownList";

        private const string ValueTextArea =
            "#ctl00_content_AddEditParameterView1_StringFieldBox_InputTemplateItem_StringTextBox";

        private const string ValueTextField =
            "#ctl00_content_AddEditParameterView1_NumberFieldBox_InputTemplateItem_StringTextBox";

        private const string SaveButton = "#ctl00_content_AddEditParameterView1_BtnSave";

        public static ParameterEditPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public bool InsertTextFieldValue(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ValueTextField)
                .Insert(value);
        }

        public bool ChangeParameterValue(string parameterValue)
        {
            if (FluentElement.Instance
                .SwitchToIframe(Iframe)
                .IsVisible(ValueCheckBox))
            {
                return SelectTheCheckBox();
            }
            
            if (FluentElement.Instance
                .SwitchToIframe(Iframe)
                .IsVisible(ValueDropDown))
            {
                return SetDropdownValue(parameterValue);
            }
            
            if (FluentElement.Instance
                .SwitchToIframe(Iframe)
                .IsVisible(ValueTextArea))
            {
                return EnterTextAreaValue(parameterValue);
            }
            
            if (FluentElement.Instance
                .SwitchToIframe(Iframe)
                .IsVisible(ValueTextField))
            {
                return InsertTextFieldValue(parameterValue);
            }

            return false;
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(SaveButton)
                .Click();
        }

        private static bool SetDropdownValue(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ValueDropDown)
                .SelectDropDown(value);
        }

        private static bool EnterTextAreaValue(string value)
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ValueTextArea)
                .Insert(value);
        }

        private static bool SelectTheCheckBox()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ValueCheckBox)
                .Click();
        }

        private ParameterEditPopup() { }

        private static readonly Lazy<ParameterEditPopup> Singleton =
            new Lazy<ParameterEditPopup>(() => new ParameterEditPopup());
    }
}
