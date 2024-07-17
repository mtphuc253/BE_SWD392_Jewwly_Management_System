using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using JewelleryShop.DataAccess.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class StaffRepository : GenericRepository<staff>, IStaffRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public StaffRepository(JewelleryDBContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<staff?> CheckLoginCredentials(string usernameOrEmail, string password)
        {
            var user = await _dbContext.staff
                .FirstOrDefaultAsync(record => 
                    (
                        record.UserName.Equals(usernameOrEmail) || 
                        record.Email.Equals(usernameOrEmail)
                    ));
            if (user == null) throw new Exception("Incorrect login credentials. Please try again");
            if (StringUtils.VerifyPassword(password, user.PasswordHash))
                return user;
            throw new Exception("Incorrect login credentials. Please try again");
        }

        public async Task<bool> CheckUserExists(string username) {
            bool usernameExists = await _dbContext.staff.AnyAsync(u => u.UserName == username);
            if (!usernameExists)
                return await _dbContext.staff.AnyAsync(u => u.Email == username);
            return usernameExists;
        }
        public void DisableAccount(staff staff)
        {
            try
            {
                _dbContext.Update(staff);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Disable Account:" + ex.Message);
            }
        }

        public async Task<staff> UpdateAsync(string id, staff employee)
        {
            var staffToUpdate = await GetByIdAsync(id);
            if (staffToUpdate != null)
            {
                Update(employee);
                await _dbContext.SaveChangesAsync();
            }
            return employee;
        }

        public async Task DeleteAsync(string id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
