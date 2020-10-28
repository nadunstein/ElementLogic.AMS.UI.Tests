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
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, userListPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool IsResultTableDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(ResultTable, true);
        }

        public bool IsNewUserAdded(string user)
        {
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, user);
        }

        private UserList() { }

        private static readonly Lazy<UserList> Singleton = new Lazy<UserList>(() => new UserList());
    }
}
