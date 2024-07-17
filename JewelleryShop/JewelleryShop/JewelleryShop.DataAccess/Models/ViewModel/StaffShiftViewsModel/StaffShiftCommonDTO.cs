using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.StaffShiftViewsModel
{
    public class StaffShiftCommonDTO
    {
        public string StationId { get; set; } = null!;
        public string StaffId { get; set; } = null!;
        public string? StaionName { get; set; }
    }
}
