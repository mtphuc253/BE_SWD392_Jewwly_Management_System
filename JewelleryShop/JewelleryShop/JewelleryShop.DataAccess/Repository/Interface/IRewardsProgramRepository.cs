using JewelleryShop.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository.Interface
{
    public interface IRewardsProgramRepository : IGenericRepository<RewardsProgram>
    {
        public Task<RewardsProgram> GetByCustomerIdAsync(string customerId);
        public Task UpdateRewardsProgramAsync(string customerId, int points);

    }
}
