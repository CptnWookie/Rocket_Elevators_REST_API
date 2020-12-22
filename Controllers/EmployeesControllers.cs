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

        // GET: api/Employees : All employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetElevators()
        {
            return await _context.Employees.ToListAsync();
        }

                private bool EmployeesExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(long id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/employees/email
        [HttpGet("employees/{email}")]
        public async Task<ActionResult<Employee>> GetEmployeesEmail(string email)
        {
            IEnumerable<Employee> employeesAll = await _context.employees.ToListAsync();
            foreach (Employee employee in employeesAll)
            {
                if (employee.email == email)
                {
                    return employee;
                }
            }
            return NotFound();
        }
    }
}