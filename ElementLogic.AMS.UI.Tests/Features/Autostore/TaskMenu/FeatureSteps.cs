using System;
using System.Threading;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu;
using NUnit.Framework;
using TechTalk.SpecFlow;
using PickNoMoreTasksPopup = ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick.NoMoreTasksPopup;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.TaskMenu
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"The Autostore task Menu is loaded")]
        public void ThenTheAutostoreTaskMenuIsLoaded()
        {
            ExitFromPickActivity();
            Assert.IsTrue(AutostoreTaskMenu.Instance.IsPageLoaded(),
                "The Autostore task Menu is not displayed");
        }

        [When(@"I click on '(.*)' putaway tile in AutoStore Main Menu")]
        [Then(@"I click on '(.*)' putaway tile in AutoStore Main Menu")]
        public void WhenIClickOnPutawayTileInAutoStoreMainMenu(string putawayTileName)
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickPutawayTaskType(putawayTileName),
                "Unable to Click on Putaway tile in AutoStore Main Menu");
        }

        [When(@"I click on '(.*)' pick task type in AutoStore Main Menu")]
        public void WhenIClickOnPickTaskTypeInAutoStoreMainMenu(string pickTaskType)
        {
            RetryPickWhileSuccess(TryPick, pickTaskType, 10);
        }

        [Then(@"I verify the prepared taskgroup count is '(.*)' for '(.*)' pick task type in AutoStore Main Menu")]
        public void ThenIVerifyThePreparedTaskgroupCountIsForPickTaskTypeInAutoStoreMainMenu(int taskgroupCount, string pickTaskType)
        {
            var isPickTaskgroupPreparedCountCorrect =
                RetryPreparePickWhileSuccess(TryPreparePickActivities, taskgroupCount, pickTaskType, 10);
            Assert.IsTrue(isPickTaskgroupPreparedCountCorrect,
                $"The prepared pick taskgroup count is wrong for {pickTaskType} in AutoStore task menu");
        }

        [When(@"I Click on Inspection tile in AutoStore Main Menu")]
        public void GivenIClickOnInspectionTileInAutoStoreMainMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickInventoryTaskType("Inspection"),
                "Unable to Click on Inspection tile in AutoStore Main Menu");
        }

        [When(@"I Click on Inventory tile in AutoStore Main Menu")]
        public void GivenIClickOnInventoryTileInAutoStoreMainMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickInventoryTaskType("Inventory"),
                "Unable to Click on Inventory tile in AutoStore Main Menu");
        }

        [When(@"I Click on Refill tile in Autostore main menu")]
        public void WhenIClickOnRefillTileInAutostoreMainMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickInventoryTaskType("Refill"),
                "Unable to Click on Refill tile in AutoStore Main Menu");
        }

        [When(@"I click on Logout button in Autostore task menu")]
        public void WhenIClickOnLogoutButtonInAutostoreTaskMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickLogout(),
                "Unable to click on Logout button in Autostore task menu");
        }

        private static bool TryPick(string pickTaskType)
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickPickTaskType(pickTaskType),
                "Unable to Click on Pick task type in AutoStore Main Menu");
            if (PickNoMoreTasksPopup.Instance.IsPopupLoaded())
            {
                if (PickNoMoreTasksPopup.Instance.IsOkButtonDisplayed())
                {
                    PickNoMoreTasksPopup.Instance.ClickOkButton();
                    AutostoreTaskMenu.Instance.IsPageLoaded();
                    return false;
                }

                Assert.IsTrue(NewOrderPopup.Instance.ClickOkButton(), "Unable to click OK button in New order popup");
                return true;
            }

            PickMission.Instance.ClickExitButton();
            return false;
        }

        private static void RetryPickWhileSuccess(Func<string, bool> retryAction, string parameter, int noOfAttempts)
        {
            for (var i = 0; i < noOfAttempts; i++)
            {
                var result = retryAction(parameter);
                if (result)
                    return;
            }

            Assert.Fail("Pick order is not prepared");
        }

        private static bool TryPreparePickActivities(int taskgroupCount, string pickTaskType)
        {
            if (AutostoreTaskMenu.Instance.IsPreparedPickTaskgroupCountDisplayed(pickTaskType))
            {
                var actualTaskgroupPreparedCountString = AutostoreTaskMenu.Instance.GetPreparedPickTaskgroupCount(pickTaskType);
                var expectedTaskgroupPreparedCountString = $"{taskgroupCount} / {taskgroupCount}";
                if (actualTaskgroupPreparedCountString == expectedTaskgroupPreparedCountString)
                {
                    return true;
                }

                PickNoMoreTasksPopup.Instance.ClickOkButton();
                AutostoreTaskMenu.Instance.IsPageLoaded();
                AutostoreTaskMenu.Instance.ClickPickTaskType(pickTaskType);
                PickNoMoreTasksPopup.Instance.IsPopupLoaded();
                PickMission.Instance.ClickExitButton();
                return false;
            }

            AutostoreTaskMenu.Instance.ClickPickTaskType(pickTaskType);
            PickNoMoreTasksPopup.Instance.IsPopupLoaded();
            PickMission.Instance.ClickExitButton();
            return false;
        }

        private static bool RetryPreparePickWhileSuccess(Func<int, string, bool> retryAction, int taskgroupCount, 
            string pickTaskType, int noOfAttempts)
        {
            for (var i = 0; i < noOfAttempts; i++)
            {
                var result = retryAction(taskgroupCount, pickTaskType);
                if (result)
                    return true;
            }

            return false;
        }

        private static void ExitFromPickActivity()
        {
            for (var i = 0; i < 20; i++)
            {
                var noMoreTasksPopupDisplayed = PickNoMoreTasksPopup.Instance.IsPopupDisplayed();
                var autoStoreTaskMenuDisplayed = AutostoreTaskMenu.Instance.IsPageDisplayed();
                var refillTaskgroupSelectionPageDisplayed = RefillTaskgroupSelection.Instance.IsPageDisplayed();

                if (noMoreTasksPopupDisplayed)
                {
                    Assert.IsTrue(PickNoMoreTasksPopup.Instance.ClickOkButton(),
                        "Unable to click OK button on No more pick task popup after the pick activity");
                    Assert.IsTrue(AutostoreTaskMenu.Instance.IsPageLoaded(),
                        "The Autostore task Menu is not loaded");
                    break;
                }

                if (refillTaskgroupSelectionPageDisplayed)
                {
                    Assert.IsTrue(RefillTaskgroupSelection.Instance.ClickExitButton());
                    Assert.IsTrue(AutostoreTaskMenu.Instance.IsPageLoaded(),
                        "The Autostore task Menu is not loaded");
                    break;
                }

                if (autoStoreTaskMenuDisplayed)
                {
                    break;
                }

                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }
    }
}
