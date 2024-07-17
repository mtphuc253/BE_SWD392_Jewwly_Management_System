using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks;

namespace JewelleryShop.DataAccess.Repository
{
    public class RewardsProgramRepository : GenericRepository<RewardsProgram>, IRewardsProgramRepository
    {
        private readonly JewelleryDBContext _dbContext;

        public RewardsProgramRepository(JewelleryDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RewardsProgram> GetByCustomerIdAsync(string customerId)
        {
            return await _dbContext.RewardsPrograms.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task UpdateRewardsProgramAsync(string customerId, int points)
        {
            var rewards = await GetByCustomerIdAsync(customerId);
            if (rewards != null)
            {
                rewards.PointsTotal = points;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}