using AutoMapper;
using BCrypt.Net;
using JewelleryShop.Business.Service;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess.Models.ViewModel.StaffShiftViewsModel;
using JewelleryShop.DataAccess.Models.ViewModel.StaffViewModel;
using JewelleryShop.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StaffStationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStaffStationService _staffShiftService;

        public StaffStationController(IMapper mapper, IStaffStationService staffShiftService)
        {
            _mapper = mapper;
            _staffShiftService = staffShiftService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStaffShifts()
        {
            var result = await _staffShiftService.GetAllStaffShifts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffShiftById(string id)
        {
            var result = await _staffShiftService.GetStaffShiftById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaffShift(StaffShiftInputDTO staffshift)
        {
            var result = await _staffShiftService.AddStaffShift(staffshift);
            return CreatedAtAction("GetStaffShiftById", new { id = result.StationId }, result);
        }

        [HttpPut("Shift/{id}")]
        public async Task<IActionResult> UpdateShift(string id, StaffShiftInputDTO shift)
        {
            try
            {
                var updatedShi = await _staffShiftService.UpdateStaffShiftAsync(id, shift);
                return Ok(APIResponse<StaffShiftCommonDTO>.SuccessResponse(updatedShi, "Employee updated successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    APIResponse<object>.ErrorResponse(
                        new List<string> { ex.Message }, "An error occurred while updating shift."));
            }
        }

        [HttpDelete("Shift/{id}")]
        public async Task<IActionResult> DeleteShift(string id)
        {
            try
            {
                await _staffShiftService.DeleteShiftAsync(id);
                return Ok(APIResponse<string>.SuccessResponse(id, "Shift deleted successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    APIResponse<object>.ErrorResponse(
                        new List<string> { ex.Message }, "An error occurred while deleting shift."));
            }
        }
    }
}

