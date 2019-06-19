using Caro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Areas.admin.Models
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        [Required]
        public int perMileage { get; set; }
        [Required]
        public Maintain service { get; set; }
        public int ScheduleID { get; set; }
    }
}