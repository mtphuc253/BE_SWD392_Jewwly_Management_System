using JewelleryShop.DataAccess.Models.ViewModel.GemstoneViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryShop.Business.Service.Interface
{
    public interface IGemstoneService
    {
        public Task<List<GemstoneCommonDTO>> GetAllGemstones();
        public Task<GemstoneCommonDTO> GetGemstoneById(string id);
        public Task<GemstoneCommonDTO> AddGemstone(GemstoneInputDTO gemstone);
        public Task<GemstoneCommonDTO> UpdateGemstoneAsync(string id, GemstoneInputDTO gemstoneDTO);
        public Task DeleteGemstoneAsync(string id);
    }
}
