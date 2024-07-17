using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.ItemImageViewModel
{
    public class ItemImageCommonDTO
    {
        public string Id { get; set; } = null!;
        public string? ItemId { get; set; }
        public string? ImageUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
