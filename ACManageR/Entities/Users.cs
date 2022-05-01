using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ACManageR.Entities
{
    public partial class Users
    {
        public Users()
        {
            RequestsTechnician = new HashSet<Requests>();
            RequestsUser = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Requests> RequestsTechnician { get; set; }
        public virtual ICollection<Requests> RequestsUser { get; set; }
    }
}
