using System;
using System.Collections.Generic;

namespace JewelleryShop.DataAccess.Models
{
    public partial class staff
    {
        public staff()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string StaffId { get; set; } = null!;
        public int RoleId { get; set; }
        public string? StationId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual StaffStation? Station { get; set; }
        public virtual Station? StationNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
