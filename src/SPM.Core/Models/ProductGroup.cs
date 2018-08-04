using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Product = new HashSet<Product>();
        }

        public int GroupId { get; set; }
        public int CategoryId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }

        public ProductCategory Category { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
