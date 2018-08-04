using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class ProductPhoto
    {
        public int ProductId { get; set; }
        public int ThumbnailId { get; set; }
        public bool? PrimaryPhoto { get; set; }
        public DateTime ModifyDate { get; set; }

        public Product Product { get; set; }
        public ProductThumbnail Thumbnail { get; set; }
    }
}
