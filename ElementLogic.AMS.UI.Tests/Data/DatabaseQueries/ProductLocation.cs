using System;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class ProductLocation
    {
        public static ProductLocation Instance => Singleton.Value;

        public double GetLocationQuantity(string locationId, string extProductId)
        {
            const string mainSql = @"SELECT QUANTITY
                                       FROM PRODUCTLOCATION 
                                      WHERE EXTPRODUCTID = @extProductId
                                        AND LOCATION_NAME = @locationId
                                        AND USERNAME = 'adm'";
            var quantity = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<double>(mainSql,
                    new { extProductId, locationId }));
            return quantity;
        }

        public string GetFirstProductLocation(string extProductId)
        {
            const string mainSql = @"SELECT TOP 1 LOCATION_NAME
                                       FROM PRODUCTLOCATION 
                                      WHERE EXTPRODUCTID =  @extProductId";
            var location = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { extProductId }));
            return location;
        }

        public string GetFirstProductLocationAssignedForPick(string extProductId)
        {
            const string mainSql = @"SELECT TOP 1 LOCATION_NAME 
                                       FROM PRODUCTLOCATION 
                                      WHERE EXTPRODUCTID = @extProductId
                                        AND QUANTITYOUT > 0";
            var location = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql,
                    new { extProductId }));
            return location;
        }

        public int GetProductLocationTypeId(string locationType)
        {
            const string mainSql = @"SELECT SIZEID
                                       FROM SIZEPARAM 
                                      WHERE SIZETEXT =  @locationType";
            var locationTypeId = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<int>(mainSql,
                    new { locationType }));
            return locationTypeId;
        }

        public string GetEmptyAutostoreLocation(string locationType)
        {
            const string mainSql = @"SELECT TOP (1) d.depthuserdefid 
                                       FROM productlocation pl 
                           RIGHT OUTER JOIN depth d 
                                         ON pl.depthid = d.depthid 
                                 INNER JOIN positions p  
                                         ON d.positionid = p.positionid 
                                 INNER JOIN shelf s 
                                         ON p.shelfid = s.shelfid 
                                 INNER JOIN equipment e  
                                         ON s.equipid = e.equipid 
                                 INNER JOIN warehousezone w 
                                         ON e.zoneid = w.zoneid 
                            LEFT OUTER JOIN sizeparam pa 
                                         ON d.sizeid = pa.sizeid 
                            LEFT OUTER JOIN product pr 
                                         ON pl.id_product = pr.productid 
                                      WHERE e.equipid = 1 
                                        AND d.sizeid = pa.sizeid
										AND pa.sizetext = @locationType 
                                        AND pl.productlocationid IS NULL";

            var location = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.QueryFirstOrDefault<string>(mainSql, new { locationType }));
            return location;
        }

        private ProductLocation() { }

        private static readonly Lazy<ProductLocation>
            Singleton = new Lazy<ProductLocation>(() => new ProductLocation());
    }
}
