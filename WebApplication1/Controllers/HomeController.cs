using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            return View();
        }

         public ActionResult Purchase()
         {
             return View();
         }

         [HttpGet]
         public ActionResult receipts()
         {
             List<User> allUsers = db.Users.ToList();
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