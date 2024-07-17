using JewelleryShop.Business.Service;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess.Models.ViewModel.GemstoneViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GemstoneController : ControllerBase
    {
        private readonly IGemstoneService _gemstoneService;
        public GemstoneController(IGemstoneService gemstoneService)
        {
            _gemstoneService = gemstoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGemstone()
        {
            var gemstones = await _gemstoneService.GetAllGemstones();
            return Ok(gemstones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGemstoneById(string id)
        {
            var gemstones = await _gemstoneService.GetGemstoneById(id);
            if (gemstones == null)
            {
                var response = APIResponse<CollectionCommonDTO>
                    .ErrorResponse(new List<string> { "No Gemstone found with the provided ID." });
                return NotFound(response);
            }
            return Ok(gemstones);
        }

        [HttpPost]
        public async Task<IActionResult> AddGemstone(GemstoneInputDTO gemstones)
        {
            var newGem = await _gemstoneService.AddGemstone(gemstones);
            return CreatedAtAction(nameof(GetGemstoneById), new { id = newGem.Id }, newGem);
        }

        [HttpPut("Gemstone/{id}")]
        public async Task<IActionResult> UpdateGemstoneAsync(string id, GemstoneInputDTO gemstones)
        {
            try
            {
                var updatedGemstone = await _gemstoneService.UpdateGemstoneAsync(id, gemstones);
                return Ok(updatedGemstone);
            }
            catch (Exception ex)
            {
                var response = APIResponse<CollectionInputDTO>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpDelete("Gemstone/{id}")]
        public async Task<IActionResult> DeleteGemstoneAsync(string id)
        {
            try
            {
                await _gemstoneService.DeleteGemstoneAsync(id);
                var response = APIResponse<string>.SuccessResponse(id, "Gemstone deleted successfully");
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return NotFound(response);
            }
        }
    }
}
