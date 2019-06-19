using Caro.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Models
{
    public class DashboardViewModel
    {
        public int CarId { get; set; }
        [DisplayName("License Plate")]
        public string Plate { get; set; }
        [DisplayName("Model Year")]
        public string modelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
    }
}