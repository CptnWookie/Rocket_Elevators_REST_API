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

        // ========== Get all the infos about a customer (buildings, batteries, columns, elevators) using the customer_id ==========
        // GET: api/Customers/email
        // [HttpGet("Products/{email}")]
        // public async Task<ActionResult<Customers>> GetCustomerEmail(string email)
        // {
        //     var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
        //                                         .Where(c => c.CompanyContactEmail == email)
        //                                         .FirstOrDefaultAsync();            
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }
        //     return customer;
        // } 

        // ========== Get all the infos about a customer (buildings, batteries, columns, elevators) using the customer_id ==========
        
        // GET: api/Customers/email
        // [HttpGet("{email}/All")]
        // public  IEnumerable<Customers> GetCustomer(string email)
        // {


        //     IEnumerable<Customers> Customers =

        //     from customer in _context.Customers
        //     join building in _context.Buildings on customer.Id equals building.CustomerId
        //     join battery in _context.Batteries on building.Id equals battery.BuildingId
        //     join column in _context.Columns on battery.Id equals column.BatteryId
        //     join elevator in _context.Elevators on column.Id equals elevator.ColumnId
        //     where
        //     customer.CompanyContactEmail == email || building.CustomerId == customer.Id  ||battery.BuildingId == building.Id
        //     || column.BatteryId == battery.Id || elevator.ColumnId == column.Id 
        //     select customer;       

        //     return Customers.Distinct().ToList();
        // } 

        

        
        
        // [HttpGet("{email}/Buildings")]
        // public  IEnumerable<Buildings> GetCustomerBuildings(string email)
        // {
        //     IEnumerable<Buildings> Buildings =

        //     from building in _context.Buildings
        //     join customer in _context.Customers on "" equals customer.CompanyContactEmail
        //     where customer.CompanyContactEmail == email

        //     return Buildings.Distinct().ToList();

        // }







        //========== Verify email for register at the Customer's Portal =========================================================================
        //GET: api/Customers/verify/cindy@client.com
        // [HttpGet("verify/{email}")]
        // public async Task<ActionResult> VerifyEmail(string email)
        // {
        //     // var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
        //     //                                     .Where(c => c.CompanyContactEmail == email)
        //     //                                     .FirstOrDefaultAsync();  

        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok();
        // }


        // GET: api/Customers
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        // {
        //     return await _context.Customers.ToListAsync();
        // }
        
        // // POST: api/Customers
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        // {
        //     _context.Customers.Add(customers);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction("GetCustomers", new { id = customers.Id }, customers);
        // }
    }
}