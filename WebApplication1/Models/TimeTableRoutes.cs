using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TimeTableRoutes
    {
        public DateTime Depart { get; set; }

        public string Timeleft { get; set; }

        public string Track { get; set; }

        public string TrainNumber { get; set; }

        public int Price { get; set; }
    }
}