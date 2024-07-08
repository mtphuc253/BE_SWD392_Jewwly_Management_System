using Microsoft.AspNetCore.Mvc;
using JewelleryShop.DataAccess.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly JewelleryDBContext _context;

        public CustomerController(JewelleryDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersById(int id)
        {
            var CustomerById = await _context.Customers.FindAsync(id);
            if (CustomerById == null)
            {
                return NotFound();
            }
            return Ok(CustomerById);
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            try { 
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomers", new { id = customer.Id }, customer);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerById(int id, [FromBody] Customer newCustomerData)
        {
            if (newCustomerData == null || newCustomerData.Id != id)
                return BadRequest();

            var existingCustomer = await _context.Customers.FindAsync(id);
            
            if (existingCustomer == null)
                return NotFound();

            existingCustomer.CustomerName = newCustomerData.CustomerName;
            existingCustomer.Address = newCustomerData.Address;
            existingCustomer.Gender = newCustomerData.Gender;
            existingCustomer.PhoneNumber = newCustomerData.PhoneNumber;
            existingCustomer.Email = newCustomerData.Email;
            existingCustomer.Status = newCustomerData.Status;

            _context.Customers.Update(existingCustomer);
            try { 
            await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("A concurrency error occurred while saving changes: " + ex.Message);
            }

            return NoContent(); // Success
        }
    }
}