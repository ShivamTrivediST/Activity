using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Activitytracker.Models
{
    public class LoginModel
    {
        
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email..")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email")]
        public String Email { get; set; }

        
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password length must between 8 to 20..")]
        public string Password { get; set; }
    }
}