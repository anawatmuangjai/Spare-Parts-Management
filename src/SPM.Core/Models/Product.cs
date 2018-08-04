using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInventory = new HashSet<ProductInventory>();
            ProductPhoto = new HashSet<ProductPhoto>();
            ProductTransaction = new HashSet<ProductTransaction>();
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int GroupId { get; set; }
        public int ShelfId { get; set; }
        public int PackageQty { get; set; }
        public int StockedQty { get; set; }
        public int SafetyStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int ShelfLife { get; set; }
        public int UsageLifeTime { get; set; }
        public int UsagePerDay { get; set; }
        public DateTime ModifyDate { get; set; }

        public ProductGroup Group { get; set; }
        public ProductShelf Shelf { get; set; }
        public ICollection<ProductInventory> ProductInventory { get; set; }
        public ICollection<ProductPhoto> ProductPhoto { get; set; }
        public ICollection<ProductTransaction> ProductTransaction { get; set; }
        public ICollection<ProductVendor> ProductVendor { get; set; }
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
