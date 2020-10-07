using System;
using ElementLogic.AMS.UI.Tests.Configuration;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus;
using NUnit.Framework;
using SeleniumEssential;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class SynchronizeAutostoreBins
    {
        public static SynchronizeAutostoreBins Instance => Singleton.Value;

        public void DoAutostoreBinSync()
        {
            var browserMode =
                bool.Parse(ConfigFileReader.Instance.ConfigurationKeyValue("BrowserSettings:ChromeBrowser:HeadlessMode"));
            WebDriverHelper.Instance.InitializeChromeDriver("Drivers/ChromeDriver", browserMode);

            LiveFeedStatus.Instance.Navigate();
            LoginPage.Instance.LoginToApplication("Admin");
            Assert.AreEqual("Live feed status", LiveFeedStatus.Instance.GetPageTitle(),
                "The Live feed status page is NOT loaded");

            LiveFeedStatus.Instance.SelectActionDropDownOption("Synchronize bin contents");
            Assert.AreEqual("Synchronize bin contents", SynchronizeBinContentsPopUp.Instance.GetPopUpTitle(),
                "Synchronize bin contents popUp is NOT displayed");
            SynchronizeBinContentsPopUp.Instance.ClickSynchronizeButton();

            WebDriverHelper.Instance.QuitDriver();
        }

        private SynchronizeAutostoreBins() { }

        private static readonly Lazy<SynchronizeAutostoreBins> Singleton =
            new Lazy<SynchronizeAutostoreBins>(() => new SynchronizeAutostoreBins());
    }
}
