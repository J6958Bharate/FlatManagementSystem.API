using System;
using System.Collections.Generic;

#nullable disable

namespace FlatManagementSystem.API.Models
{
    public partial class Admin
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int BuildingCount { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
