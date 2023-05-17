using System;
using System.Collections.Generic;

#nullable disable

namespace FlatManagementSystem.API.Models
{
    public partial class Location
    {
        public Location()
        {
            Admins = new HashSet<Admin>();
            Buildings = new HashSet<Building>();
            Users = new HashSet<User>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
