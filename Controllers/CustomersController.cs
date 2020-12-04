using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;
namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RocketContext _context;
        public CustomersController(RocketContext context)
        {
            _context = context;
        }

        // ========== Get all the infos about a customer (buildings, batteries, columns, elevators) using the customer_id ==========
        // GET: api/Customers/email
        [HttpGet("{email}")]
        public async Task<ActionResult<Customers>> GetCustomer(string email)
        {
            var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
                                                .Where(c => c.CompanyContactEmail == email)
                                                .FirstOrDefaultAsync();            
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        } 
        // ========== Verify email for register at the Customer's Portal =========================================================================
        // GET: api/Customers/verify/cindy@client.com
        [HttpGet("verify/{email}")]
        public async Task<ActionResult> VerifyEmail(string email)
        {
            var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
                                                .Where(c => c.CompanyContactEmail == email)
                                                .FirstOrDefaultAsync();            
            if (customer == null)
            {
                return NotFound();
            }
            return Ok();
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomers(long id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return customers;
        }
        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(long id, Customers customers)
        {
            if (id != customers.Id)
            {
                return BadRequest();
            }
            _context.Entry(customers).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomers", new { id = customers.Id }, customers);
        }
        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(long id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return customers;
        }
        private bool CustomersExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}