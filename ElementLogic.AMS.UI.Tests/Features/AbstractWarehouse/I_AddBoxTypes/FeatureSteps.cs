using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AbstractWarehouse.I_AddBoxTypes
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I add box types to BoxTypes table as follows:")]
        public void GivenIAddBoxTypesToBoxTypesTableAsFollows(Table table)
        {
            var boxTypes = table.CreateDynamicSet();
            foreach (var boxType in boxTypes)
            {
                if (boxType.ExternalContainerRegEx == "null")
                {
                    boxType.ExternalContainerRegEx = null;
                }
                BoxType.Instance.InsertBoxType(boxType.BoxTypeName, boxType.IsExternalContainer, boxType.ExternalContainerRegEx);
            }
        }

    }
}
