using System;
using System.Collections.Generic;

#nullable disable

namespace ReadyDev_backend.Models
{
    public partial class User
    {
        public User()
        {
            Families = new HashSet<Family>();
        }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Family> Families { get; set; }
    }
}
