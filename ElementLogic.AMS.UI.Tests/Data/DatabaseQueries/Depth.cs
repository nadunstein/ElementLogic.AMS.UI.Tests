using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Depth
    {
        public static Depth Instance => Singleton.Value;

        public bool IsPutToLightLocationExist(string locationId)
        {
            const string mainSql = @"SELECT count(DEPTHUSERDEFID) 
                                       FROM DEPTH 
                                      WHERE LOCATIONTYPE = 20 
                                        AND DEPTHUSERDEFID = @locationId";

            var location = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { locationId }));

            return location == "1";
        }

        private Depth() { }

        private static readonly Lazy<Depth> Singleton = new Lazy<Depth>(() => new Depth());
    }
}
