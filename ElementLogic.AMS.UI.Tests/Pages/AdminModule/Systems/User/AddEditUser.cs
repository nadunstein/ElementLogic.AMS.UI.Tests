using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.User
{
    public class AddEditUser
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_Label2";

        private const string UsernameField =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_txtUserName_TextboxControl";

        private const string FirstNameField =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_txtFirstName_TextboxControl";

        private const string LastNameField =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_txtLastName_TextboxControl";

        private const string PasswordField =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_flbPassword_InputTemplateItem_txtPassword";

        private const string ConfirmPasswordField =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_flbConfirmPassword_InputTemplateItem_txtConfirmPassword";

        private const string ActivateCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_chkActive";

        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_rtbTopBar li:nth-child(1) .rtbText";

        private const string CancelButton =
            "#ctl00_ContentPlaceHolderContent_AddEditUserView1_rtbTopBar li:nth-child(4) .rtbText";

        public static AddEditUser Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Add/Edit user");
        }

        public bool InsertUsername(string value)
        {
            return FluentElement.Instance
                .WaitForElement(UsernameField)
                .Insert(value);
        }

        public bool InsertFirstName(string value)
        {
            return FluentElement.Instance
                .WaitForElement(FirstNameField)
                .Insert(value);
        }

        public bool InsertLastName(string value)
        {
            return FluentElement.Instance
                .WaitForElement(LastNameField)
                .Insert(value);
        }

        public bool InsertPassword(string value)
        {
            return FluentElement.Instance
                .WaitForElement(PasswordField)
                .Insert(value);
        }

        public bool InsertConfirmPassword(string value)
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmPasswordField)
                .Insert(value);
        }

        public bool SelectActivateCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(ActivateCheckBox)
                .Click();
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool ClickCancelButton()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(CancelButton)
                .Click();
        }

        private AddEditUser() { }

        private static readonly Lazy<AddEditUser> Singleton = new Lazy<AddEditUser>(() => new AddEditUser());
    }
}
