using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACManageR.ViewModels
{
    public class EditUserVM
    {
        public int Id { get; set; }
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [DisplayName("Role: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public int RoleId { get; set; }
        public List<SelectListItem> RoleOptions { get; set; }
    }
}
