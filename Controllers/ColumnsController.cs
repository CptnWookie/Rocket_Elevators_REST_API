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


        // GET: api/columns/battery/{id}
        [HttpGet("Batteries/{id}")]
        public ActionResult<List<Columns>> GetColumnsFromBattery(long id)
        {
            List<Columns> columnsAll = _context.Columns.ToList();
            List<Columns> columnsFromBattery = new List<Columns>();
            foreach (Columns column in columnsAll)
            {
                if (column.BatteryId == id)
                {
                    columnsFromBattery.Add(column);
                }
            }
            return columnsFromBattery;
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
        public async Task<IActionResult> UpdateStatus([FromRoute] long id, Columns mycolumn)
        {

            if (id != mycolumn.Id)
            {
                return BadRequest();
            }

            if (mycolumn.ColumnStatus == "Active" || mycolumn.ColumnStatus == "Inactive" || mycolumn.ColumnStatus == "Intervention")
            {
                _context.Entry(mycolumn).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Column: " + mycolumn.Id + ", status as been change to: " + mycolumn.ColumnStatus);
            }

            return Content("Please insert a valid status : Intervention, Inactive, Active, Tray again !  ");
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
