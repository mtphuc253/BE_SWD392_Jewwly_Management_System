using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool? Status { get; set; }
    }
}
