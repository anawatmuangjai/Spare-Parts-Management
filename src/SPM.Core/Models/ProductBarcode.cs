using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductBarcode
    {
        public int BarcodeId { get; set; }
        public int ProductVendorId { get; set; }
        public string BarcodeText { get; set; }
        public string BarcodeType { get; set; }
        public bool? BarcodeVendor { get; set; }

        public ProductVendor ProductVendor { get; set; }
    }
}
