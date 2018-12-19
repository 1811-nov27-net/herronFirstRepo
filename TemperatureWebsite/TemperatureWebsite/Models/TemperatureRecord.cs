using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureWebsite.Models
{
    public class TemperatureRecord
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }

        public int Unit { get; set; }

        public string UnitId => UnitName(Unit);

        public static string UnitName(int id)
        {
            switch (id)
            {
                case 1:
                    return "Celsius";
                case 2:
                    return "Fahrenheit";
                default:
                    return null;
            }
        }

    }
}
