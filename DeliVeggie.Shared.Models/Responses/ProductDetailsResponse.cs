﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Shared.Models.Responses
{
    public class ProductDetailsResponse 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double CurrentPrice { get; set; }
    }
}
