using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiThing.Models
{
    public class Temperature
    {
        [Required]
        public int TempId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        [Range(-200,1000)]
        public double CelsiusValue { get; set; }
    }

    public enum TempType
    {
        Celsius,
        Ferenheight,
        Kelvin
    }
}
