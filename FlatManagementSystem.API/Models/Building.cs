using System;
using System.Collections.Generic;

#nullable disable

namespace FlatManagementSystem.API.Models
{
    public partial class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public int TotalFlatCount { get; set; }
        public int OwnerId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
