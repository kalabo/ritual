﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Booking.Data;
using PagedList;

namespace Ritual.Booking.Web.Controllers
{
    public class LocationsController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: Locations
        public ActionResult Index(string sortOrder, string searchString, string Command)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";

            var locations = from l in db.Locations
                            select l;

            if (Command == "Search")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    locations = locations.Where(l => l.Name.Contains(searchString)
                                           || l.Country.Contains(searchString)
                                           || l.Address.Contains(searchString));
                }
            }
            else if (Command == "Reset")
            {

            }
            switch (sortOrder)
            {
                case "name_desc":
                    locations = locations.OrderByDescending(l => l.Name);
                    break;
                case "Country":
                    locations = locations.OrderBy(l => l.Country);
                    break;
                case "country_desc":
                    locations = locations.OrderByDescending(l => l.Country);
                    break;
                default:
                    locations = locations.OrderBy(l => l.Name);
                    break;
            }
            return View(locations.ToList());

        }

        public ActionResult GetCurrentLocationMapData(int id)
        {
            var rituallocations = new List<RitualLocations>();
            var location = db.Locations.Find(id);
            rituallocations.Add(new RitualLocations(location.Latitude, location.Longitude));
            return Json(rituallocations, JsonRequestBehavior.AllowGet);
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detailModel = new LocationDetailData();
            detailModel.Location = db.Locations.Find(id);
            detailModel.OpeningHours = db.OpeningHours.Where(m => m.LocationId == id);
            detailModel.OpeningHourOverrides = db.OpeningHourOverrides.Where(m => m.LocationId == id);
            detailModel.Members = db.Members.Where(m => m.HomeLocationId == id);

            if (detailModel.Location == null)
            {
                return HttpNotFound();
            }

            return View(detailModel);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,PhoneNumber,PostCode,Country,TimeZoneOffset,Currency,Longitude,Latitude")] Location location)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,PhoneNumber,PostCode,Country,TimeZoneOffset,Currency,Longitude,Latitude")] Location location)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: OpeningHours/Create
        public ActionResult CreateOpeningHour(int? locationId)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (locationId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(locationId);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location = location;
            return View();
        }

        // POST: OpeningHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOpeningHour([Bind(Include = "Id,DateOfWeek,OpenTime,CloseTime")] OpeningHour openingHour, int locationId)
        {
            if (ModelState.IsValid)
            {
                openingHour.LocationId = locationId;
                db.OpeningHours.Add(openingHour);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = openingHour.LocationId});
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
