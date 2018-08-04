using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductThumbnail
    {
        public ProductThumbnail()
        {
            ProductPhoto = new HashSet<ProductPhoto>();
        }

        public int ThumbnailId { get; set; }
        public string ThumbnailFileName { get; set; }
        public byte[] ThumbnailPhoto { get; set; }

        public ICollection<ProductPhoto> ProductPhoto { get; set; }
    }
}
