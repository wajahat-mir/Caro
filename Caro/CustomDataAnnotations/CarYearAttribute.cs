using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caro.CustomDataAnnotations
{
    public class CarYearAttribute : ValidationAttribute
    {
        public CarYearAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var modelYear = Convert.ToInt32(value);
            if (modelYear < 1900 || modelYear > (DateTime.Now.Year + 1))
                return false;
            return true;
        }

    }
}