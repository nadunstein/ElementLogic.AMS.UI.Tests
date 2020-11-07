using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AdminOrderTypes = ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.OrderTypes.OrderTypes;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Systems.OrderTypes
{
    [Binding]
    public class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Given(@"I navigate to Order Types page")]
        public void GivenINavigateToOrderTypesPage()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            AdminOrderTypes.Instance.Navigate();
            Assert.IsTrue(AdminOrderTypes.Instance.IsPageLoaded(),
                "The Order Type page is not loaded");
        }

        [When(@"I click on Add button in Order Types page")]
        public void WhenIClickOnAddButtonInOrderTypesPage()
        {
            Assert.IsTrue(AdminOrderTypes.Instance.ClickAddButton(),
                "Unable to click on Add button in Order Types page");
        }

        [Then(@"The Add row is displayed in Order Types page")]
        public void ThenTheAddRowIsDisplayedInOrderTypesPage()
        {
            Assert.IsTrue(AdminOrderTypes.Instance.IsAddRowDisplayed(),
                "The Add row is not displayed in Order Types page");
        }

        [Then(@"I enter values to the fields in adding row in Order Types page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddingRowInOrderTypesPageAsFollows(Table table)
        {
            var orderTypeDetails = table.CreateDynamicSet();
            foreach (var orderTypeDetail in orderTypeDetails)
            {
                switch (orderTypeDetail.FieldName)
                {
                    case "OrderTypeId":
                        Assert.IsTrue(AdminOrderTypes.Instance.InsertOrderTypeId(orderTypeDetail.Value.ToString()),
                            "Unable to insert Code in adding row on the search result grid in Edit task page");
                        break;

                    case "OrderTypeText":
                        Assert.IsTrue(AdminOrderTypes.Instance.InsertOrderTypeText(orderTypeDetail.Value),
                            "Unable to insert Name in adding row on the search result grid in Edit task page");
                        break;
                }
            }
        }

        [When(@"I click on Save button in Order Types page")]
        public void WhenIClickOnSaveButtonInOrderTypesPage()
        {
            Assert.IsTrue(AdminOrderTypes.Instance.ClickSaveButton(),
                "Unable to click on Save button in Order Types page");
        }

        [Then(@"The newly added '(.*)' order type is listed in Order Types page")]
        public void ThenTheNewlyAddedOrderTypeIsListedInOrderTypesPage(string orderType)
        {
            Assert.IsTrue(AdminOrderTypes.Instance.IsNewOrderTypeAdded(orderType),
                $"The newly added '{orderType}' order type is listed in Order Types page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
