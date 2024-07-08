using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Item
    {
        public string ItemId { get; set; } = null!;
        public string? ItemImagesId { get; set; }
        public string? BrandId { get; set; }
        public string? AccessoryType { get; set; }
        public string? Sku { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Size { get; set; }
        public string? Weight { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Status { get; set; }
    }
}
