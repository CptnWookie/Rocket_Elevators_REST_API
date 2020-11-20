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

        // Returns all fields of all Service Request records that do not have a start date and are in "Pending" status.
        // GET: api/Interventions/Status/Pending
        [HttpGet("Status/Pending")]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventionsPending() 
        {
            var intpending = await _context.Interventions.Where(intervention => intervention.Status == "Pending" && intervention.StartIntervention == null).ToListAsync();

            if (intpending == null) {
                return NotFound ("Great Work! No Intervention left !");
            }

            return intpending;
        }


        // Change the status of the intervention request to "InProgress" and add a start date and time (Timestamp).
        // PUT: api/Interventions/10/Init
        [HttpPut("{id}/Start")]
        public async Task<IActionResult> PutInterventionInProgress([FromRoute] long id, Interventions intervention)
        {
            if (id != intervention.Id)
            {                
                return Content("Wrong id ! please check and try again");
            }

            if (intervention.Status == "InProgress")
            {
                intervention.StartIntervention = DateTime.Now;
                _context.Update(intervention).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Intervention: " + intervention.Id + ", status as been change to: " + intervention.Status + " and Start Intervention has been set to " + intervention.StartIntervention );
            }

            return Content("Please insert a valid status : InProgress ....... Please try again !");
        }


        // Change the status of the request for action to "Completed" and add an end date and time (Timestamp).
        // PUT: 
        [HttpPut("{id}/End")]
        public async Task<IActionResult> PutInterventionCompleted([FromRoute] long id, Interventions intervention)
        {
            if (id != intervention.Id)
            {                
                return Content("Wrong id ! please check and try again");
            }

            if (intervention.Status == "Complete")
            {
                intervention.EndIntervention = DateTime.Now;
                _context.Update(intervention).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Content("Intervention: " + intervention.Id + ", status as been change to: " + intervention.Status + " and Start Intervention has been set to " + intervention.EndIntervention );
            }

            return Content("Please insert a valid status : Complete ....... Please try again !");
        }

        

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
