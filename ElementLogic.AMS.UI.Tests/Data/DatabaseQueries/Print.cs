using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Print
    {
        public static Print Instance => Singleton.Value;

        public void DeletePrintLogs()
        {
            const string mainSql = @"DELETE FROM PRINTLOG";
            ConnectionManager.Instance.Execute(connection => connection.Execute(mainSql));
        }

        public string GetContainerIdForInternalTransportLabel(string picklistId)
        {
            const string mainSql = @"SELECT TOP 1 ID
                                       FROM CONTAINER 
                                      WHERE ID_ACTIVITY = (SELECT ID 
                                                             FROM ACTIVITY 
                                                            WHERE ID_TASKGROUPACTIVE = (SELECT Top 1 MMPICKLISTID 
                                                                                          FROM MISSION 
                                                                                         WHERE PICKLISTID =@picklistId))
                                   ORDER BY ID DESC";
            var containerId = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { picklistId }));
            return containerId;
        }

        private Print() { }

        private static readonly Lazy<Print> Singleton = new Lazy<Print>(() => new Print());
    }
}
