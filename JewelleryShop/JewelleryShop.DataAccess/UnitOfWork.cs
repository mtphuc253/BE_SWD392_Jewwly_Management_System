using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JewelleryDBContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public UnitOfWork(JewelleryDBContext dbContext, IEmployeeRepository employeeRepository)
        {
            _dbContext = dbContext;
            _employeeRepository = employeeRepository;
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
