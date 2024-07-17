using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.ItemViewModel
{
    public class ItemDTO
    {   
        public string? ItemImagesId { get; set; }
        public string? GemStoneId { get; set; }
        public string? Brand { get; set; }
        public string? AccessoryType { get; set; }
        public string? SerialNumber { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Size { get; set; }
        public string? Weight { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Status { get; set; }
        public int? Quantity { get; set; }
        public bool? IsBuyBack { get; set; }
    }
}
