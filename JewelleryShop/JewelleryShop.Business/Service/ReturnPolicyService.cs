using AutoMapper;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.WarrantyViewModel;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelleryShop.DataAccess.Models.ViewModel.ReturnPolicyViewModel;
using System.Net;
using Microsoft.IdentityModel.Tokens;

namespace JewelleryShop.Business.Service
{
    public class ReturnPolicyService : IReturnPolicyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReturnPolicyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReturnPolicyCommonDTO> CreateReturnPolicy(ReturnPolicyCreateDTO returnPolicy)
        {
            returnPolicy.Id = returnPolicy.Id.IsNullOrEmpty() ? Guid.NewGuid().ToString() : returnPolicy.Id;
            var res = new ReturnPolicy();
            _mapper.Map(returnPolicy, res);

            await _unitOfWork.ReturnPolicyRepository.AddAsync(res);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<ReturnPolicyCommonDTO>(res);
        }
        public async Task<List<ReturnPolicyCommonDTO>> GetAllReturnPolicy()
        {
            var RPs = await _unitOfWork.ReturnPolicyRepository.GetAllAsync();

            return _mapper.Map<List<ReturnPolicyCommonDTO>>(RPs);
        }
        public async Task<ReturnPolicyCommonDTO> GetReturnPolicyByID(string id)
        {
            var RP = await _unitOfWork.ReturnPolicyRepository.GetByIdAsync(id);
            return _mapper.Map<ReturnPolicyCommonDTO>(RP);
        }
        public async Task<ReturnPolicyCommonDTO> UpdateReturnPolicy(string returnPolicyID, ReturnPolicyUpdateDTO returnPolicy)
        {
            var Dest_ReturnPolicy = await _unitOfWork.ReturnPolicyRepository.GetByIdAsync(returnPolicyID);
            _mapper.Map(returnPolicy, Dest_ReturnPolicy);
            _unitOfWork.ReturnPolicyRepository.Update(Dest_ReturnPolicy);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<ReturnPolicyCommonDTO>(Dest_ReturnPolicy);
        }
        public async Task DeleteReturnPolicy(string returnPolicyID)
        {
            var ReturnPolicy = await _unitOfWork.ReturnPolicyRepository.GetByIdAsync(returnPolicyID);
            if (ReturnPolicy != null)
            {
                _unitOfWork.ReturnPolicyRepository.Remove(ReturnPolicy);
                await _unitOfWork.SaveChangeAsync();
            }
            else
            {
                throw new ArgumentException("No Return Policy found with the provided ID.");
            }
        }
    }
}