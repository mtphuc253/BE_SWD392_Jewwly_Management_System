using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class RewardsProgram
    {
        public string Id { get; set; } = null!;
        public string? CustomerId { get; set; }
        public int? PointsTotal { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
