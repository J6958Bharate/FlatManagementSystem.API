using System;
using System.Collections.Generic;

#nullable disable

namespace FlatManagementSystem.API.Models
{
    public partial class FlatType
    {
        public FlatType()
        {
            Users = new HashSet<User>();
        }

        public int FlatTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
