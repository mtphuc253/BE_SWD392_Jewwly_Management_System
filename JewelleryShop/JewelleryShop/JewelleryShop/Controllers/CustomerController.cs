using Microsoft.AspNetCore.Mvc;
using JewelleryShop.DataAccess.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using JewelleryShop.DataAccess.Models.dto;
using AutoMapper;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using Newtonsoft.Json.Linq;

using AutoMapper;
using JewelleryShop.DataAccess.Models.ViewModel.CustomerViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess;
using JewelleryShop.Business.Service.Interface;


namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var data = await _customerService.GetAllAsync();

                return Ok(
                    APIResponse<List<CustomerCommonDTO>>
                    .SuccessResponse(data, "Successfully fetched customers.")
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, 
                        APIResponse<object>.ErrorResponse(new List<string> { ex.Message }, 
                        "An error occurred while fetching customers."
                    )
                );
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersById(string id)
        {
            try
            {
                var customerById = await _customerService.GetByIDAsync(id);

                if (customerById == null)
                {
                    return NotFound();
                }

                return Ok(customerById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, APIResponse<object>.ErrorResponse(new List<string> { ex.Message }, "An error occurred while retrieving the customer."));
            }
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetCustomersByEmail(string email)
        {
            try
            {
                var customerByEmail = await _customerService.GetByEmailAsync(email);
                if (customerByEmail == null)
                {
                    return NotFound();
                }
                return Ok(customerByEmail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, APIResponse<object>.ErrorResponse(new List<string> { ex.Message }, "An error occurred while retrieving the customer."));
            }
        }

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetCustomersByPhoneNumber(string phone)
        {
            try
            {
                var customerByPhone = await _customerService.GetByPhoneNumberAsync(phone);
                if (customerByPhone == null)
                {
                    return NotFound();
                }
                return Ok(customerByPhone);
            }
            catch (Exception ex)
            {
                return StatusCode(500, APIResponse<object>.ErrorResponse(new List<string> { ex.Message }, "An error occurred while retrieving the customer."));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerInputDTO customerDto)
        {
            try
            {
                var customer = await _customerService.CreateCustomerAsync(customerDto);
                if (customer == null)
                {
                    return StatusCode(500, APIResponse<object>.ErrorResponse(new List<string>(), "An error occurred while creating the customer."));
                }
                return CreatedAtAction("GetCustomersById", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerById(string id, [FromBody] CustomerInputDTO newCustomerData)
        {
            try
            {
                var updatedCustomerDto = await _customerService.UpdateCustomerAsync(id, newCustomerData);

                if (updatedCustomerDto == null)
                {
                    return NotFound();
                }

                return Ok(updatedCustomerDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}