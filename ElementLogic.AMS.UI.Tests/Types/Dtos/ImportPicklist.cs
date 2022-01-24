using System.Collections.Generic;

namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class ImportPicklist
    {
        public string UniqueMessageId { get; set; }

        public IEnumerable<PicklistLine> Lines { get; set; }

        public string BlobReference { get; set; }

        public bool PayloadInMessage { get; set; }
    }
}
