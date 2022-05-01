using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ACManageR.Entities
{
    public partial class Requests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public int StatusId { get; set; }
        public DateTime? TechVisitDate { get; set; }
        public int? TechnicianId { get; set; }
        public int UserId { get; set; }

        public virtual Statuses Status { get; set; }
        public virtual Users Technician { get; set; }
        public virtual Users User { get; set; }
    }
}
