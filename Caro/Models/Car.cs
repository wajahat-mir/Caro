using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public string Plate { get; set; }
        [Required]
        public string modelYear { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public long currentMileage {get; set;}
        public DateTime? lastWashed { get; set; }
        public virtual ICollection<Maintainence> Maintainences { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}