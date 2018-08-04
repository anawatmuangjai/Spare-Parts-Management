using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductGroup = new HashSet<ProductGroup>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public string Description { get; set; }

        public ICollection<ProductGroup> ProductGroup { get; set; }
    }
}
