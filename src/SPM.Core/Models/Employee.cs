using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ProductInventory = new HashSet<ProductInventory>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            SalesOrder = new HashSet<SalesOrder>();
        }

        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime ModifyDate { get; set; }

        public Person Person { get; set; }
        public ICollection<ProductInventory> ProductInventory { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public ICollection<SalesOrder> SalesOrder { get; set; }
    }
}
