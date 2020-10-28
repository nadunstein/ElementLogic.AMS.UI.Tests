using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.HamburgerMenu;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory;
using ElementLogic.Integration.Import.Contracts.Types;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.CommonStepDefinitions
{
    [Binding]
    public class AdminCommonSteps
    {
        private static ScenarioContext _scenarioContext;

        [When(@"I Click on Log Out option on Hamburger menu in admin module page")]
        public void WhenIClickOnLogOutOptionOnHamburgerMenuInAdminModulePage()
        {
            Assert.IsTrue(HamburgerMenu.Instance.SelectLogOutOption(),
                "Unable to Click on LogOut option on Hamburger menu in admin module page");
            _scenarioContext.Add("NoDeleteBrowserCookies", true);
        }

        [Then(@"I Import and create a GR order with following data")]
        public void ThenIImportAndCreateAgrOrderWithFollowingData(Table table)
        {
            var (orderLineId, productId, productName, scancode, quantity) = table.CreateInstance<(
                string OrderLineId,
                string ProductId,
                string ProductName,
                string Scancode,
                int Quantity)>();

            var goodsReceivalOrderLines = new List<GoodsReceivalLine>
            {
                new GoodsReceivalLine
                {
                    Action = "A",
                    PurchaseOrderLineId = orderLineId,
                    ProductName = productName,
                    ExtProductId = productId,
                    ProductScancodes = scancode,
                    Quantity = quantity,
                    Returned = false
                }
            };

            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(goodsReceivalOrderLines, _scenarioContext);
        }

        private AdminCommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
