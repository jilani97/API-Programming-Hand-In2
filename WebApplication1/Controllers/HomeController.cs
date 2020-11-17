using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BLL;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private TrainTicketContext db = new TrainTicketContext();

        private ITicket _BLL;

        public HomeController()
        {
            _BLL = new TicketBLL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetLocation(string searchInput)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.entur.io/geocoder/v1/autocomplete?text=" + searchInput + "&lang=en");
            HttpContent content = response.Content;
            var feature = await content.ReadAsStringAsync();
            List<EnTurAPI> locationStops = new List<EnTurAPI> { };
            List<EnTurAPI> empty = new List<EnTurAPI>();
            try
            {
                dynamic results = JsonConvert.DeserializeObject(feature);
                foreach (dynamic e in results["features"])
                {
                    EnTurAPI location = new EnTurAPI();
                    location.location = e["properties"]["label"].ToString() as string;
                    locationStops.Add(location);
                }
            }
            catch(Exception e) { Console.WriteLine("Exception",e); };
            if (searchInput == null) { searchInput = ""; }
            return Json(locationStops.ToList().FindAll(x => x.location.Contains(searchInput)), JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult Timetable(Ticket route)
        {
            if (route.DestinationFrom != null)
            {
                TimeSpan t15Minutes = new TimeSpan(0, 0, 15, 0);
                TimeSpan t30Minutes = new TimeSpan(0, 0, 30, 0);
                TimeSpan t45Minutes = new TimeSpan(0, 0, 45, 0);
                TimeSpan t60Minutes = new TimeSpan(0, 1, 0, 0);

                var totalPrice = 0;
                totalPrice += 37 * route.AdultsTravelling;
                totalPrice += 30 * route.StudentsTravelling;
                totalPrice += 15 * route.ChildrenTravelling;
                List<TimeTableRoutes> routesGenerated = new List<TimeTableRoutes> {
                new TimeTableRoutes{
                    Depart = route.TravelTime  + t15Minutes,
                    Timeleft = (DateTime.Now - (route.TravelTime + t15Minutes)).ToString("mm"),
                    Track = route.DestinationFrom,
                    TrainNumber = route.DestinationTo.Substring(1,2).ToUpper()+"37",
                    Price = totalPrice },
                new TimeTableRoutes{
                    Depart = route.TravelTime + t30Minutes,
                    Timeleft = (DateTime.Now - (route.TravelTime + t30Minutes)).ToString("mm"),
                    Track = route.DestinationFrom,
                    TrainNumber = route.DestinationTo.Substring(1,2)+"22",
                    Price = totalPrice },
                new TimeTableRoutes{
                    Depart = route.TravelTime + t45Minutes,
                    Timeleft = (DateTime.Now - (route.TravelTime + t45Minutes)).ToString("mm"),
                    Track = route.DestinationFrom,
                    TrainNumber = route.DestinationTo.Substring(1,2)+"72",
                    Price = totalPrice },
                new TimeTableRoutes{
                    Depart = route.TravelTime + t60Minutes,
                    Timeleft = (DateTime.Now - (route.TravelTime + t60Minutes)).ToString("mm"),
                    Track = route.DestinationFrom,
                    TrainNumber = route.DestinationTo.Substring(1,2)+"77",
                    Price = totalPrice },

            };
                PurchaseTicketViewModel ticketModel = new PurchaseTicketViewModel { routeList = routesGenerated.ToList(), ticket = route };
            return PartialView("Timetable", ticketModel);
            }
            List<TimeTableRoutes> empty = new List<TimeTableRoutes>();
            Ticket emptyTicket = new Ticket();
            PurchaseTicketViewModel emtpyRoute = new PurchaseTicketViewModel { routeList = empty, ticket = emptyTicket };
            return PartialView(emtpyRoute);
        }

        public ActionResult Purchase(
            string destFrom, string destTo, int adults, int children, int studs, DateTime travelDate, DateTime travelTime,
            DateTime depart, string timeLeft, string trainNr, string track, int price
            )
         {
            var newRoute = new TimeTableRoutes
            {
                Depart = depart,
                Timeleft = timeLeft,
                TrainNumber = trainNr,
                Track = track,
                Price = price,
            };

            var newTicket = new Ticket
            {
                AdultsTravelling = adults,
                ChildrenTravelling = children,
                StudentsTravelling = studs,
                DestinationFrom = destFrom,
                TravelDate = travelDate,
                TravelTime = travelTime,
                IsValid = true,
                route = newRoute,
                DestinationTo = destTo
            };

            if (ModelState.IsValid)
            {
                bool ok = _BLL.CreateTicket(newTicket);
                bool receiptOK = _BLL.CreateReceipt(newTicket);
                if (ok && receiptOK)
                {
                    return View(newTicket);
                }
            }

            return RedirectToAction("Index");

         }

         [HttpGet]
         public ActionResult receipts()
         {
            List<Receipt> allReceipts = _BLL.GetReceiptList();
             return View(allReceipts);
         }

    }
}