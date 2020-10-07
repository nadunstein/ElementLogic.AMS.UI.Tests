using System;
using ElementLogic.AMS.UI.Tests.Configuration;
using ElementLogic.AMS.UI.Tests.ExcelDataAccess.UserCredentials;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Login
{
    public class Login
    {
        private const string UserNameField = "#flbUserName_InputTemplateItem_txbUserName";

        private const string PasswordField = "#flbPassword_InputTemplateItem_txbPassword";

        private const string AdminAsLoginButton = "#btnLogin";

        public static Login Instance => Singleton.Value;

        public void NavigateToAdminModule()
        {
            PageObjectHelper.Instance.Navigate(ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url"));
        }

        public bool IsLoginPageLoaded()
        {
            return PageObjectHelper.Instance.IsDisplayed(UserNameField, true);
        }

        public void NavigateToAutoStore(string portId)
        {
            PageObjectHelper.Instance.DeleteBrowserCookies();
            var autostoreUrl = string.Concat("/as/", portId);
            string baseUrl = ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, autostoreUrl);
        }

        public void LoginToApplication(string username)
        {
            if (!PageObjectHelper.Instance.IsDisplayed(UserNameField))
            {
                return;
            }

            var userData = AccessUserCredentials.Instance.GetUserCredentials(username);
            InsertUsername(userData.Username);
            InsertPassword(userData.Password);
            ClickAdminLoginButton();
        }

        public bool InsertUsername(string username)
        {
            return PageObjectHelper.Instance.InsertField(UserNameField, username);
        }

        public bool InsertPassword(string password)
        {
            return PageObjectHelper.Instance.InsertField(PasswordField, password);
        }

        public bool ClickAdminLoginButton()
        {
            return PageObjectHelper.Instance.Click(AdminAsLoginButton);
        }

        private Login() { }

        private static readonly Lazy<Login> Singleton = new Lazy<Login>(() => new Login());
    }
}
