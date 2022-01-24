using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class GoodsReceivalLine : IProductLine
    {
        public virtual string ExtReceivalListId { get; set; }

        public virtual int TransactionId { get; set; }

        public string Unnr { get; set; }

        public string OwnerCode { get; set; }

        public virtual string PurchaseOrderId { get; set; }

        public virtual string PurchaseOrderLineId { get; set; }

        public int? ExtPicklistHeaderId { get; set; }

        public int? ExtPicklistLineId { get; set; }

        public virtual string ExtOrderId { get; set; }

        public virtual string ExtProductId { get; set; }

        public string ProductScancodes { get; set; }

        string IProductLine.Scancodes
        {
            get => ProductScancodes;
            set => ProductScancodes = value;
        }

        public string ExtWarehouseId { get; set; }

        public virtual string OrderTypeId { get; set; }

        public virtual string OrderTypeText { get; set; }

        public virtual string ProducerProductId { get; set; }

        public string ProductCategoryId { get; set; }

        public virtual string VendorProductId { get; set; }

        public string BatchId { get; set; }

        public decimal? Tariff { get; set; }

        public string OriginatingCountry { get; set; }

        public virtual string ProductDesc { get; set; }

        public virtual string ProductName { get; set; }

        public virtual int? SizeParam { get; set; }

        public virtual decimal Quantity { get; set; }

        public decimal? Quantity1 { get; set; }

        public decimal? Quantity2 { get; set; }

        public decimal? Quantity3 { get; set; }

        public decimal? Quantity4 { get; set; }

        public decimal? Quantity5 { get; set; }

        public decimal? Quantity6 { get; set; }

        public virtual int QualityCheck { get; set; }

        public virtual int? ItemCategoryId { get; set; }

        public virtual string InitialSalesUnit { get; set; }

        public virtual int? SalesUnitId { get; set; }

        public virtual string SalesUnit { get; set; }

        public virtual decimal? SalesUnitPerLocation { get; set; }

        public virtual decimal? SalesUnitsPerStockUnit { get; set; }

        public string SalesUnitText { get; set; }

        public virtual string Revision { get; set; }

        public virtual string LotNo { get; set; }

        public virtual string ExtLocationIdFrom { get; set; }

        public virtual string Quality { get; set; }

        public virtual string ExpiryDate { get; set; }

        public virtual string ExtOrderlineId { get; set; }

        public virtual int? AddedInfo { get; set; }

        public virtual string SerialNo { get; set; }

        public virtual int? NoPick { get; set; }

        public string DisplayExtProductId { get; set; }

        public virtual string EanId { get; set; }

        public virtual decimal? Weight { get; set; }

        public virtual string ExtId { get; set; }

        public virtual decimal? Volume { get; set; }

        public decimal? SalesUnitWeight { get; set; }

        public virtual int? SalesUnitWidth { get; set; }

        public virtual int? SalesUnitDepth { get; set; }

        public virtual int? SalesUnitHeight { get; set; }

        public decimal? SalesUnitVolume { get; set; }

        public virtual bool? Returned { get; set; }

        public virtual string ExtPicklistId { get; set; }

        public virtual int? ExpiryDateRequired { get; set; }

        public virtual string Vendor { get; set; }

        public string DeliveryIndex { get; set; }

        public string CustLocationId { get; set; }

        public string CustOrderId { get; set; }

        public string OrderlineNote { get; set; }

        public string ImageId { get; set; }

        public string Invoice { get; set; }

        public string Action { get; set; }

        public virtual bool? AllowDuplicates { get; set; }

        public int? ExtOrderlineSubId { get; set; }

        public string HandlingUnitScanCode { get; set; }

        public override string ToString()
        {
            var stringWriter = new StringWriter();
            new XmlSerializer(this.GetType()).Serialize(XmlWriter.Create(stringWriter), this);
            return stringWriter.ToString();
        }
    }
}
