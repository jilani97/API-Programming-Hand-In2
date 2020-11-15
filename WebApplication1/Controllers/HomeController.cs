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
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private TrainTicketContext db = new TrainTicketContext();

        public ActionResult Index(string searchInput)
        {
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseTicket(Ticket fm)
        {
            //Write your database insert code / activities  
            return RedirectToAction("Purchase", fm);
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



         public ActionResult Purchase()
         {
             return View();
         }

         [HttpGet]
         public ActionResult receipts()
         {
             List<Ticket> allUsers = db.Tickets.ToList();
             return View(allUsers);
         }

         public ActionResult Edit(object id)
         {
             throw new NotImplementedException();
         }

         public ActionResult Details(object id)
         {
             throw new NotImplementedException();
         }

         public ActionResult Delete(object id)
         {
             throw new NotImplementedException();
         }
    }
}