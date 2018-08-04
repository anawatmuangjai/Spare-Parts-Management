using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public int OrderId { get; set; }
        public int VendorId { get; set; }
        public string OrderNumber { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ModifyDate { get; set; }

        public Employee Employee { get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
