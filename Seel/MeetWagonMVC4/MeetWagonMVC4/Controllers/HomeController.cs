using MeetWagonMVC4.Context;
using MeetWagonMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetWagonMVC4.Controllers
{
    public class HomeController : Controller
    {
		private DataContext db = new DataContext();
        public ActionResult Index()
        {
			List<Wagon> popularWagons = db.Wagons.OrderByDescending(x => x.UserProfiles.Count()).ToList();

            return View(popularWagons);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
    }
}
