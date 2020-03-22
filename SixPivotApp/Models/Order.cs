using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItem> LineItems { get; set; }
    }
}
