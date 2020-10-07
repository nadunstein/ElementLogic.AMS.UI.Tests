using System;
using System.Collections.Generic;
using System.Linq;
using AutoStoreManagementSystem.UITests.Types.Enums;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Order
    {
        public static Order Instance => Singleton.Value;

        public string GetOrderStatusId(string picklistId)
        {
            const string mainSql = @"SELECT ORDERSTATUSID 
                                       FROM ORDERS 
                                      WHERE EXTPICKLISTID = @picklistId";

            var orderStatus = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { picklistId }));
            return orderStatus;
        }

        public string GetFirstUnFinishedPickOrderStatus()
        {
            const int orderType = (int)OrderType.Picking;
            const int maxOrderLineStatus = (int)LineStatus.Controller;

            const string mainSql = @"SELECT top 1 ORDERSTATUSID
                                       FROM ORDERS 
                                      WHERE DIRECTION = @orderType
                                        AND ORDERSTATUSID <= @maxOrderLineStatus
                                   GROUP BY ORDERSTATUSID";

            var location = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { orderType, maxOrderLineStatus }));
            return location;
        }

        public IList<string> GetUnFinishedPickOrders()
        {
            const int orderType = (int)OrderType.Picking;
            const int maxOrderLineStatus = (int)LineStatus.Controller;

            const string mainSql = @"SELECT EXTPICKLISTID as PicklistId
                                       FROM ORDERS 
                                      WHERE DIRECTION = @orderType
                                        AND ORDERSTATUSID <= @maxOrderLineStatus";

            var picklistIds = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.Query<string>(mainSql,
                    new { orderType, maxOrderLineStatus })).ToList();
            return picklistIds;
        }

        public int GetUnFinishedPickOrderCount(int orderStatus)
        {
            const int orderType = (int)OrderType.Picking;

            const string mainSql = @"SELECT COUNT(EXTPICKLISTID)
                                       FROM ORDERS 
                                      WHERE DIRECTION = @orderType
                                        AND ORDERSTATUSID = @orderStatus";

            var location = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<int>(mainSql,
                    new { orderType, orderStatus }));
            return location;
        }

        private Order() { }

        private static readonly Lazy<Order> Singleton = new Lazy<Order>(() => new Order());
    }
}
