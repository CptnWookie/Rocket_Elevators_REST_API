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
    public class NotCostumersController : ControllerBase
    {
        private readonly RocketContext _context;

        public NotCostumersController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/NotCostumers
        // Retrieving a list of Leads created in the last 30 days who have not yet become customers.
        [HttpGet]
        public IEnumerable<Leads> GetLeads()
        {

            IEnumerable<Leads> Leads =
            from lead in _context.Leads
                // we select all the leads made it by non customers 
            where !(from c in _context.Customers select c.UserId).Contains(lead.UserId)
            // the last 30 days
            && lead.CreatedAt >= DateTime.UtcNow.AddDays(-30)
            select lead;

            return Leads.ToList();
        }


        private bool LeadsExists(long id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
