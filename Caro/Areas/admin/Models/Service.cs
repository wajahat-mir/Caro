using Caro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Areas.admin.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int perMileage { get; set; }
        public Maintain service { get; set; }
        public int ScheduleID { get; set; }
        public Schedule schedule { get; set; }
    }
}