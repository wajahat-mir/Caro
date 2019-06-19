using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Areas.admin.Models
{
    public class ScheduleViewModel
    {
        public int ScheduleID { get; set; }
        [Required]
        [DisplayName("Model Year")]
        public string modelYear { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
    }
}