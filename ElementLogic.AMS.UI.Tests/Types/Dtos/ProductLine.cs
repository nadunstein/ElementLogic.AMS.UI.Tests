namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class ProductLine
    {
        public int TransactionId { get; set; }

        public string ExtProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public string ProducerProductId { get; set; }

        public string VendorProductId { get; set; }

        public string DisplayExtProductId { get; set; }

        public string SalesUnitText { get; set; }

        public string InitialSalesUnit { get; set; }

        public string EanId { get; set; }

        public string ExtId { get; set; }

        public decimal? SalesUnitWeight { get; set; }

        public int? SalesUnitWidth { get; set; }

        public int? SalesUnitDepth { get; set; }

        public int? SalesUnitHeight { get; set; }

        public decimal? SalesUnitVolume { get; set; }

        public decimal? SalesUnitPerLocation { get; set; }

        public decimal? SalesUnitsPerStockUnit { get; set; }

        public decimal? Quantity { get; set; }

        public int? ExpiryDateRequired { get; set; }

        public string ProductCategoryId { get; set; }

        public string ExtWarehouseId { get; set; }

        public decimal? PriceNet { get; set; }

        public decimal? PriceGross { get; set; }

        public string Unnr { get; set; }

        public string BatchId { get; set; }

        public decimal? Tariff { get; set; }

        public string OriginatingCountry { get; set; }

        public string ImageId { get; set; }

        public string Scancodes { get; set; }

        public int? ValidateQuantityAbove { get; set; }

        public decimal? QuantityVerificationThreshold { get; set; }
    }
}
