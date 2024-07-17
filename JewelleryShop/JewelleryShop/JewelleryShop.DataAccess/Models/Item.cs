using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Item
    {
        public Item()
        {
            Brands = new HashSet<Brand>();
            ItemImages = new HashSet<ItemImage>();
            ItemInvoices = new HashSet<ItemInvoice>();
            Collections = new HashSet<Collection>();
        }

        public string ItemId { get; set; } = null!;
        public string? ItemImagesId { get; set; }
        public string? BrandId { get; set; }
        public string? AccessoryType { get; set; }
        public string? SerialNumber { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Size { get; set; }
        public string? Weight { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Status { get; set; }
        public string? GemStoneId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsBuyBack { get; set; }

        public virtual Gemstone? GemStone { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
        public virtual ICollection<ItemInvoice> ItemInvoices { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
    }
}
