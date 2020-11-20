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
    public class InterventionsController : ControllerBase
    {
        private readonly RocketContext _context;

        public InterventionsController(RocketContext context)
        {
            _context = context;
        }

        // GET: api/Interventions : All interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // Retrieving a specific Intervention
        // GET: api/Interventions/10 
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }

        // Retrieving the current status of a specific Intervention
        // GET: api/Interventions/{id}/status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetInterventionStatus([FromRoute] long id)
        {
            var cc = await _context.Interventions.FindAsync(id);

            if (cc == null)
                return NotFound();
            Console.WriteLine("Get Intervention status", cc.Status);

            return cc.Status;

        }

        // Changing the status of a specific Intervention
        [HttpPut("{id}/Status")]
        public async Task<IActionResult> UpdateInterventionStatus([FromRoute] long id, Interventions intervention)
        {


            if (id != intervention.Id)
            {
                Console.WriteLine(intervention.Id);
                return Content("Wrong id ! please check and try again");
            }

            if (intervention.Status == "Pending" || intervention.Status == "InProgress" || intervention.Status == "Interrupted" || intervention.Status == "Resumed" || intervention.Status == "Complete")
            {
                _context.Entry(intervention).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Intervention: " + intervention.Id + ", status as been change to: " + intervention.Status);
            }

            return Content("Please insert a valid status : Pending, InProgress, Interrupted, Resumed, Complete, Try again !");
        }


        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interventions>> DeleteInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(interventions);
            await _context.SaveChangesAsync();

            return interventions;
        }

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
