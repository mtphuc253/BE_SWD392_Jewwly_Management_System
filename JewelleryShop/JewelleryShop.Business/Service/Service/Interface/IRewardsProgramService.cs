using JewelleryShop.DataAccess.Models.ViewModel.RewardsProgramViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IRewardsProgramService
    {
        public Task<List<RewardsProgramCommonDTO>> GetAllRewardsProgram();
        public Task<RewardsProgramCommonDTO> GetRewardsProgramByCustomerIdAsync(string customerId);
        public Task UpdateRewardsProgramAsync(string customerId, int points);
        public Task DeleteRewardsProgramAsync(string customerId);
        public Task<RewardsProgramCommonDTO> AddRewardsProgram(RewardsProgramInputDTO rewardsProgramDTO);
    }
}
