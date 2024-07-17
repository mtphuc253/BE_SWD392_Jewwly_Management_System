using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Gemstone
    {
        public Gemstone()
        {
            Items = new HashSet<Item>();
        }

        public string Id { get; set; } = null!;
        public string? GemstoneName { get; set; }
        public string? Colour { get; set; }
        public string? Rarity { get; set; }
        public string? Origin { get; set; }
        public int? Price { get; set; }
        public string? Hardness { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
