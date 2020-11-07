using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class AddedInfoRules
    {
        public static AddedInfoRules Instance => Singleton.Value;

        public void InsertAddedInfoRule(int id, string addedInfoRuleName, int exactQuantity, string addedInfoRegEx)
        {
            const string mainSql = @"INSERT INTO ADDEDINFORULES ([ID],
					                                      [DISPLAYTEXT],
                                                          [EXACTQUANTITY],
                                                          [FORMATREGEXP])

                                          VALUES (@id,
                                                  @addedInfoRuleName,
                                                  @exactQuantity,
			                                      @addedInfoRegEx)";

            ConnectionManager.Instance.Execute(connection => connection.Execute(mainSql,
                            new { id, addedInfoRuleName, exactQuantity, addedInfoRegEx }));
        }

        private AddedInfoRules() { }

        private static readonly Lazy<AddedInfoRules> Singleton = new Lazy<AddedInfoRules>(() => new AddedInfoRules());
    }
}
