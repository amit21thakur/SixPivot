using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixPivotApp.Models
{
    public class FxRate
    {
        public string SourceCurrency { get; set; }

        public string TargetCurrency { get; set; }

        public double Rate { get; set; }
    }
}
