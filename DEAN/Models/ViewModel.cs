using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEAN.Models
{
    // Models/HealthStatsViewModel.cs
    public class HealthStatsViewModel
    {
        public HealthStat Today { get; set; }
        public HealthStat Yesterday { get; set; }
    }

}