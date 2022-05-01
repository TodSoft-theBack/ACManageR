using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACManageR.ViewModels
{
    public class MakeRequestVM
    {
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DisplayName("Description: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Address: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DisplayName("Picture: ")]
        [DataType(DataType.ImageUrl, ErrorMessage = "You must select an image file!")]
        public IFormFile Picture { get; set; }
    }
}
