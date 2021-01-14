using NUnit.Framework;
using TechTalk.SpecFlow;
using PicklistSearchPage = ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch.PicklistSearch;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Pick.PicklistSearch
{
    [Binding]
    public sealed class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Given(@"I navigate to Picklist Search page")]
        public void GivenINavigateToPicklistSearchPageInAdminModule()
        {
            PicklistSearchPage.Instance.Navigate();
            Assert.IsTrue(PicklistSearchPage.Instance.IsPageLoaded(),
                "The Picklist Search page is not loaded");
        }

        [Then(@"I include a picklist Id to the picklistId field in Picklist Search page")]
        public void ThenIIncludeAPicklistIdToThePicklistIdFieldInPicklistSearchPage()
        {
            var picklistId = _scenarioContext["PicklistId"].ToString();
            Assert.IsTrue(PicklistSearchPage.Instance.InsertPicklistId(picklistId),
                $"Unable to include a picklist Id as {picklistId} to the picklistId field in Picklist Search page");
        }

        [When(@"I click on Search button in Picklist Search page")]
        public void WhenIClickOnSearchButtonInPicklistSearchPage()
        {
            Assert.IsTrue(PicklistSearchPage.Instance.ClickSearchButton(),
                "Unable to click on Search button in Picklist Search page");
        }

        [Then(@"The pick order is displayed in the search grid in Picklist Search page")]
        public void ThenThePickOrderIsDisplayedInTheSearchGridInPicklistSearchPage()
        {
            Assert.IsTrue(PicklistSearchPage.Instance.IsFirstPicklistResultBarDisplayed(),
                "The pick order is not displayed in the search grid in Picklist Search page");
        }

        [When(@"I click on '(.*)' option by selecting the gear icon of the pick order in the search grid in Picklist Search page")]
        public void WhenIClickOnOptionBySelectingTheGearIconOfThePickOrderInTheSearchGridInPicklistSearchPage(string optionToBeSelected)
        {
            Assert.IsTrue(PicklistSearchPage.Instance.SelectActionMenuOption(optionToBeSelected),
                $"Unable to click on the '{optionToBeSelected}' option by selecting the gear icon of the pick order in the search grid in Picklist Search page");
        }

        [Then(@"I verify the order status is '(.*)' for the pick order in the search grid in Picklist Search page")]
        public void ThenIVerifyTheOrderStatusIsForThePickOrderInTheSearchGridInPicklistSearchPage(string expectedPickOrderStatus)
        {
            Assert.AreEqual(expectedPickOrderStatus, PicklistSearchPage.Instance.GetPickOrderStatus(),
                "The order status is wrong for the pick order in the search grid in Picklist Search page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
