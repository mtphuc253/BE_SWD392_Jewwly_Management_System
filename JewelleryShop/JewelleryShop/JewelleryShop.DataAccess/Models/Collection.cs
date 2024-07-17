using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Collection
    {
        public Collection()
        {
            Items = new HashSet<Item>();
        }

        public string Id { get; set; } = null!;
        public string? CollectionName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
