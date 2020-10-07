using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class ReasonCode
    {
        public static ReasonCode Instance => Singleton.Value;

        public void InsertReasonCode(int reasonCodeId, string reasonText, int updateCode)
        {
            const string mainSql = @"INSERT INTO REASONCODE ([REASONCODEID],
                                                             [REASONTEXT],
                                                             [UPDATECODE])
                                          VALUES (@reasonCodeId,
                                                  @reasonText,
                                                  @updateCode)";

            ConnectionManager.Instance.Execute(connection => connection.Execute(mainSql,
                new { reasonCodeId, reasonText, updateCode }));
        }

        private ReasonCode() { }

        private static readonly Lazy<ReasonCode> Singleton = new Lazy<ReasonCode>(() => new ReasonCode());
    }
}
