using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly JewelleryDBContext _dbContext;
        public EmployeeRepository(JewelleryDBContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Employee?> CheckLoginCredentials(string usernameOrEmail, string passwordHash)
        {
            var user = await _dbContext.Employees
                .FirstOrDefaultAsync(record => 
                    (
                        record.UserName.Equals(usernameOrEmail) || 
                        record.Email.Equals(usernameOrEmail)
                    ));
            if (user == null) throw new Exception("Incorrect login credentials. Please try again");
            if (user.PasswordHash.Equals(passwordHash))
                return user;
            throw new Exception("Incorrect login credentials. Please try again");
        }

        public async Task<bool> CheckUserExists(string username) {
            bool usernameExists = await _dbContext.Employees.AnyAsync(u => u.UserName == username);
            if (!usernameExists)
                return await _dbContext.Employees.AnyAsync(u => u.Email == username);
            return usernameExists;
        }

    }
}
