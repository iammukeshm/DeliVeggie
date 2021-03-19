using System;
using System.Collections.Generic;

namespace DeliVeggie.Shared.Models.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
        public IEnumerable<PriceReduction> PriceReductions { get; set; }
    }
}