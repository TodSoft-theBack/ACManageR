using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ACManageR.Entities
{
    public partial class Statuses
    {
        public Statuses()
        {
            Requests = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string StatusType { get; set; }

        public virtual ICollection<Requests> Requests { get; set; }
    }
}
