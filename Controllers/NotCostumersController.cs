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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leads>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();





        }


        private bool LeadsExists(long id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
