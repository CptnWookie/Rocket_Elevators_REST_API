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
    public class EmployeesController : ControllerBase
    {
        private readonly RocketContext _context;

        public EmployeesController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Elevators : All elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetElevators()
        {
            return await _context.Employees.ToListAsync();
        }

                private bool EmployeesExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}