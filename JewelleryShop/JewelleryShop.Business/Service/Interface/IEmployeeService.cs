using JewelleryShop.DataAccess.Models.ViewModel.EmployeeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IEmployeeService
    {
        public Task<string> LoginAsync(EmployeeLoginDTO employee);
    }
}
