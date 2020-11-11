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
    public class ColumnsController : ControllerBase
    {
        private readonly RocketContext _context;

        public ColumnsController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Columns>>> GetColumns()
        {
            return await _context.Columns.ToListAsync();
        }

        // GET: api/Columns/10
        [HttpGet("{id}")]
        public async Task<ActionResult<Columns>> GetColumns(long id)
        {
            var columns = await _context.Columns.FindAsync(id);

            if (columns == null)
            {
                return NotFound();
            }

            return columns;
        }

        // Retrieving the current status of a specific Column
        // GET: api/Columns/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetColumnStatus([FromRoute] long id)
        {
            var cc = await _context.Columns.FindAsync(id);

            if (cc == null)
                return NotFound();
            Console.WriteLine("Get batterie status", cc.ColumnStatus);

            return cc.ColumnStatus;

        }

        // Changing the status of a specific Column
        [HttpPut("{id}/Status/")]
        public async Task<IActionResult> UpdateStatus([FromRoute] long id, Columns current)
        {

            if (id != current.Id)
            {
                return BadRequest();
            }

            if (current.ColumnStatus == "Active" || current.ColumnStatus == "Inactive" || current.ColumnStatus == "Intervention")
            {
                _context.Entry(current).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Column: " + current.Id + ", status as been change to: " + current.ColumnStatus);
            }

            return Content("Please insert a valid status : Intervention, Inactive, Active, Tray again !  ");
        }


        // PUT: api/Columns/10
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumns(long id, Columns columns)
        {
            if (id != columns.Id)
            {
                return BadRequest();
            }

            _context.Entry(columns).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnsExists(id))
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

        // POST: api/Columns
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Columns>> PostColumns(Columns columns)
        {
            _context.Columns.Add(columns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumns", new { id = columns.Id }, columns);
        }

        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Columns>> DeleteColumns(long id)
        {
            var columns = await _context.Columns.FindAsync(id);
            if (columns == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(columns);
            await _context.SaveChangesAsync();

            return columns;
        }

        private bool ColumnsExists(long id)
        {
            return _context.Columns.Any(e => e.Id == id);
        }
    }
}
