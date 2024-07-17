using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Material
    {
        public string MaterialId { get; set; } = null!;
        public string? MaterialName { get; set; }
        public string? MaterialDescription { get; set; }
    }
}
