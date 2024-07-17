
﻿using JewelleryShop.Business.Service;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess.Models.ViewModel.PromotionViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPromotionController : Controller
    {
        private readonly ICustomerPromotionService _customerPromotionService;

        public CustomerPromotionController(ICustomerPromotionService customerPromotionService)
        {
            _customerPromotionService = customerPromotionService;
        }

        [HttpGet]
        public async Task<IActionResult> ListPromotion()
        {
            var list = await _customerPromotionService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(CustomerPromotionDto promotion)
        {
            await _customerPromotionService.AddAsync(promotion);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Create successfully."));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePromotion(string id, CustomerPromotionDto promotion)
        {
            await _customerPromotionService.Update(id, promotion);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Update Successfully."));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(string id) 
        {
            await _customerPromotionService.Delete(id);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Delete Successfully."));
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApprovePromotion(string id)
        {
            await _customerPromotionService.Approve(id);
            return Ok(APIResponse<string>.SuccessResponse(data: null, "Approve successfully."));
        }

    }
}
