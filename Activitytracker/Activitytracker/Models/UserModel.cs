using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Activitytracker.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "UserID")]
        public int UserID { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required ][DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name ="Email")]
        public String Email { get; set; }

        [Required]
        [Display(Name ="Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}