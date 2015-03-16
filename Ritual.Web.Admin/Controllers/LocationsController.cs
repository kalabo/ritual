using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Data;
using PagedList;
using System.Globalization;

namespace Ritual.Web.Admin.Controllers
{
    public class LocationsController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();
        
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, string Command)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
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

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(locations.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetMapDataJson()
        {
            var rituallocations = new List<RitualLocations>();
            var locations = from l in db.Locations
                            select l;
            foreach (Location location in locations)
            {
                rituallocations.Add(new RitualLocations(location.Latitude, location.Longitude, location.Name, location.Id, location.Address, location.getLocalTime()));
            }
            return Json(rituallocations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocationPaymentMethodChart(int locationId)
        {
            var data = new List<LocationChartData>();
            Location location = db.Locations.Find(locationId);

            return Json(location.getLocationPaymentMethodChart(), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create([Bind(Include = "Id,Name,Address,PhoneNumber,PostCode,Country,TimeZoneOffset,AvailableSlots,Currency,Longitude,Latitude")] Location location)
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
        public ActionResult Edit([Bind(Include = "Id,Name,Address,PhoneNumber,PostCode,Country,TimeZoneOffset,AvailableSlots,Currency,Longitude,Latitude")] Location location)
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
        
        #region Opening Hours

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
                Location location = db.Locations.Find(locationId);
                if (location == null)
                {
                    return HttpNotFound();
                }
                if (ValidatePositiveTimeRange(openingHour.OpenTime, openingHour.CloseTime))
                {
                    openingHour.LocationId = locationId;
                    db.OpeningHours.Add(openingHour);
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = openingHour.LocationId });
                }
                else
                {
                    ModelState.AddModelError("Error", "Please ensure that your close time is later than your opening time");
                    ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
                    ViewBag.Location = location;
                    return View(openingHour);
                }
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }


        // GET: OpeningHours/Edit/5
        public ActionResult EditOpeningHour(int? id, int locationId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpeningHour openingHour = db.OpeningHours.Find(id);
            if (openingHour == null)
            {
                return HttpNotFound();
            }

            Location location = db.Locations.Find(locationId);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location = location;

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }
        // POST: OpeningHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOpeningHour([Bind(Include = "Id,DateOfWeek,OpenTime,CloseTime,LocationId")] OpeningHour openingHour, int locationId)
        {
            if (ModelState.IsValid)
            {
                Location location = db.Locations.Find(locationId);
                if (location == null)
                {
                    return HttpNotFound();
                }
                if (ValidatePositiveTimeRange(openingHour.OpenTime, openingHour.CloseTime))
                {
                    openingHour.LocationId = locationId;
                    db.Entry(openingHour).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = openingHour.LocationId });
                }
                else
                {
                    ModelState.AddModelError("Error", "Please ensure that your close time is later than your opening time");
                    ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
                    ViewBag.Location = location;
                    return View(openingHour);
                }
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }

        // GET: OpeningHours/Delete/5
        public ActionResult DeleteOpeningHour(int? id, int locationId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpeningHour openingHour = db.OpeningHours.Find(id);
            if (openingHour == null)
            {
                return HttpNotFound();
            }
            Location location = db.Locations.Find(locationId);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location = location;
            return View(openingHour);
        }

        // POST: OpeningHours/Delete/5
        [HttpPost, ActionName("DeleteOpeningHour")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOpeningHourConfirmed(int id, int locationId)
        {
            OpeningHour openingHour = db.OpeningHours.Find(id);
            db.OpeningHours.Remove(openingHour);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = locationId });
        }

        #endregion

        #region Opening Hour Override

        // GET: OpeningHours/Create
        public ActionResult CreateOpeningHourOverride(int? locationId)
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
        public ActionResult CreateOpeningHourOverride([Bind(Include = "Id,OverrideStartDate,OverrideEndDate,AltOpenTime,AltCloseTime,OverrideReason")] OpeningHourOverride openingHouroverride, int locationId)
        {
            if (ModelState.IsValid)
            {
                Location location = db.Locations.Find(locationId);
                if (location == null)
                {
                    return HttpNotFound();
                }
                if (ValidatePositiveTimeRange(openingHouroverride.AltOpenTime, openingHouroverride.AltCloseTime))
                {
                    openingHouroverride.LocationId = locationId;
                    db.OpeningHourOverrides.Add(openingHouroverride);
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = openingHouroverride.LocationId });
                }
                else
                {
                    ModelState.AddModelError("Error", "Please ensure that your close time is later than your opening time");
                    ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHouroverride.LocationId);
                    ViewBag.Location = location;
                    return View(openingHouroverride);
                }
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHouroverride.LocationId);
            return View(openingHouroverride);
        }


        // GET: OpeningHours/Edit/5
        public ActionResult EditOpeningHourOverride(int? id, int locationId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpeningHourOverride openingHourOverride = db.OpeningHourOverrides.Find(id);
            if (openingHourOverride == null)
            {
                return HttpNotFound();
            }

            Location location = db.Locations.Find(locationId);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location = location;

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHourOverride.LocationId);
            return View(openingHourOverride);
        }
        // POST: OpeningHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOpeningHourOverride([Bind(Include = "Id,OverrideStartDate,OverrideEndDate,AltOpenTime,AltCloseTime,OverrideReason")] OpeningHourOverride openingHouroverride, int locationId)
        {
            if (ModelState.IsValid)
            {
                Location location = db.Locations.Find(locationId);
                if (location == null)
                {
                    return HttpNotFound();
                }
                if (ValidatePositiveTimeRange(openingHouroverride.AltOpenTime, openingHouroverride.AltCloseTime))
                {
                    openingHouroverride.LocationId = locationId;
                    db.Entry(openingHouroverride).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = openingHouroverride.LocationId });
                }
                else
                {
                    ModelState.AddModelError("Error", "Please ensure that your close time is later than your opening time");
                    ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHouroverride.LocationId);
                    ViewBag.Location = location;
                    return View(openingHouroverride);
                }
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHouroverride.LocationId);
            return View(openingHouroverride);
        }

        // GET: OpeningHours/Delete/5
        public ActionResult DeleteOpeningHourOverride(int? id, int locationId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpeningHourOverride openingHouroverride = db.OpeningHourOverrides.Find(id);
            if (openingHouroverride == null)
            {
                return HttpNotFound();
            }
            Location location = db.Locations.Find(locationId);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location = location;
            return View(openingHouroverride);
        }

        // POST: OpeningHours/Delete/5
        [HttpPost, ActionName("DeleteOpeningHour")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOpeningHourOverrideConfirmed(int id, int locationId)
        {
            OpeningHourOverride openingHouroverride = db.OpeningHourOverrides.Find(id);
            db.OpeningHourOverrides.Remove(openingHouroverride);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = locationId });
        }

        #endregion

        private bool ValidatePositiveTimeRange(TimeSpan start, TimeSpan end)
        {
            if (TimeSpan.Compare(start, end) == -1)
            {
                return true;
            }
            return false;
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
