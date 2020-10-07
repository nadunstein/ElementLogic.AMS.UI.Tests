namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class DirectPutawayLine
    {
        public string TransactionId { set; get; }
        public string LocationCode { set; get; }
        public string SkuNumber => ExtProductId;
        public string ExtProductId { set; get; }
        public string Quantity { set; get; }
        public string UserCode { set; get; }
    }
}
