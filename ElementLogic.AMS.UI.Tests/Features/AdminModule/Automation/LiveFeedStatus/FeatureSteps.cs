using System;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AutoStoreLiveFeedStatus =
    ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus.LiveFeedStatus;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Automation.LiveFeedStatus
{
    [Binding]
    public class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Given(@"I navigate to Autostore Equipment List page")]
        public void GivenINavigateToAutostoreEquipmentListPage()
        {
            AutostoreEquipmentList.Instance.Navigate();
            Assert.IsTrue(AutostoreEquipmentList.Instance.IsPageLoaded(),
                "THe Autostore Equipment List page is not loaded");
        }

        [When(@"I select the Autostore equipment as '(.*)' in Autostore Equipment List page")]
        public void WhenISelectTheAutostoreEquipmentAsInAutostoreEquipmentListPage(string equipmentToBeSelected)
        {
            Assert.IsTrue(AutostoreEquipmentList.Instance.SelectAutostoreEquipment(equipmentToBeSelected),
                $"Unable to select the Autostore equipment as '{equipmentToBeSelected}' in Autostore Equipment List page");
        }

        [Given(@"I navigate to Live feed status page")]
        public void GivenINavigateToLiveFeedStatusPage()
        {
            AutoStoreLiveFeedStatus.Instance.Navigate();
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.IsPageLoaded(),
                "The Autostore equipment list - Live feed status page is NOT loaded");
        }

        [Then(@"The Live feed status page is loaded")]
        public void ThenTheLiveFeedStatusPageIsLoaded()
        {
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.IsPageLoaded(),
                "The Autostore equipment list - Live feed status page is NOT loaded");
        }

        [When(@"I select '(.*)' option from the Gear action menu in Live feed status page")]
        public void WhenISelectOptionFromTheGearActionMenuInLiveFeedStatusPage(string option)
        {
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.SelectActionDropDownOption(option),
                "The Action DropDown is not selectable in Live feed status page");
        }

        [Then(@"The Synchronize bin contents popup is displayed in Live feed status page")]
        public void ThenTheSynchronizeBinContentsPopupIsDisplayedInLiveFeedStatusPage()
        {
            Assert.IsTrue(SynchronizeBinContentsPopup.Instance.IsPopupDisplayed(),
                "Synchronize bin contents popUp is not displayed in Live feed status page");
        }

        [Then(@"I click on Synchronize button on Synchronize bin contents popup in Live feed status page")]
        public void ThenIClickOnSynchronizeButtonOnSynchronizeBinContentsPopupInLiveFeedStatusPage()
        {
            Assert.IsTrue(SynchronizeBinContentsPopup.Instance.ClickSynchronizeButton(),
                "Unable to click on Synchronize button on Synchronize bin contents popup in Live feed status page");
        }

        [Then(@"I verify '(.*)' action is listed on Live feed table in Live Feed Status page")]
        public void ThenIVerifyActionIsListedOnLiveFeedTableInLiveFeedStatusPage(string liveFeedAction)
        {
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.IsLiveFeedActionListed(liveFeedAction),
                $"The '{liveFeedAction}' action is not listed on Live feed table in Live Feed Status page");
        }

        [When(@"I click on Show/hide responses button in Live Feed Status page")]
        public void WhenIClickOnShowHideResponsesButtonInLiveFeedStatusPage()
        {
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.ClickShowHideResponsesButton(),
                "Unable to click on Show/hide responses button in Live Feed Status page");
        }

        [Then(@"The '(.*)' live feed Response is displayed on Live feed table in Live Feed Status page")]
        public void ThenTheLiveFeedResponseIsDisplayedOnLiveFeedTableInLiveFeedStatusPage(string liveFeedAction)
        {
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.IsLiveFeedResponseDisplayed(liveFeedAction),
                $"The '{liveFeedAction}' live feed Response is not displayed on Live feed table in Live Feed Status page");
        }

        [Then(@"I verify the '(.*)' for '(.*)' action with following details on Live feed table in Live Feed Status page:")]
        public void ThenIVerifyTheForActionWithFollowingDetailsOnLiveFeedTableInLiveFeedStatusPage(string liveFeedActionMessageType, string liveFeedAction, Table table)
        {
            var xmlRecords = table.CreateDynamicSet();
            foreach (var xmlRecord in xmlRecords)
            {
                var expectedString = GetExpectedLiveFeedActionMessageTagValue(liveFeedActionMessageType, xmlRecord);
                Assert.IsTrue(
                    AutoStoreLiveFeedStatus.Instance.GetLiveFeedMessage(liveFeedActionMessageType, liveFeedAction)
                        .Contains(expectedString),
                    $"The '{liveFeedAction}' '{liveFeedActionMessageType}' is not generated with the '{expectedString}' value in LiveFeed status page");
            }
        }

        private string GetExpectedLiveFeedActionMessageTagValue(string liveFeedActionMessageType, dynamic xmlRecord)
        {
            string tagName = Convert.ToString(xmlRecord.TagName);
            string tagValue;
            if (Convert.ToString(xmlRecord.Value).Contains("Key"))
            {
                var contextKey = Convert.ToString(xmlRecord.Value).Split('[', ']')[1];
                tagValue = _scenarioContext[contextKey];
            }

            else
            {
                tagValue = Convert.ToString(xmlRecord.Value);
            }

            var expectedString = liveFeedActionMessageType switch
            {
                "Request" => $"{tagName}='{tagValue.ToLower()}'",
                "Response" => $"<{tagName}>{tagValue.ToLower()}</{tagName}>",
                _ => null
            };

            return expectedString;
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
