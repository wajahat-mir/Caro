using Caro.Areas.admin.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Caro.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public string modelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public List<Service> services { get; set; }
    }
}