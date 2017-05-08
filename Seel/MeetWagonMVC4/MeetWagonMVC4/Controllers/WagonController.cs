using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetWagonMVC4.Models;
using MeetWagonMVC4.Context;

namespace MeetWagonMVC4.Controllers
{
    public class WagonController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Wagon/
		
        public ActionResult Index()
        {
            return View(db.Wagons.ToList());
        }

        //
        // GET: /Wagon/Details/5

        public ActionResult Details(int id = 0)
        {
            Wagon wagon = db.Wagons.Find(id);
            if (wagon == null)
            {
                return HttpNotFound();
            }

			string fbData = "This goes in the like button";
			WagonDetailsResponse response = new WagonDetailsResponse();
			response.FbLikeButtonData = fbData;
			response.Wagon = wagon;

            return View(response);
        }

        //
        // GET: /Wagon/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Wagon/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WagonCreateRequest request)
        {
			Wagon wagon = new Wagon();
			if (ModelState.IsValid)
            {
				wagon.Name = request.Name;
				wagon.Description = request.Description;
				wagon.DateAdded = DateTime.Now;
				db.Wagons.Add(wagon);
				db.SaveChanges();
				return RedirectToAction("Index");
            }
            return View(wagon);
        }

        //
        // GET: /Wagon/Edit/5
		[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Wagon wagon = db.Wagons.Find(id);
            if (wagon == null)
            {
                return HttpNotFound();
            }
            return View(wagon);
        }

		//
		// POST: /Wagon/Edit/5
		[Authorize(Roles = "Administrator")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WagonEditRequest request)
        {
			Wagon wagon = new Wagon();
			if (ModelState.IsValid)
            {
				wagon = db.Wagons.Find(request.WagonId);
				wagon.Description = request.Description;
                db.Entry(wagon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wagon);
        }

		//
		// GET: /Wagon/Join/5

		public ActionResult Join(int id = 0)
		{
			Wagon wagon = db.Wagons.Find(id);
			if (wagon == null)
			{
				return HttpNotFound();
			}
			var userProfile = db.UserProfiles.Where(user => user.UserName == User.Identity.Name).Single();
			wagon.UserProfiles.Add(userProfile);
			db.SaveChanges();
			return RedirectToAction("Index");
		}


		//
		// GET: /Wagon/Delete/5
		[Authorize(Roles = "Administrator")]
		public ActionResult Delete(int id = 0)
        {
            Wagon wagon = db.Wagons.Find(id);
            if (wagon == null)
            {
                return HttpNotFound();
            }
            return View(wagon);
        }

		//
		// POST: /Wagon/Delete/5
		[Authorize(Roles = "Administrator")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wagon wagon = db.Wagons.Find(id);
            db.Wagons.Remove(wagon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}