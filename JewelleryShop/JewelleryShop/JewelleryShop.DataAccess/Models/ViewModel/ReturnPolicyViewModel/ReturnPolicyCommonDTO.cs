using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.ReturnPolicyViewModel
{
    public class ReturnPolicyCommonDTO
    {
        public string Id { get; set; } = null!;
        public string? ReturnPolicyType { get; set; }
        public string? ReturnWindow { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
