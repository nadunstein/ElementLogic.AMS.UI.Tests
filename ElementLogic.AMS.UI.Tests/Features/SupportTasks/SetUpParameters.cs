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

            if (!ParameterList.Instance.IsPageLoaded())
            {
                ParameterList.Instance.Navigate();
                AdminLogin.Instance.LoginToApplication("Admin");
                Assert.AreEqual("Parameter list", ParameterList.Instance.GetPageTitle(),
                    "The Admin parameter List page is not loaded");
            }

            ParameterList.Instance.InsertParameterCode(parameterCode);
            ParameterList.Instance.ClickSearchButton();
            Assert.IsTrue(ParameterList.Instance.IsFirstResultRowDisplayed(),
                "Parameter is not listed on the search grid in Parameter list page");

            ParameterList.Instance.ClickEditButton();
            Assert.IsTrue(ParameterEditPopup.Instance.IsPopupDisplayed(),
                "The parameter edit Popup is not displayed in Parameter list page");

            ParameterEditPopup.Instance.ChangeParameterValue(paramValue);
            ParameterEditPopup.Instance.ClickSaveButton();
            Assert.IsTrue(ParameterList.Instance.IsFirstResultRowDisplayed(),
                "Parameter is not listed on the search grid in Parameter list page");

            var changedParamValue =
                string.IsNullOrEmpty(Parameter.Instance.GetParameterData(parameterCode).ParameterValue)
                    ? Parameter.Instance.GetParameterData(parameterCode).ParameterTextValue
                    : Parameter.Instance.GetParameterData(parameterCode).ParameterValue;

            Assert.AreEqual(paramValue, changedParamValue, "The Parameter value is not changed");
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

        private SetUpParameters() { }

        private static readonly Lazy<SetUpParameters>
            Singleton = new Lazy<SetUpParameters>(() => new SetUpParameters());
    }
}
