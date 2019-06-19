using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.Models
{
    public class MaintainenceViewModel
    {
        public int MaintainenceId { get; set; }
        public DateTime? dateMaintained { get; set; }
        [Required]
        public long mileageMaintained { get; set; }
        [Required]
        public Maintain service { get; set; }

        public int CarId { get; set; }
    }
}