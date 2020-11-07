using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.User;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Systems.User
{
    [Binding]
    public class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Given(@"I navigate to User list page")]
        public void GivenINavigateToUserListPage()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            UserList.Instance.Navigate();
            Assert.IsTrue(UserList.Instance.IsPageLoaded(),
                "The User List page is NOT loaded");
        }

        [When(@"I click on Add button in User list page")]
        public void WhenIClickOnAddButtonInUserListPage()
        {
            Assert.IsTrue(UserList.Instance.ClickAddButton(), "Unable to click on Add button in User list page");
        }

        [Then(@"Add/Edit user page is loaded")]
        public void ThenAddEditUserPageIsLoaded()
        {
            Assert.IsTrue(AddEditUser.Instance.IsPageLoaded(),
                "The Add/Edit user page is NOT loaded");
        }

        [Then(@"I enter values to the fields in Add/Edit User page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddEditUserPageAsFollows(Table table)
        {
            var userDetails = table.CreateDynamicSet();
            foreach (var userDetail in userDetails)
            {
                switch (userDetail.FieldName)
                {
                    case "Username":
                        Assert.IsTrue(AddEditUser.Instance.InsertUsername(userDetail.Value),
                            "Unable to insert Username to the fields in Add/Edit User page");
                        break;

                    case "First name":
                        Assert.IsTrue(AddEditUser.Instance.InsertFirstName(userDetail.Value),
                            "Unable to insert FirstName to the fields in Add/Edit User page");
                        break;

                    case "Last name":
                        Assert.IsTrue(AddEditUser.Instance.InsertLastName(userDetail.Value),
                            "Unable to insert LastName to the fields in Add/Edit User page");
                        break;

                    case "Password":
                        Assert.IsTrue(AddEditUser.Instance.InsertPassword(userDetail.Value.ToString()),
                            "Unable to insert Password to the fields in Add/Edit User page");
                        break;

                    case "Confirm password":
                        Assert.True(AddEditUser.Instance.InsertConfirmPassword(userDetail.Value.ToString()),
                            "Unable to insert ConfirmPassword to the fields in Add/Edit User page");
                        break;

                    case "Activate":
                        if (userDetail.Value)
                        {
                            Assert.IsTrue(AddEditUser.Instance.SelectActivateCheckBox(),
                                "Unable to select Activate CheckBox to the fields in Add/Edit User page");
                        }
                        break;
                }
            }
        }

        [Then(@"I click on Save button in Add/Edit user page")]
        public void ThenIClickOnSaveButtonInAddEditUserPage()
        {
            Assert.IsTrue(AddEditUser.Instance.ClickSaveButton(),
                "Unable to click on Save button in Add/Edit user page");
        }

        [When(@"I click on Cancel button in Add/Edit user page")]
        public void WhenIClickOnCancelButtonInAddEditUserPage()
        {
            Assert.IsTrue(AddEditUser.Instance.ClickCancelButton(),
                "Unable to click on Cancel button in Add/Edit user page");
        }
        [Then(@"User list page is loaded")]
        public void ThenUserListPageIsLoaded()
        {
            Assert.IsTrue(UserList.Instance.IsPageLoaded(),
                "The User List page is NOT loaded");
        }

        [Then(@"The newly added '(.*)' User is listed in the search result grid in User list page")]
        public void ThenTheNewlyAddedUserIsListedInTheSearchResultGridInUserListPage(string user)
        {
            Assert.True(UserList.Instance.IsResultTableDisplayed(),
                "The user result table is not displayed in User list page");
            Assert.True(UserList.Instance.IsNewUserAdded(user),
                $"The newly added '{user}' user is NOT listed in the search result grid in User list page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
