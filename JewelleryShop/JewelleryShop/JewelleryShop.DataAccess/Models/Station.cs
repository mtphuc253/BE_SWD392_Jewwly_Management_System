using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Station
    {
        public Station()
        {
            staff = new HashSet<staff>();
        }

        public string StationId { get; set; } = null!;
        public string? StationName { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
