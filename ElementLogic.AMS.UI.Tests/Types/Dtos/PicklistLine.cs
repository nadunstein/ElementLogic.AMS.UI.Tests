using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class PicklistLine : IProductLine
    {
        public int TransactionId { get; set; }

        public string ExtPicklistId { get; set; }

        public string ExtOrderId { get; set; }

        public int? ExtOrderlineId { get; set; }

        public int? ExtOrderlineSubId { get; set; }

        public string ExtProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public decimal Quantity { get; set; }

        public decimal? Quantity2 { get; set; }

        public decimal? Quantity3 { get; set; }

        public decimal? Quantity4 { get; set; }

        public string CustId { get; set; }

        public string CustName { get; set; }

        public string PicklistConsolidationLocation { get; set; }

        public string SpeditorId { get; set; }

        public string SpeditorText { get; set; }

        public decimal? SalesUnitPerLocation { get; set; }

        public decimal? SalesUnitsPerStockUnit { get; set; }

        public string SalesUnitText { get; set; }

        public string OrderTypeId { get; set; }

        public string OrderTypeText { get; set; }

        public string ProducerProductId { get; set; }

        public string Complete { get; set; }

        public int? OrderPriority { get; set; }

        public string Text1 { get; set; }

        public string BatchId { get; set; }

        public decimal? Tariff { get; set; }

        public string OriginatingCountry { get; set; }

        public decimal Volume { get; set; }

        public decimal Weight { get; set; }

        public string YourRef { get; set; }

        public string OurRef { get; set; }

        public string ExtPickDate { get; set; }

        public string ExtPickTime { get; set; }

        public string DelDate { get; set; }

        public string DelTime { get; set; }

        public string DelCompCode { get; set; }

        public string DelName { get; set; }

        public string DelAddr1 { get; set; }

        public string DelAddr2 { get; set; }

        public string DelCity { get; set; }

        public string DelPostCode { get; set; }

        public string DelCountry { get; set; }

        public string DevName { get; set; }

        public string DevAddr1 { get; set; }

        public string DevAddr2 { get; set; }

        public string DevPostCode { get; set; }

        public string DevCity { get; set; }

        public string DevCountry { get; set; }

        public string InvCompCode { get; set; }

        public string InvName { get; set; }

        public string InvAddr1 { get; set; }

        public string InvAddr2 { get; set; }

        public string InvPostCode { get; set; }

        public string InvCity { get; set; }

        public string InvCountry { get; set; }

        public string OrderDate { get; set; }

        public string OrderTime { get; set; }

        public string OrderRouteDate { get; set; }

        public string RouteDate { get; set; }

        public int? ItemCategoryId { get; set; }

        public int? ExtPicklistLineId { get; set; }

        public int? ExtPicklistHeaderId { get; set; }

        public string OrderLineNote { get; set; }

        public string OrderLineNote2 { get; set; }

        public string ExtRouteId { get; set; }

        public string RouteName { get; set; }

        public string PurchaseId { get; set; }

        public string CustLocationId { get; set; }

        public string Info1 { get; set; }

        public string Info2 { get; set; }

        public string Info3 { get; set; }

        public string Info4 { get; set; }

        public string OrderText1 { get; set; }

        public string OrderText2 { get; set; }

        public string OrderLineText1 { get; set; }

        public decimal? NetPrice { get; set; }

        public decimal? GrossPrice { get; set; }

        public decimal? Discount { get; set; }

        public string Sequence { get; set; }

        public string Boxtype { get; set; }

        public int? ShipmentId { get; set; }

        public string TmsCustomerId { get; set; }

        public string IncoTerm { get; set; }

        public string IncoTermText { get; set; }

        public string Unnr { get; set; }

        public string OwnerCode { get; set; }

        public int? ProductLabels { get; set; }

        public string Scancode { get; set; }

        public string ProductScancodes { get; set; }

        string IProductLine.Scancodes
        {
            get => ProductScancodes;
            set => ProductScancodes = value;
        }

        public string CustOrderId { get; set; }

        public string StockAvailabilityHandling { get; set; }

        public string Action { get; set; }

        public int? AddedInfo { get; set; }

        public string VendorProductId { get; set; }

        public string DisplayExtProductId { get; set; }

        public string EanId { get; set; }

        public string ExtId { get; set; }

        public int? ExpiryDateRequired { get; set; }

        public string ExtWarehouseId { get; set; }

        public decimal? PriceGross { get; set; }

        public decimal? PriceNet { get; set; }

        public string InitialSalesUnit { get; set; }

        public string ProductCategoryId { get; set; }

        public decimal? SalesUnitWeight { get; set; }

        public int? SalesUnitWidth { get; set; }

        public int? SalesUnitDepth { get; set; }

        public int? SalesUnitHeight { get; set; }

        public decimal? SalesUnitPerStockUnit { get; set; }

        public decimal? SalesUnitVolume { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal TotalInvoiceAmount { get; set; }

        public string InvoiceNumber { get; set; }

        public string ReceiverMail { get; set; }

        public string ReceiverPhone { get; set; }

        public string SenderMail { get; set; }

        public string SenderPhone { get; set; }

        public string ImageId { get; set; }

        public string WorkOrderId { get; set; }

        public int? ValidateQuantityAbove { get; set; }

        public override string ToString()
        {
            var stringWriter = new StringWriter();
            new XmlSerializer(GetType()).Serialize(XmlWriter.Create(stringWriter), this);
            return stringWriter.ToString();
        }
    }
}
