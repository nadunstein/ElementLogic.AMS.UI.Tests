using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class BoxType
    {
        public static BoxType Instance => Singleton.Value;

        public void InsertBoxType(string boxTypeName, int isExternalContainer, string externalContainerRegEx)
        {
            const string mainSql = @"INSERT INTO BOXTYPE ([EXTBOXTYPE],
					                                      [INTBOXTYPE],
                                                          [SCANOFEXTERNALIDREQUIRED],
                                                          [EXTERNALIDREGEX])

                                          VALUES (@boxTypeName,
                                                  @boxTypeName,
                                                  @isExternalContainer,
			                                      @externalContainerRegEx)";

            ConnectionManager.Instance.Execute(connection => connection.Execute(mainSql,
                            new { boxTypeName, isExternalContainer, externalContainerRegEx }));
        }

        private BoxType() { }

        private static readonly Lazy<BoxType> Singleton = new Lazy<BoxType>(() => new BoxType());
    }
}
