using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.RewardsProgramViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffShiftViewsModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service
{
    public class RewardsProgramService : IRewardsProgramService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RewardsProgramService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<RewardsProgramCommonDTO>> GetAllRewardsProgram()
        {
            var result = await _unitOfWork.RewardsProgramRepository.GetAllAsync();
            return _mapper.Map<List<RewardsProgramCommonDTO>>(result);
        }
        public async Task<RewardsProgramCommonDTO> GetRewardsProgramByCustomerIdAsync(string customerId)
        {
            var rewardsProgram = await _unitOfWork.RewardsProgramRepository.GetByCustomerIdAsync(customerId);
            return _mapper.Map<RewardsProgramCommonDTO>(rewardsProgram);
        }

        public async Task UpdateRewardsProgramAsync(string customerId, int points)
        {
            await _unitOfWork.RewardsProgramRepository.UpdateRewardsProgramAsync(customerId, points);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteRewardsProgramAsync(string customerId)
        {
            var rewardsProgram = await _unitOfWork.RewardsProgramRepository.GetByCustomerIdAsync(customerId);
            if (rewardsProgram != null)
            {
                _unitOfWork.RewardsProgramRepository.Remove(rewardsProgram);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task<RewardsProgramCommonDTO> AddRewardsProgram(RewardsProgramInputDTO rewards)
        {
            if (rewards == null)
            {
                throw new ArgumentNullException(nameof(rewards));
            }

            var existReward = await _unitOfWork.RewardsProgramRepository.GetByCustomerIdAsync(rewards.CustomerId);

            if (existReward != null && existReward.PointsTotal.HasValue)
            {
                existReward.PointsTotal = rewards.AddPoints + existReward.PointsTotal;
                _unitOfWork.RewardsProgramRepository.Update(existReward);
            }
            else
            {
                existReward = _mapper.Map<RewardsProgram>(rewards);
                existReward.PointsTotal = rewards.AddPoints;
                existReward.Id = Guid.NewGuid().ToString();
                await _unitOfWork.RewardsProgramRepository.AddAsync(existReward);
            }

            await _unitOfWork.SaveChangeAsync();

            var result = _mapper.Map<RewardsProgramCommonDTO>(existReward);

            return result;
        }
    }
}
