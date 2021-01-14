using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.TaskTypes;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AdminTaskTypes = ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.TaskTypes.TaskTypes;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Systems.TaskTypes
{
    [Binding]
    public sealed class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Given(@"I navigate to Task Types page")]
        public void GivenINavigateToTaskTypesPage()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            AdminTaskTypes.Instance.Navigate();
            Assert.IsTrue(AdminTaskTypes.Instance.IsPageLoaded(),
                "The Admin Task Types page is not loaded");
        }

        [Then(@"The Task Type\(s\) are listed in the search result grid in Task Types page")]
        public void ThenTheTaskTypeSAreListedInTheSearchResultGridInTaskTypesPage()
        {
            Assert.True(AdminTaskTypes.Instance.IsFirstSearchResultRowDisplayed(),
                "The Task Type(s) are NOT listed in the search result grid in Task Types page");
        }

        [When(@"I click on Add button in Task Types List page")]
        public void WhenIClickOnAddButtonInTaskTypesListPage()
        {
            Assert.IsTrue(AdminTaskTypes.Instance.ClickAddButton(),
                "Unable to click on Add button in Task Types List page");
        }

        [Then(@"The Edit task page is loaded")]
        public void ThenTheEditTaskPageIsLoaded()
        {
            Assert.IsTrue(EditTask.Instance.IsPageLoaded(), "The Admin Edit task page is NOT loaded");
        }

        [Then(@"I enter values to the fields in adding row on the search result grid in Edit task page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddingRowOnTheSearchResultGridInEditTaskPageAsFollows(Table table)
        {
            var taskTypeDetails = table.CreateDynamicSet();
            foreach (var taskTypeDetail in taskTypeDetails)
            {
                switch (taskTypeDetail.FieldName)
                {
                    case "Code":
                        Assert.IsTrue(EditTask.Instance.InsertCode(taskTypeDetail.Value.ToString()),
                            "Unable to insert Code in adding row on the search result grid in Edit task page");
                        break;

                    case "Name":
                        Assert.IsTrue(EditTask.Instance.InsertName(taskTypeDetail.Value),
                            "Unable to insert Name in adding row on the search result grid in Edit task page");
                        break;

                    case "Priority":
                        Assert.IsTrue(EditTask.Instance.InsertPriority(taskTypeDetail.Value.ToString()),
                            "Unable to insert Priority in adding row on the search result grid in Edit task page");
                        break;

                    case "Min Queue Length":
                        Assert.IsTrue(EditTask.Instance.InsertMinQueueLength(taskTypeDetail.Value.ToString()),
                            "Unable to insert MinQueueLength in adding row on the search result grid in Edit task page");
                        break;

                    case "Max Queue Length":
                        Assert.IsTrue(EditTask.Instance.InsertMaxQueueLength(taskTypeDetail.Value.ToString()),
                            "Unable to insert MaxQueueLength in adding row on the search result grid in Edit task page");
                        break;

                    case "SQL":
                        Assert.IsTrue(EditTask.Instance.InsertSql(taskTypeDetail.Value),
                            "Unable to insert Sql in adding row on the search result grid in Edit task page");
                        break;

                    case "Sequence":
                        Assert.IsTrue(EditTask.Instance.InsertSequence(taskTypeDetail.Value.ToString()),
                            "Unable to insert Sequence in adding row on the search result grid in Edit task page");
                        break;

                    case "Shipment":
                        Assert.IsTrue(EditTask.Instance.InsertShipment(taskTypeDetail.Value.ToString()),
                            "Unable to insert Shipment in adding row on the search result grid in Edit task page");
                        break;

                    case "Activity Type":
                        Assert.IsTrue(EditTask.Instance.SelectActivityType(taskTypeDetail.Value),
                            "Unable to insert ActivityType in adding row on the search result grid in Edit task page");
                        break;
                }
            }
        }

        [When(@"I click on Save button in Edit task page")]
        public void WhenIClickOnSaveButtonInEditTaskPage()
        {
            Assert.IsTrue(EditTask.Instance.ClickSaveButton(), "Unable to click on Save button in Edit task page");
        }

        [Then(@"The Task types page is loaded")]
        public void ThenTheTaskTypesPageIsLoaded()
        {
            Assert.IsTrue(AdminTaskTypes.Instance.IsPageLoaded(),
                "The Admin Task Types page is NOT loaded");
        }

        [Then(@"The newly added '(.*)' Task Type is listed in the search result grid in Task Type List page")]
        public void ThenTheNewlyAddedTaskTypeIsListedInTheSearchResultGridInTaskTypeListPage(string taskType)
        {
            Assert.True(AdminTaskTypes.Instance.IsFirstSearchResultRowDisplayed(),
                "The Task Type result table is NOT displayed in Task Type List page");
            Assert.True(AdminTaskTypes.Instance.IsNewTaskTypeAdded(taskType),
                $"The newly added '{taskType}' Location Type is NOT listed in the search result grid in Location Type List page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
