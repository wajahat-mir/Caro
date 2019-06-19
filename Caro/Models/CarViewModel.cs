using Caro.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Models
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Cars),
              ErrorMessageResourceName = "PlateRequired")]
        [Display(Name = "Plate", ResourceType = typeof(Resources.Cars))]
        public string Plate { get; set; }
        [Required]
        [DisplayName("Model Year")]
        [CarYear(ErrorMessage ="Model Year is not valid")]
        public string modelYear { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [DisplayName("Current Mileage")]
        public long currentMileage { get; set; }
        [DisplayName("Last Date Time Washed")]
        public DateTime? lastWashed { get; set; }
    }
}