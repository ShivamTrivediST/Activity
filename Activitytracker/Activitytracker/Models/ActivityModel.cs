using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Activitytracker.Models
{
    public class ActivityModel
    {
        [Key]
        public int ActivityID { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "FromTime")]
        public string FromTime { get; set; }
        [Required]
        [Display(Name = "ToTime")]
        public string ToTime { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public string Duration { get; set; }    
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}