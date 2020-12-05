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
        

        [Produces("application/json")]

            // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Getcustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // GET: api/Customers/email
        [HttpGet("Email/{email}")]
        public async Task<ActionResult<Customers>> GetCustomerEmail(string email)
        {

            IEnumerable<Customers> customersAll = await _context.Customers.ToListAsync();

            foreach (Customers customer in customersAll)
            {
                if (customer.CompanyContactEmail == email)
                {
                    return customer;
                }
            }
            return NotFound();
        }
    }
}