using System;
using ElementLogic.AMS.UI.Tests.ExcelDataAccess.UserCredentials;
using ElementLogic.AMS.UI.Tests.Integration;
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
            var adminBaseUrl =
                JsonFileReader.Instance
                    .GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            FluentElement.Instance
                .Navigate(adminBaseUrl)
                .WaitForPageLoad();
        }

        public void NavigateToAutoStore(string portId)
        {
            FluentElement.Instance.DeleteBrowserCookies();
            var baseUrl =
                JsonFileReader.Instance
                    .GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var autostoreUrl = string.Concat("/as/", portId);
            var pageUrl = baseUrl + autostoreUrl;
            FluentElement.Instance
                .Navigate(pageUrl)
                .WaitForPageLoad();
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(UserNameField)
                .IsVisible();
        }

        public bool InsertUsername(string username)
        {
            return FluentElement.Instance
                .WaitForElement(UserNameField)
                .Insert(username);
        }

        public bool InsertPassword(string password)
        {
            return FluentElement.Instance
                .WaitForElement(PasswordField)
                .Insert(password);
        }

        public bool ClickAdminLoginButton()
        {
            return FluentElement.Instance
                .WaitForElement(AdminAsLoginButton)
                .Click();
        }

        public void LoginToApplication(string username)
        {
            if (!FluentElement.Instance
                .WaitForPageLoad()
                .IsVisible(UserNameField))
            {
                return;
            }

            var userData = AccessUserCredentials.Instance
                .GetUserCredentials(username);
            InsertUsername(userData.Username);
            InsertPassword(userData.Password);
            ClickAdminLoginButton();
        }

        private Login() { }

        private static readonly Lazy<Login> Singleton = new Lazy<Login>(() => new Login());
    }
}
