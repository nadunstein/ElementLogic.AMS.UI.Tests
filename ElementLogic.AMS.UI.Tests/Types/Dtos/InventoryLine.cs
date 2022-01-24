namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class InventoryLine
    {
        public string ExtProductId { get; set; }

        public string HandlingUnitScanCode { get; set; }

        public virtual decimal HandlingUnitQuantity { get; set; }
    }
}
