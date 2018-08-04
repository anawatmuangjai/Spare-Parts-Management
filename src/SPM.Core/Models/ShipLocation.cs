using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ShipLocation
    {
        public ShipLocation()
        {
            SalesOrder = new HashSet<SalesOrder>();
        }

        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationGroup { get; set; }

        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
