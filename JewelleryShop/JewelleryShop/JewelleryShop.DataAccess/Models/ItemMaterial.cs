using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class ItemMaterial
    {
        public string? ItemId { get; set; }
        public string? MaterialId { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Material? Material { get; set; }
    }
}
