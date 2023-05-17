using System;
using System.Collections.Generic;

#nullable disable

namespace FlatManagementSystem.API.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int FlatTypeId { get; set; }
        public int LocationId { get; set; }
        public int BuildingId { get; set; }
        public int OwnerId { get; set; }

        public virtual FlatType FlatType { get; set; }
        public virtual Location Location { get; set; }
    }
}
