using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? ActiveStatus { get; set; }

        public ICollection<ProductVendor> ProductVendor { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
