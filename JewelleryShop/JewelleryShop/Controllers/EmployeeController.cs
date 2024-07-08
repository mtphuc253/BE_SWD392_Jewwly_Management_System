using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess.Models.ViewModel.EmployeeViewModel;
using JewelleryShop.DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(EmployeeLoginDTO employee)
        {
            try
            {
                string token = await _employeeService.LoginAsync(employee);

                return Ok(
                    APIResponse<string>
                    .SuccessResponse(token, "Login successully.")
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, APIResponse<object>.ErrorResponse(new List<string> { ex.Message }, "An error occurred while logging in."));
            }
        } 
    }
}
