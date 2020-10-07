using System;
using System.Threading;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu;
using NUnit.Framework;
using TechTalk.SpecFlow;
using PickNoMoreTasksPopup = ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick.NoMoreTasksPopup;
using InventoryNoMoreTasksPopup = ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory.NoMoreTasksPopup;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.TaskMenu
{
    [Binding]
    public class FeatureSteps
    {
        [Then(@"The Autostore task Menu should be loaded")]
        public void ThenTheAutostoreTaskMenuShouldBeLoaded()
        {
            ExitFromActivity();
            Assert.AreEqual("AutoStore task menu", AutostoreTaskMenu.Instance.GetPageTitle(),
                "The Autostore task Menu is not loaded");
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
            RetryPickWhileSuccess(TryPick, pickTaskType, 5);
        }

        [When(@"I Click on Inspection tile in AutoStore Main Menu")]
        public void GivenIClickOnInspectionTileInAutoStoreMainMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickInspectionTile(),
                "Unable to Click on Inspection tile in AutoStore Main Menu");
        }

        [When(@"I Click on Inventory tile in AutoStore Main Menu")]
        public void GivenIClickOnInventoryTileInAutoStoreMainMenu()
        {
            RetryInventoryWhileSuccess(TryInventory, 5);
        }

        [When(@"I Click on Refill tile in Autostore main menu")]
        public void WhenIClickOnRefillTileInAutostoreMainMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickRefillTile(),
                "Unable to Click on Refill tile in AutoStore Main Menu");
        }

        [When(@"I click on Logout button in Autostore task menu")]
        public void WhenIClickOnLogoutButtonInAutostoreTaskMenu()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickLogout(),
                "Unable to click on Logout button in Autostore task menu");
        }

        private static bool TryInventory()
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickInventoryTile(),
                "Unable to Click on Inventory tile in AutoStore Main Menu");
            Assert.AreEqual("Inventory", InventoryMission.Instance.GetPageTitle(),
                "Autostore Inventory mission page is not loaded");
            if (InventoryMission.Instance.IsInventoryMissionLoaded())
            {
                return true;
            }

            InventoryNoMoreTasksPopup.Instance.IsPopupDisplayed();
            InventoryNoMoreTasksPopup.Instance.ClickOkButton();
            AutostoreTaskMenu.Instance.GetPageTitle();
            return false;
        }

        private static void RetryInventoryWhileSuccess(Func<bool> retryAction, int noOfAttempts)
        {
            for (var i = 0; i < noOfAttempts; i++)
            {
                var result = retryAction();
                if (result)
                    return;
            }

            Assert.Fail("Activity is not prepared");
        }

        private static bool TryPick(string pickTaskType)
        {
            Assert.IsTrue(AutostoreTaskMenu.Instance.ClickPickTaskType(pickTaskType),
                "Unable to Click on Pick task type in AutoStore Main Menu");
            if (PickNoMoreTasksPopup.Instance.IsPopupDisplayed())
            {
                if (PickNoMoreTasksPopup.Instance.IsOkButtonDisplayed())
                {
                    SynchronizeTaskGroups.Instance.DoAutostoreTaskGroupSync();
                    LoginPage.Instance.NavigateToAutoStore("01");
                    LoginPage.Instance.IsLoginPageLoaded();
                    LoginPage.Instance.LoginToApplication("Admin");
                    Assert.AreEqual("AutoStore task menu", AutostoreTaskMenu.Instance.GetPageTitle(),
                        "The Autostore task Menu is not loaded");
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

        private static void ExitFromActivity()
        {
            for (var i = 0; i < 20; i++)
            {
                var noMoreTasksPopupDisplayed = PickNoMoreTasksPopup.Instance.IsPopupLoaded();
                var autoStoreTaskMenuDisplayed = AutostoreTaskMenu.Instance.IsPageDisplayed();

                if (noMoreTasksPopupDisplayed)
                {
                    Assert.IsTrue(PickNoMoreTasksPopup.Instance.ClickOkButton(),
                        "Unable to click OK button on No more pick task popup after the pick activity");
                    Assert.AreEqual("AutoStore task menu", AutostoreTaskMenu.Instance.GetPageTitle(),
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
