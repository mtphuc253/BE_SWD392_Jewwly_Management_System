using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<Employee> CheckLoginCredentials(string usernameOrEmail, string passwordHash);
        public Task<bool> CheckUserExists(string username);
    }
}
