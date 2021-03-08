using System;
using System.Collections.Generic;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.Parameters;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using NUnit.Framework;
using AdminLogin = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class SetUpParameters
    {
        public IList<ParameterLIne> ParametersToBeReset = new List<ParameterLIne>();

        public static SetUpParameters Instance => Singleton.Value;

        public void ChangeTheParameterValue(string parameterCode, string paramValue)
        {
            var actualParamValue =
                string.IsNullOrEmpty(Parameter.Instance.GetParameterData(parameterCode).ParameterValue)
                    ? Parameter.Instance.GetParameterData(parameterCode).ParameterTextValue
                    : Parameter.Instance.GetParameterData(parameterCode).ParameterValue;
            if (actualParamValue.Equals(paramValue))
            {
                return;
            }

            AddParametersToBeChangedToList(parameterCode, actualParamValue);
            ChangeParameterSteps(parameterCode, paramValue);
            var changedParamValue =
                string.IsNullOrEmpty(Parameter.Instance.GetParameterData(parameterCode).ParameterValue)
                    ? Parameter.Instance.GetParameterData(parameterCode).ParameterTextValue
                    : Parameter.Instance.GetParameterData(parameterCode).ParameterValue;

            Assert.AreEqual(paramValue, changedParamValue, $"The Parameter '{parameterCode}' value is not changed");
        }

        public IList<ParameterLIne> GetParametersToBeReset()
        {
            return ParametersToBeReset;
        }

        public void FlushParametersToBeReset()
        {
            ParametersToBeReset.Clear();
        }

        private void AddParametersToBeChangedToList(string parameterCode, string paramValue)
        {
            if (ParametersToBeReset.Any(parameterList => parameterList.ParameterName.Equals(parameterCode)))
            {
                return;
            }

            var parameterLIne = new ParameterLIne
            {
                ParameterName = parameterCode, ParameterValue = paramValue
            };

            ParametersToBeReset.Add(parameterLIne);
        }

        private static void ChangeParameterSteps(string parameterCode, string paramValue)
        {
            ParameterList.Instance.Navigate();
            AdminLogin.Instance.LoginToApplication("Admin");
            var isPageLoaded = ParameterList.Instance.IsPageLoaded();
            var isInserted = ParameterList.Instance.InsertParameterCode(parameterCode);
            var isClickedSearchButton = ParameterList.Instance.ClickSearchButton();
            var isFirstResultRowDisplayed1 = ParameterList.Instance.IsFirstResultRowDisplayed();
            var isClickedEditButton = ParameterList.Instance.ClickEditButton();
            var isPopupDisplayed = ParameterEditPopup.Instance.IsPopupDisplayed();
            var changedParameterValue = ParameterEditPopup.Instance.ChangeParameterValue(paramValue);
            var isClickedSaveButton = ParameterEditPopup.Instance.ClickSaveButton();
            var isFirstResultRowDisplayed2 = ParameterList.Instance.IsFirstResultRowDisplayed();

            var result = isPageLoaded && isInserted && isClickedSearchButton && isFirstResultRowDisplayed1 &&
                   isClickedEditButton && isPopupDisplayed && changedParameterValue && isClickedSaveButton &&
                   isFirstResultRowDisplayed2;
            Assert.IsTrue(result, "Unable to change parameter value in TEST DATA PREPARATION");
        }

        private SetUpParameters() { }

        private static readonly Lazy<SetUpParameters>
            Singleton = new Lazy<SetUpParameters>(() => new SetUpParameters());
    }
}
