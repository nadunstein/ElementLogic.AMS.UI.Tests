using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Inventory
    {
        public static Inventory Instance => Singleton.Value;

        public IList<string> GetFirstHandlingUnitsForLocation(string binLocationId)
        {
            const string mainSql = @"SELECT PS.CODE
                                       FROM PRODUCTLOCATION PL 
                                       LEFT OUTER JOIN PRODUCT_SCANCODE PS 
                                         ON PL.PRODUCTLOCATIONID = PS.STOCKITEM_ID
                                       LEFT OUTER JOIN DEPTH D 
                                         ON PL.DEPTHID = D.DEPTHID
                                      WHERE D.DEPTHUSERDEFID = @binLocationId
                                        AND PS.TYPE = 2";

            var handlingUnitScanCodes = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.Query<string>(mainSql,
                    new { binLocationId })).ToList();
            return handlingUnitScanCodes;
        }

        private Inventory() { }

        private static readonly Lazy<Inventory> Singleton = new Lazy<Inventory>(() => new Inventory());
    }
}
