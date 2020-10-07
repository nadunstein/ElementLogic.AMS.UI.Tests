using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ElementLogic.AMS.UI.Tests.Configuration;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Parameter
    {
        private static readonly string Context = ConfigFileReader.Instance.ConfigurationKeyValue("Application:context");

        public static Parameter Instance => Singleton.Value;

        public MegaParamData GetParameterData(string parameterName)
        {
            var parameterDetails = GetParameterData();
            return parameterDetails.FirstOrDefault(parameter =>
                parameter.ParameterDefinition.Contains(parameterName));
        }

        private static IEnumerable<MegaParamData> GetParameterData()
        {
            const string mainSql = @"SELECT PARAMDEF as ParameterDefinition,
                                            PARAMVAL as ParameterValue,
                                            PARAMTXT as ParameterTextValue
                                       FROM MEGAPARAM
                                      WHERE CONTEXT = @context";

            var paramData = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.Query<MegaParamData>(mainSql, new { Context }).ToList());
            return paramData;
        }

        private Parameter() { }

        private static readonly Lazy<Parameter> Singleton = new Lazy<Parameter>(() => new Parameter());
    }

    public class MegaParamData
    {
        public string ParameterDefinition { get; set; }
        public string ParameterValue { get; set; }
        public string ParameterTextValue { get; set; }
    }
}
