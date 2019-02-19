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
        public DateTime VisitTime { get; set; } = DateTime.UtcNow;
        public string IPAddress { get; set; }
    }
}
