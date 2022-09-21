using System;
using System.Collections.Generic;

#nullable disable

namespace ReadyDev_backend.Models
{
    public partial class Family
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FamilyName { get; set; }
        public string Logo { get; set; }
        public string Representative { get; set; }

        public virtual User User { get; set; }
    }
}
