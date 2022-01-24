using System.Collections.Generic;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.UserActivity;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UserActivityPage = ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.UserActivity.UserActivity;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.UserActivity
{
    [Binding]
    public sealed class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string _finishedMissionId;
        private IList<UserActivityMissionData> _missionsDataBeforeFinish;

        [Given(@"I navigate to User Activity page")]
        public void GivenINavigateToUserActivityPage()
        {
            UserActivityPage.Instance.Navigate();
            Assert.IsTrue(UserActivityPage.Instance.IsPageLoaded(),
                "The User Activity page is not loaded");
        }

        [Then(@"I include picklist id to the Pick list ID field in User Activity page")]
        public void ThenIIncludePicklistIdToThePickListIdFieldInUserActivityPage()
        {
            var picklistId = _scenarioContext["PicklistId"].ToString();
            Assert.IsTrue(UserActivityPage.Instance.InsertPicklistId(picklistId),
                "Unable to include picklist id to the Pick list ID field in User Activity page");
        }

        [Then(@"I Select status as '(.*)' from Status dropdown in User Activity page")]
        public void ThenISelectStatusAsFromStatusDropdownInUserActivityPage(string statusToBeSelected)
        {
            Assert.IsTrue(UserActivityPage.Instance.SelectStatus(statusToBeSelected),
                $"Unable to select status as '{statusToBeSelected}' from Status dropdown in User Activity page");
        }

        [Then(@"I include Taskgroup id to the Task group ID field in User Activity page")]
        public void ThenIIncludeTaskgroupIdToTheTaskGroupIdFieldInUserActivityPage()
        {
            var picklistId = _scenarioContext["PicklistId"].ToString();
            var taskgroupId = Mission.Instance.GetTaskGroupIdFromPicklistId(picklistId);
            Assert.IsTrue(UserActivityPage.Instance.InsertTaskgroupId(taskgroupId),
                "Unable to include Taskgroup id to the Task group ID field in User Activity page");
        }

        [When(@"I click on Search button in User Activity page")]
        public void WhenIClickOnSearchButtonInUserActivityPage()
        {
            Assert.IsTrue(UserActivityPage.Instance.ClickSearchButton(),
                "Unable to click on Search button in User Activity page");
        }

        [Then(@"The user activity is displayed in the search grid in User Activity page")]
        public void ThenTheUserActivityIsDisplayedInTheSearchGridInUserActivityPage()
        {
            Assert.IsTrue(UserActivityPage.Instance.IsFirstUserActivityResultBarDisplayed(),
                "The user activity is not displayed in the search grid in User Activity page");
        }

        [When(@"I click on '(.*)' option by selecting the gear icon of the activity in User Activity page")]
        public void WhenIClickOnOptionBySelectingTheGearIconOfTheActivityInUserActivityPage(string optionToBeSelected)
        {
            Assert.IsTrue(UserActivityPage.Instance.SelectActivityActionMenuOption(optionToBeSelected),
                $"Unable to click on '{optionToBeSelected}' option by selecting the gear icon of the activity in User Activity page");
        }

        [Then(@"The Transfer User popup is displayed in User Activity Page")]
        public void ThenTheTransferUserPopupIsDisplayedInUserActivityPage()
        {
            Assert.IsTrue(TransferUserPopup.Instance.IsPopupDisplayed(),
                "The Transfer User popup is displayed in User Activity Page");
        }

        [Then(@"I select transfer user as '(.*)' from Transfer user dropdown in Transfer User popup in User Activity Page")]
        public void ThenISelectTransferUserAsFromTransferUserDropdownInTransferUserPopupInUserActivityPage(string userToBeSelected)
        {
            Assert.IsTrue(TransferUserPopup.Instance.SelectTransferUser(userToBeSelected),
                $"Unable to select transfer user as '{userToBeSelected}' from Transfer user dropdown in Transfer User popup in User Activity Page");
        }

        [When(@"I click on '(.*)' button in Transfer User popup in User Activity Page")]
        public void WhenIClickOnButtonInTransferUserPopupInUserActivityPage(string buttonToBeClicked)
        {
            Assert.IsTrue(TransferUserPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to click on '{buttonToBeClicked}' button in Transfer User popup in User Activity Page");
        }

        [Then(@"I verify the UserCode of the activity is displayed as '(.*)' in User Activity page")]
        public void ThenIVerifyTheUserCodeOfTheActivityIsDisplayedAsInUserActivityPage(string expectedUserName)
        {
            Assert.AreEqual(expectedUserName, UserActivityPage.Instance.GetFirstActivityUserCode(),
                "The transferred user code for the activity is different in User Activity page");
        }

        [When(@"I click on '(.*)' option by selecting the gear icon of the mission for the user activity in status '(.*)' in User Activity page")]
        public void WhenIClickOnOptionBySelectingTheGearIconOfTheMissionForTheUserActivityInStatusInUserActivityPage(string optionToBeSelected, string missionStatus)
        {
            Assert.IsTrue(UserActivityPage.Instance.ExpandActivityMissions(),
                "Unable to click on mission expander for the user activity in User Activity page");
            _missionsDataBeforeFinish = UserActivityPage.Instance.GetActivityMissionData();
            _finishedMissionId = UserActivityPage.Instance.GetMissionIdToBeFinished(missionStatus);

            Assert.IsTrue(UserActivityPage.Instance.SelectActivityMissionActionMenuOption(missionStatus, optionToBeSelected),
                $"Unable to click on '{optionToBeSelected}' option by selecting the gear icon of the mission for the user activity in status '{missionStatus}' in User Activity page");
        }

        [Then(@"The Started Missions popup is displayed in User Activity Page")]
        public void ThenTheStartedMissionsPopupIsDisplayedInUserActivityPage()
        {
            Assert.IsTrue(StartedMissionsPopup.Instance.IsPopupDisplayed(),
                "The Started Missions popup is not displayed in User Activity Page");
            const string expectedPopupMessage = "Some of the missions selected are already started. Do you want to proceed?";
            Assert.AreEqual(expectedPopupMessage, StartedMissionsPopup.Instance.GetPopupMessage(),
                "The Started Missions popup message is wrong in User Activity Page");
        }

        [When(@"I click on '(.*)' button on Started Missions popup in User Activity Page")]
        public void WhenIClickOnButtonOnStartedMissionsPopupInUserActivityPage(string buttonToBeClicked)
        {
            Assert.IsTrue(StartedMissionsPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to Click on {buttonToBeClicked} button on Started Missions popup in User Activity Page");
        }

        [Then(@"I verify the mission statuses are correct in User Activity page")]
        public void ThenIVerifyTheMissionStatusesAreCorrectInUserActivityPage()
        {
            var expectedMissionsData = _missionsDataBeforeFinish.Select(missionDataBeforeFinish =>
                new UserActivityMissionData
                {
                    Id = missionDataBeforeFinish.Id,
                    Status = missionDataBeforeFinish.Id == _finishedMissionId
                        ? "17 - Completed"
                        : missionDataBeforeFinish.Status
                }).ToList();

            Assert.IsTrue(UserActivityPage.Instance.ExpandActivityMissions(),
                "Unable to click on mission expander for the user activity in User Activity page");
            var actualMissionsData = UserActivityPage.Instance.GetActivityMissionData();

            foreach (var expectedMissionData in expectedMissionsData)
            {
                foreach (var actualMissionData in actualMissionsData)
                {
                    if (expectedMissionData.Id != actualMissionData.Id)
                    {
                        continue;
                    }

                    Assert.AreEqual(expectedMissionData.Status, actualMissionData.Status,
                        $"The expected mission status after finishing is wrong for {actualMissionData.Id} in  User Activity page");
                    break;
                }
            }
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
