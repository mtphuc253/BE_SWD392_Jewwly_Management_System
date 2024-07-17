using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IStaffRepository : IGenericRepository<staff>
    {
        public Task<staff> CheckLoginCredentials(string usernameOrEmail, string password);
        public Task<bool> CheckUserExists(string username);
        void DisableAccount(staff staff);
        public Task<staff> UpdateAsync(string id, staff employee);
        public Task DeleteAsync(string id);
    }
}
