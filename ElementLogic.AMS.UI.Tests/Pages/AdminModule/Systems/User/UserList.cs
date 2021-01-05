using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.User
{
    public class UserList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_UserListView1_lblHeader";

        private const string ResultTable = ".rgMasterTable > tbody";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_UserListView1_grdUsers_ctl00_ctl02_ctl00_rtbTopBar .rtbText";

        public static UserList Instance => Singleton.Value;

        public void Navigate()
        {
            const string userListPageUrl = "/Pages/System/SearchAndListUsers.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + userListPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("User list");
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsResultTableDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(ResultTable)
                .IsVisible();
        }

        public bool IsNewUserAdded(string user)
        {
            return FluentElement.Instance
                .WaitForElement(ResultTable)
                .GetTableElements()
                .FindRowElements(3, user)
                .IsExists();
        }

        private UserList() { }

        private static readonly Lazy<UserList> Singleton = new Lazy<UserList>(() => new UserList());
    }
}
