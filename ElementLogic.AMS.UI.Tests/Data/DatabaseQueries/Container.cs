using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Container
    {
        public static Container Instance => Singleton.Value;

        public void DeleteBoxTypes()
        {
            const string mainSql = @"DELETE FROM BOXTYPE";
            ConnectionManager.Instance.Execute(connection => connection.Execute(mainSql));
        }

        public void InsertBoxType(int boxNumber, int externalContainer = 0, string boxName = "Box",
            string externalIdRegEx = null)
        {
            var nameOfTheBox = string.Concat(boxName, boxNumber);

            const string mainSql = @"INSERT INTO BOXTYPE ([EXTBOXTYPE],
                                                          [INTBOXTYPE],
                                                          [SCANOFEXTERNALIDREQUIRED],
                                                          [EXTERNALIDREGEX])
                                                  VALUES (@boxname,
                                                          @boxname,
                                                          @externalContainer,
                                                          @externalIdRegEx)";

            ConnectionManager.Instance.Execute(connection => connection.Execute(mainSql,
                new { nameOfTheBox, externalContainer, externalIdRegEx }));
        }

        public bool IsExternalContainer(string containerId)
        {
            const string mainSql = @"SELECT count(ID_CONTAINER) 
                                       FROM CONTAINERITEM 
                                      WHERE EXTPICKLISTID = @containerId";

            var extContainerCount = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { containerId }));

            return extContainerCount == "1";
        }

        private Container() { }

        private static readonly Lazy<Container> Singleton = new Lazy<Container>(() => new Container());
    }
}
