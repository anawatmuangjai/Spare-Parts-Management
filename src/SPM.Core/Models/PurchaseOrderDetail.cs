using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class PurchaseOrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderQty { get; set; }
        public int ReceivedQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime RequireDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public PurchaseOrder Order { get; set; }
        public Product Product { get; set; }
    }
}
