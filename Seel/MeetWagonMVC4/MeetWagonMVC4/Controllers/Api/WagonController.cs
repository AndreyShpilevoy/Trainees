using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MeetWagonMVC4.Models;
using MeetWagonMVC4.Context;

namespace MeetWagonMVC4.Controllers.Api
{
    public class WagonController : ApiController
    {
        private DataContext db = new DataContext();

		/// <summary>
		/// Gets all wagons
		/// </summary>
        // GET api/Wagon
		[HttpGet]
        public IEnumerable<Wagon> Index()
        {
            return db.Wagons.AsEnumerable();
        }

		/// <summary>
		/// Gets a wagon
		/// </summary>
		/// <param name="id">The ID of a Wagon</param>
        // GET api/Wagon/Details/5
		[HttpGet]
        public WagonDetailsResponse Details(int id)
        {
            Wagon wagon = db.Wagons.Find(id);
            if (wagon == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

			WagonDetailsResponse response = new WagonDetailsResponse();
			string fbData = "This goes to the like button";
			response.FbLikeButtonData = fbData;
			response.Wagon = wagon;
            return response;
        }
		/// <summary>
		/// Edits a wagon
		/// </summary>
		/// <param name="id">The ID of the wagon</param>
		/// <param name="request">The wagon request containing edits</param>
		/// <returns></returns>
		// PUT api/Wagon/Edit/5
		[HttpPut]
		[Authorize(Roles = "Administrator")]
		public HttpResponseMessage Edit(int id, WagonEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
			var wagon = new Wagon();
			wagon = db.Wagons.Find(request.WagonId);
			wagon.Description = request.Description;

            if (id != wagon.WagonId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(wagon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

		// PUT api/Wagon/Join/5
		[HttpPut]
		public HttpResponseMessage Join(int id)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			Wagon wagon = db.Wagons.Find(id);
			if (wagon == null)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
			var userProfile = db.UserProfiles.Where(user => user.UserName == User.Identity.Name).Single();
			wagon.UserProfiles.Add(userProfile);
		
			db.Entry(wagon).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
			}

			return Request.CreateResponse(HttpStatusCode.OK);
		}

		/// <summary>
		/// Creates a wagon
		/// </summary>
		/// <param name="request">The wagon request</param>
		/// <returns></returns>
		// POST api/Create/Wagon
		[HttpPost]
        public HttpResponseMessage Create(WagonCreateRequest request)
        {
            if (ModelState.IsValid)
            {
				var wagon = new Wagon();
				wagon.Name = request.Name;
				wagon.Description = request.Description;
				wagon.DateAdded = DateTime.Now;
				db.Wagons.Add(wagon);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, wagon);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = wagon.WagonId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Wagon/Delete/5
		[HttpDelete]
		[Authorize(Roles = "Administrator")]
		public HttpResponseMessage Delete(int id)
        {
            Wagon wagon = db.Wagons.Find(id);
            if (wagon == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Wagons.Remove(wagon);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, wagon);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}