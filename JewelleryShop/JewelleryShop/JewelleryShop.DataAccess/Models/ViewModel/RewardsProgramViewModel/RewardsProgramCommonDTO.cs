using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.RewardsProgramViewModel
{
    public class RewardsProgramCommonDTO
    {
        public string Id { get; set; } = null!;
        public string? CustomerId { get; set; }
        public int? PointsTotal { get; set; }
    }
}
