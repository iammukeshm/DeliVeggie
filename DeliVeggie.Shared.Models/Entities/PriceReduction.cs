using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Shared.Models.Entities
{
    public class PriceReduction
    {
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}
