using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACManageR.ViewModels
{
    public class LogInVM
    {
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [DisplayName("Password: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
