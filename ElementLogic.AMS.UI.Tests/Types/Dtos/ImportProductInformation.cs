using System.Collections.Generic;

namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class ImportProductInformation
    {
        public string UniqueMessageId { get; set; }

        public IEnumerable<ProductLine> Lines { get; set; }

        public string BlobReference { get; set; }

        public bool PayloadInMessage { get; set; }
    }
}
