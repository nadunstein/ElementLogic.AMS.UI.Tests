using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class ParameterData
    {
        public static ParameterData Instance => Singleton.Value;

        public void SetUpParameterData(IList<ParameterLIne> parametersToBeChanged)
        {
            foreach (var parameterToBeChanged in parametersToBeChanged)
            {
                SetUpParameters.Instance.ChangeTheParameterValue(parameterToBeChanged.ParameterName,
                    parameterToBeChanged.ParameterValue);
            }
        }

        private ParameterData() { }

        private static readonly Lazy<ParameterData> Singleton = new Lazy<ParameterData>(() => new ParameterData());
    }
}
