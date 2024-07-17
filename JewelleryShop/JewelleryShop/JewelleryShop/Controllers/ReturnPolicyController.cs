using AutoMapper;
using JewelleryShop.Business.Service;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess.Models.ViewModel.ItemImageViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.ReturnPolicyViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.RewardsProgramViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnPolicyController : ControllerBase
    {
        private readonly IReturnPolicyService _returnPolicyService;
        public ReturnPolicyController(IReturnPolicyService returnPolicyService)
        {
            _returnPolicyService = returnPolicyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReturnPolicy()
        {
            try
            {
                var result = await _returnPolicyService.GetAllReturnPolicy();
                return Ok(
                    APIResponse<List<ReturnPolicyCommonDTO>>
                        .SuccessResponse(data: result, "Successfully Fetched Return Policies.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpGet("{returnPolicyID}")]
        public async Task<ActionResult<RewardsProgramCommonDTO>> GetReturnPolicy(string returnPolicyID)
        {
            try
            {
                var result = await _returnPolicyService.GetReturnPolicyByID(returnPolicyID);
                return Ok(
                    APIResponse<ReturnPolicyCommonDTO>
                        .SuccessResponse(data: result, "Successfully Fetched Return Policy.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReturnPolicy(ReturnPolicyCreateDTO rewardsProgramInputDTO)
        {
            try
            {
                var result = await _returnPolicyService.CreateReturnPolicy(rewardsProgramInputDTO);
                return Ok(
                    APIResponse<ReturnPolicyCommonDTO>
                        .SuccessResponse(data: result, "Successfully fetched Return Policies.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpPut("{returnPolicyID}")]
        public async Task<IActionResult> UpdateReturnPolicy(string returnPolicyID, ReturnPolicyUpdateDTO returnPolicyUpdateDTO)
        {
            try
            {
                var result = await _returnPolicyService.UpdateReturnPolicy(returnPolicyID, returnPolicyUpdateDTO);
                return Ok(
                    APIResponse<ReturnPolicyCommonDTO>
                        .SuccessResponse(data: result, "Successfully Updated Return Policy.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpDelete("{returnPolicyID}")]
        public async Task<IActionResult> DeleteReturnPolicy(string returnPolicyID)
        {
            try
            {
                await _returnPolicyService.DeleteReturnPolicy(returnPolicyID);
                return Ok(
                    APIResponse<string>
                        .SuccessResponse(returnPolicyID, "Successfully Deleted Return Policy.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

    }
}



