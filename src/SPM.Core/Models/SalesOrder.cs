using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int ReasonId { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ProductInventory Inventory { get; set; }
        public ShipLocation Location { get; set; }
        public SalesReason Reason { get; set; }
    }
}
