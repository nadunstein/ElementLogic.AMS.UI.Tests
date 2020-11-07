using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Refill;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Given(@"I navigate to Refill Order List page")]
        public void GivenINavigateToRefillOrderListPage()
        {
            RefillOrderList.Instance.Navigate();
            Assert.IsTrue(RefillOrderList.Instance.IsPageLoaded(),
                "The Admin Refill Order List page is not displayed");
        }

        [Then(@"The Refill Order List page is loaded with empty records on the fields")]
        public void ThenTheRefillOrderListPageIsLoadedWithEmptyRecordsOnTheFields()
        {
            Assert.IsTrue(RefillOrderList.Instance.IsPageLoaded(),
                "The Admin Refill Order List page is not displayed");
            Assert.AreEqual("Search for trolleys...", RefillOrderList.Instance.GetTrolleyFieldValue(),
                "Trolley Field value is not empty after activating refill Order");
        }

        [Given(@"I include the '(.*)' to the scan Id field in Refill Order List page")]
        [Then(@"I include the '(.*)' of the newly created GR order to the scan Id field in Refill Order List page")]
        public void GivenIIncludeTheToTheScanIdFieldInRefillOrderListPage(string scanOption)
        {
            var scanValue = scanOption switch
            {
                "Product Id" => _scenarioContext["ExtProductId"].ToString(),
                "Producer Product Id" => _scenarioContext["ProducerProductId"].ToString(),
                "Vendor Product Id" => _scenarioContext["VenderProductId"].ToString(),
                "Purchase Id" => _scenarioContext["PurchaseId"].ToString(),
                "EAN Id" => _scenarioContext["EANId"].ToString(),
                "ScanCode" => _scenarioContext["Scancode"].ToString(),
                _ => null
            };

            Assert.IsTrue(RefillOrderList.Instance.EnterScanId(scanValue),
                $"Unable to include the {scanOption} to the scan Id field in Refill Order List page");
        }

        [Given(@"I select a trolley from Trolley drop down in Refill Order List page")]
        [Given(@"I select the same trolley from Trolley drop down in Refill Order List page")]
        public void GivenISelectATrolleyFromTrolleyDropDownInRefillOrderListPage()
        {
            var nameOfTheTrolley = TestDataFactory.Instance.GetRefillTrolleyForScenario(_scenarioContext);
            Assert.IsTrue(RefillOrderList.Instance.SelectTrolley(nameOfTheTrolley),
                "Unable to select a trolley from Trolley drop down in Refill Order List page");
        }

        [When(@"I click on Confirm button in Refill Order List page")]
        public void WhenIClickOnConfirmButtonInRefillOrderListPage()
        {
            Assert.IsTrue(RefillOrderList.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button in Refill Order List page");
        }

        [Then(@"The No\. of Items on the Trolley field value is displayed as '(.*)' in Refill Order List page")]
        public void ThenTheNo_OfItemsOnTheTrolleyFieldValueIsDisplayedAsInRefillOrderListPage(int noOfItemsOnTrolley)
        {
            var actualRefillCount = RefillOrderList.Instance.GetNumberOfItemsOnTrolley();
            Assert.AreEqual(noOfItemsOnTrolley, actualRefillCount,
                "Number of Items on refill trolley is different than the expected item count");
        }

        [When(@"I Click on View Items button in Refill Order List page")]
        public void WhenIClickOnViewItemsButtonInRefillOrderListPage()
        {
            Assert.IsTrue(RefillOrderList.Instance.ClickViewItemsButton(),
                "Unable to click on View Items button in Refill Order List page");
        }

        [Then(@"The Refill item\(s\) are listed under the grid in Refill Order List page")]
        public void ThenTheRefillItemSAreListedUnderTheGridInRefillOrderListPage()
        {
            Assert.True(RefillOrderList.Instance.IsViewItemTableDisplayed(),
                "The Refill item Grid is not displayed in Refill order list page");

            var expectedRefillProductCount = RefillOrderList.Instance.GetNumberOfItemsOnTrolley();
            var actualRefillProductCount = RefillOrderList.Instance.GetViewItemProductList().Count;
            Assert.AreEqual(expectedRefillProductCount, actualRefillProductCount,
                "The listed Refill item count is incorrect under the grid in Refill Order List page");
        }

        [Then(@"I check the correct Refill product\(s\) are displayed in the view item grid in Refill Order List page")]
        public void ThenICheckTheCorrectRefillProductSAreDisplayedInTheViewItemGridInRefillOrderListPage()
        {
            var actualRefillCount = RefillOrderList.Instance.GetNumberOfItemsOnTrolley();
            var actualProducts = RefillOrderList.Instance.GetViewItemProductList();
            string expectedProductId;

            if (actualRefillCount.Equals(1))
            {
                expectedProductId = _scenarioContext.ContainsKey("ExtProductId01")
                    ? _scenarioContext["ExtProductId01"].ToString()
                    : _scenarioContext["ExtProductId"].ToString();

                Assert.AreEqual(expectedProductId, actualProducts[0],
                    "The correct Refill product(s) are not displayed in the view item grid in Refill Order List page");
                return;
            }

            for (var i = 1; i <= actualRefillCount; i++)
            {
                expectedProductId = _scenarioContext[$"ExtProductId0{i}"].ToString();
                Assert.AreEqual(expectedProductId, actualProducts[i-1],
                    "The correct Refill product(s) are not displayed in the view item grid in Refill Order List page");
            }
        }

        [When(@"I click on Activate button in Refill Order List page")]
        public void WhenIClickOnActivateButtonInRefillOrderListPage()
        {
            Assert.IsTrue(RefillOrderList.Instance.ClickActivateButton(),
                "Unable to click on Activate button in Refill Order List page");
        }

        private CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
