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
            var isPopupDisplayed =  PageObjectHelper.Instance.IsDisplayed(Iframe, true);
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return isPopupDisplayed;
        }

        public bool InsertTextFieldValue(string value)
        {
            return PageObjectHelper.Instance.InsertField(ValueTextField, value);
        }

        public bool ChangeParameterValue(string parameterValue)
        {
            if (PageObjectHelper.Instance.IsDisplayed(ValueCheckBox))
            {
                return SelectTheCheckBox();
            }
            
            if (PageObjectHelper.Instance.IsDisplayed(ValueDropDown))
            {
                return SetDropdownValue(parameterValue);
            }
            
            if (PageObjectHelper.Instance.IsDisplayed(ValueTextArea))
            {
                return EnterTextAreaValue(parameterValue);
            }
            
            if (PageObjectHelper.Instance.IsDisplayed(ValueTextField))
            {
                return InsertTextFieldValue(parameterValue);
            }

            return false;
        }

        public bool ClickSaveButton()
        {
            var isSaveButtonClicked = PageObjectHelper.Instance.Click(SaveButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isSaveButtonClicked;
        }

        private static bool SetDropdownValue(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(ValueDropDown, value);
        }

        private static bool EnterTextAreaValue(string value)
        {
            return PageObjectHelper.Instance.InsertField(ValueTextArea, value);
        }

        private static bool SelectTheCheckBox()
        {
            return PageObjectHelper.Instance.Click(ValueCheckBox);
        }

        private ParameterEditPopup() { }

        private static readonly Lazy<ParameterEditPopup> Singleton =
            new Lazy<ParameterEditPopup>(() => new ParameterEditPopup());
    }
}
