namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class ProductLocationLine
    {
        public string ExtProductId { set; get; }
        public string ProductName { set; get; }
        public string LocationType { set; get; }
        public string HandlingUnitScanCode { set; get; }
        public string EanId { set; get; }
        public bool UseSameLocation { set; get; }
        public bool IsHandlingUnitProduct { set; get; }
        public string BatchId { set; get; }
        public int Quantity { set; get; }
    }
}
