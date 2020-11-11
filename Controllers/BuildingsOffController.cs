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


        // Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention
        // GET: api/BuildingsOff

        [HttpGet]
        public IEnumerable<Buildings> GetBuildings()
        {



            IEnumerable<Buildings> Building =

            from building in _context.Buildings
            join battery in _context.Batteries on building.Id equals battery.BuildingId
            join column in _context.Columns on battery.Id equals column.BatteryId
            join elevator in _context.Elevators on column.Id equals elevator.ColumnId
            where
            battery.BatteryStatus == "Intervention" || battery.BatteryStatus == "Inactive"
            || column.ColumnStatus == "Intervention" || column.ColumnStatus == "Inactive"
            || elevator.ElevatorStatus == "Intervention" || elevator.ElevatorStatus == "Inactive"
            select building;

            return Building.Distinct().ToList();

        }

        private bool BuildingsExists(long id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
