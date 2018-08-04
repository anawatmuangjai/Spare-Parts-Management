using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductInventory
    {
        public ProductInventory()
        {
            SalesOrder = new HashSet<SalesOrder>();
        }

        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductSerial { get; set; }
        public int Quantity { get; set; }
        public int BusinessId { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int EmployeeId { get; set; }

        public ProductBusiness Business { get; set; }
        public Employee Employee { get; set; }
        public Product Product { get; set; }
        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
