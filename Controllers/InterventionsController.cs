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
        [HttpGet("Status/Pending")]
        public ActionResult<List<Interventions>> GetPending () {
            var list = _context.Interventions.ToList ();
            if (list == null) {
                return NotFound ("Not Found");
            }

            List<Interventions> list_pending = new List<Interventions> ();
            foreach (var i in list) {
                if ((i.Status == "Pending") && (i.StartIntervention == null)) {
                    list_pending.Add (i);
                }
            }

            return list_pending;
        }

        // Retrieving a specific Intervention
        // GET: api/Interventions/10 
        [HttpGet("Status/Pending")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
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
       

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
