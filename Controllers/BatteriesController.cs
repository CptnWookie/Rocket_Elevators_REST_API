using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly RocketContext _context;

        public BatteriesController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Batteries: All batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET: api/Batteries/10
        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> GetBatteries(long id)
        {
            var batteries = await _context.Batteries.FindAsync(id);

            if (batteries == null)
            {
                return NotFound();
            }

            return batteries;
        }

        // Will get all batteries of a building from a customer id
        // GET: api/Batteries/Buildings/{id}
        [HttpGet("Buildings/{id}")]
        public ActionResult<List<Batteries>> GetBatteriesFromBuilding(long id)
        {
            List<Batteries> batteriesAll = _context.Batteries.ToList();
            List<Batteries> batteriesFromBuilding = new List<Batteries>();
            foreach (Batteries battery in batteriesAll)
            {
                if (Convert.ToInt64(battery.BuildingId) == id)
                {
                    batteriesFromBuilding.Add(battery);
                }
            }
            return batteriesFromBuilding;
        }

        
        // 1.  Retrieving the current status of a specific Battery
        // GET: api/Batteries/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetBatteryStatus([FromRoute] long id)
        {
            var bb = await _context.Batteries.FindAsync(id);

            if (bb == null)
                return NotFound();
            Console.WriteLine("Get batterie status", bb.BatteryStatus);

            return bb.BatteryStatus;

        }


        //  2. Changing the status of a specific Battery  
        [HttpPut("{id}/Status/")]
        public async Task<IActionResult> UpdateStatus([FromRoute] long id, Batteries current)
        {

            if (id != current.Id)
            {
                return BadRequest();
            }

            if (current.BatteryStatus == "Active" || current.BatteryStatus == "Inactive" || current.BatteryStatus == "Intervention")
            {
                _context.Entry(current).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Battery: " + current.Id + ", status as been change to: " + current.BatteryStatus);
            }

            return Content("Please insert a valid status : Intervention, Inactive, Active, Tray again !  ");
        }




        // DELETE: api/Batteries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batteries>> DeleteBatteries(long id)
        {
            var batteries = await _context.Batteries.FindAsync(id);
            if (batteries == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(batteries);
            await _context.SaveChangesAsync();

            return batteries;
        }




        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}
