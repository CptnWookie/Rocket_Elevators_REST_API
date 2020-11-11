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
    public class BatteriesController : ControllerBase
    {
        private readonly RocketContext _context;

        public BatteriesController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET: api/Batteries/5
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

        // PUT: api/Batteries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteries(long id, Batteries batteries)
        {
            if (id != batteries.Id)
            {
                return BadRequest();
            }

            _context.Entry(batteries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteriesExists(id))
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

        // POST: api/Batteries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Batteries>> PostBatteries(Batteries batteries)
        {
            _context.Batteries.Add(batteries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteries", new { id = batteries.Id }, batteries);
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

        // POST: api/Batteries/{id}/status
        // [HttpPut("{id}/Status/")]
        // public async Task<ActionResult> UpdateBatteryStatus([FromRoute] long id)
        // {
        //     var bb = await _context.Batteries.FindAsync(id);

        //     if (bb == null)
        //     {
        //         return NotFound();
        //     }
        //     if (bb.BatteryStatus == "ACTIVE")
        //     {
        //         bb.BatteryStatus = "INACTIVE";
        //     }

        //     else { bb.BatteryStatus = "ACTIVE"; }

        //     _context.Batteries.Update(bb);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        [HttpPut("{id}/Status/")]
        public async Task<IActionResult> UpdateStatus([FromRoute] long id, Batteries item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }

            if (item.BatteryStatus == "Intervention" || item.BatteryStatus == "Active" || item.BatteryStatus == "Inactive")
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Battery: " + item.Id + ", status as been change to: " + item.BatteryStatus);
            }

            return Content("You need to insert a valid status : Intervention, Inactive, Active, Thank you !  ");
        }


        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.Id == id);
        }
    }
}
