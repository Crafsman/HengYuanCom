using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HengYuan.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime RecentVisitTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public string IPAddress { get; set; }
        public int VisitTimes { get; set; } = 1;
        public string Country { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
    }
}
