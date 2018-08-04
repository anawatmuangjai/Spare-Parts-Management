using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductBusiness
    {
        public ProductBusiness()
        {
            ProductInventory = new HashSet<ProductInventory>();
        }

        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string Description { get; set; }

        public ICollection<ProductInventory> ProductInventory { get; set; }
    }
}
