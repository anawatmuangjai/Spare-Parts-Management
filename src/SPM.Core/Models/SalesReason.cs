using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class SalesReason
    {
        public SalesReason()
        {
            SalesOrder = new HashSet<SalesOrder>();
        }

        public int ReasonId { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonName { get; set; }

        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
