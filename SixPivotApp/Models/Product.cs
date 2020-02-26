﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.Models
{
    public class Product
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public int? MaximumQuantity { get; set; }

    }
}
