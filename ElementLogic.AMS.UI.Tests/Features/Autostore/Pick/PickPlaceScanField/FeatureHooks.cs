using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickPlaceScanField.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickPlaceScanField
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_PickPlaceScanField_WhenOrderlineHasScancode")]
        public void BeforeScenarioOne()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer",
                "1");
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(FirstScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Pick_PickPlaceScanField_WhenMoreThanOneOpenContainer")]
        public void BeforeScenarioTwo()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer",
                "1");
            SetUpParameters.Instance.ChangeTheParameterValue("Picking.AutoStore.CloseCurrentContainer",
                "0");
            SetUpParameters.Instance.ChangeTheParameterValue("PickingAutoPlaceOnTrolleyAfterPick",
                "0");
            ProductData.Instance.PrepareProductData(SecondScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(SecondScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Pick_PickPlaceScanField_WhenPickActivityHasMultipleShipments")]
        public void BeforeScenarioThree()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer",
                "1");
            SetUpParameters.Instance.ChangeTheParameterValue("Picking.UseStorageDeviceBatching",
                "1");
            ProductData.Instance.PrepareProductData(ThirdScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(ThirdScenarioTestData.FirstPickOrderLines,
                _scenarioContext);
            PickData.Instance.PreparePickTestData(ThirdScenarioTestData.SecondPickOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Pick_PickPlaceScanField_WhenPickActivityDoesNotHaveMultipleShipments")]
        public void BeforeScenarioFour()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer",
                "1");
            ProductData.Instance.PrepareProductData(ForthScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(ForthScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Pick_PickPlaceScanField_WhenOnlyOneOpenContainer")]
        public void BeforeScenarioFive()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer",
                "1");
            ProductData.Instance.PrepareProductData(FifthScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(FifthScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [AfterScenario("AS_Pick_PickPlaceScanField_WhenOrderlineHasScancode",
            "AS_Pick_PickPlaceScanField_WhenMoreThanOneOpenContainer",
            "AS_Pick_PickPlaceScanField_WhenPickActivityHasMultipleShipments",
            "AS_Pick_PickPlaceScanField_WhenPickActivityDoesNotHaveMultipleShipments", Order = 2)]
        public void AfterScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer",
                "0");
            SetUpParameters.Instance.ChangeTheParameterValue("PickingAutoPlaceOnTrolleyAfterPick",
                "1");
            SetUpParameters.Instance.ChangeTheParameterValue("Picking.UseStorageDeviceBatching",
                "0");
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
