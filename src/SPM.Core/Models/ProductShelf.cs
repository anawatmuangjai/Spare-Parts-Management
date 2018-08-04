using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductShelf
    {
        public ProductShelf()
        {
            Product = new HashSet<Product>();
        }

        public int ShelfId { get; set; }
        public string ShelfName { get; set; }
        public string ShelfGroup { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
