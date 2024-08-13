using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
namespace DEAN.Models
{
    public class Common
    {
        public int UserId { get; set; }
        public int Steps { get; set; }
        public decimal WaterIntake { get; set; }
        public decimal SleepDuration { get; set; }
        public HealthStat Today { get; set; }
        public HealthStat Yesterday { get; set; }

    }
}
