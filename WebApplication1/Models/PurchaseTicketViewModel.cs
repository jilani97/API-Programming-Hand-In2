using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PurchaseTicketViewModel
    {
        public Ticket ticket { get; set; }
        public List<TimeTableRoutes> routeList { get; set; }
    }
}