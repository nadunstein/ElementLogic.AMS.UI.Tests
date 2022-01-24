namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public interface IProductLine
    {
        string DisplayExtProductId { get; set; }

        string EanId { get; set; }

        int? ExpiryDateRequired { get; set; }

        string ExtId { get; set; }

        string ExtProductId { get; set; }

        string ExtWarehouseId { get; set; }

        string ProducerProductId { get; set; }

        string ProductCategoryId { get; set; }

        string ProductDesc { get; set; }

        string ProductName { get; set; }

        int? SalesUnitDepth { get; set; }

        int? SalesUnitHeight { get; set; }

        decimal? SalesUnitPerLocation { get; set; }

        decimal? SalesUnitsPerStockUnit { get; set; }

        string SalesUnitText { get; set; }

        string InitialSalesUnit { get; set; }

        decimal? SalesUnitVolume { get; set; }

        decimal? SalesUnitWeight { get; set; }

        int? SalesUnitWidth { get; set; }

        int TransactionId { get; set; }

        string Unnr { get; set; }

        string VendorProductId { get; set; }

        string BatchId { get; set; }

        decimal? Tariff { get; set; }

        string OriginatingCountry { get; set; }

        string ImageId { get; set; }

        string Scancodes { get; set; }
    }
}
