using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class MaterialPrice
    {
        public string Id { get; set; } = null!;
        public string? Symbol { get; set; }
        public decimal? PriceUsd { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
