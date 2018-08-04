using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductVendor
    {
        public ProductVendor()
        {
            ProductBarcode = new HashSet<ProductBarcode>();
        }

        public int ProductVendorId { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int LeadTime { get; set; }
        public decimal? LastReceiptPrice { get; set; }
        public DateTime ModifyDate { get; set; }

        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<ProductBarcode> ProductBarcode { get; set; }
    }
}
