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
    public class BuildingsOffController : ControllerBase
    {
        private readonly RocketContext _context;

        public BuildingsOffController(RocketContext context)
        {
            _context = context;
        }

        // Will get all the buildings based on a customer id
        // GET: api/buildings/customer/{id}
        [HttpGet("Customers/{id}")]
        public ActionResult<List<Buildings>> GetBuildingsFromCustomer(long id)
        {
            List<Buildings> buildingsAll = _context.Buildings.ToList();
            List<Buildings> buildingsFromCustomer = new List<Buildings>();
            foreach (Buildings building in buildingsAll)
            {
                if (building.CustomerId == id)
                {
                    buildingsFromCustomer.Add(building);
                }
            }
            return buildingsFromCustomer;
        }


        private bool BuildingsExists(long id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
