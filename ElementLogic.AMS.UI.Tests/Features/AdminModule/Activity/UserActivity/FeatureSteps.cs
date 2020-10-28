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
    public class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string _finishedMissionId;
        private IList<UserActivityMissionData> _missionsDataBeforeFinish;

        [Given(@"I navigate to User Activity page")]
        public void GivenINavigateToUserActivityPage()
        {
            UserActivityPage.Instance.Navigate();
        }

        [Then(@"The User Activity page is loaded")]
        public void ThenTheUserActivityPageIsLoaded()
        {
            Assert.AreEqual("User activity search", UserActivityPage.Instance.GetPageTitle(),
                "The User Activity page is not loaded");
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

        [When(@"I click on '(.*)' option by selecting the gear icon of the mission for the user activity in status '(.*)' in User Activity page")]
        public void WhenIClickOnOptionBySelectingTheGearIconOfTheMissionForTheUserActivityInStatusInUserActivityPage(string optionToBeSelected, string missionStatus)
        {
            _missionsDataBeforeFinish = UserActivityPage.Instance.GetActivityMissionData();
            _finishedMissionId =
                UserActivityPage.Instance.SelectActivityMissionActionMenuOptionAndGetMissionId(missionStatus,
                    optionToBeSelected);

            Assert.IsNotNull(_finishedMissionId,
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
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => StartedMissionsPopup.Instance.ClickYesButton(),
                "No" => StartedMissionsPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
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
                        $"The expected mission is wrong for {actualMissionData.Id} in  User Activity page");
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
