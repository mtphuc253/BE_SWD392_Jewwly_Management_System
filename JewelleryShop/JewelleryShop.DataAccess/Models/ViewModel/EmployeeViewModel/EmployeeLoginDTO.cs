using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Models.ViewModel.EmployeeViewModel
{
    public class EmployeeLoginDTO
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
