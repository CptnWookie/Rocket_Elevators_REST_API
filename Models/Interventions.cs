using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public partial class Interventions
    {
        public long Id { get; set; }
        public int Author { get; set; }
        public int CustomerId { get; set; }
        public int BuildingId { get; set; }
        public int? BatteryId { get; set; }
        public int? ColumnId { get; set; }
        public int? ElevatorId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? StartIntervention { get; set; }
        public DateTime? EndIntervention { get; set; }
        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
