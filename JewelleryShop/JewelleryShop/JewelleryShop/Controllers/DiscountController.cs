using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.dto;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscountList()
        {
            var list = await _discountService.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);

            if (discount == null)
            {
                return NotFound();
            }

            return Ok(discount);
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> CreateDiscount(Discount request)
        {
            await _discountService.AddAsync(request);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Create successfully."));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, DiscountDto discount)
        {
            await _discountService.Update(id, discount);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Update successfully."));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _discountService.RemoveAsync(id);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Delete successfully."));
        }

     
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveDiscount(int id)
        {
            await _discountService.Approve(id);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Approve successfully."));
        }

  
        [HttpPut("request/{id}")]
        public async Task<IActionResult> RequestDiscount(int id)
        {
            await _discountService.Request(id);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Request successfully."));
        }
    }
}
