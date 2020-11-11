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
    public class ElevatorsController : ControllerBase
    {
        private readonly RocketContext _context;

        public ElevatorsController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Elevators : All elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevators>>> GetElevators()
        {
            return await _context.Elevators.ToListAsync();
        }

        // Retrieving a specific Elevator
        // GET: api/Elevators/10 
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevators>> GetElevators(long id)
        {
            var elevators = await _context.Elevators.FindAsync(id);

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

        // Retrieving the current status of a specific Elevator
        // GET: api/Elevators/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetElevatorStatus([FromRoute] long id)
        {
            var cc = await _context.Elevators.FindAsync(id);

            if (cc == null)
                return NotFound();
            Console.WriteLine("Get Elevator status", cc.ElevatorStatus);

            return cc.ElevatorStatus;

        }

        // Changing the status of a specific Elevator




        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Elevators>> DeleteElevators(long id)
        {
            var elevators = await _context.Elevators.FindAsync(id);
            if (elevators == null)
            {
                return NotFound();
            }

            _context.Elevators.Remove(elevators);
            await _context.SaveChangesAsync();

            return elevators;
        }

        private bool ElevatorsExists(long id)
        {
            return _context.Elevators.Any(e => e.Id == id);
        }
    }
}
