using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Data;

namespace Ritual.Web.Admin.Controllers
{
    public class OpeningHourOverridesController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: OpeningHourOverrides
        public ActionResult Index()
        {
            var openingHourOverrides = db.OpeningHourOverrides.Include(o => o.Location);
            return View(openingHourOverrides.ToList());
        }

        // GET: OpeningHourOverrides/Details/5
        public ActionResult Details(int? id)
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
            return View(openingHourOverride);
        }

        // GET: OpeningHourOverrides/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: OpeningHourOverrides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OverrideStartDate,OverrideEndDate,DayOfWeek,AltOpenTime,AltCloseTime,Closed,OverrideReason,LocationId")] OpeningHourOverride openingHourOverride)
        {
            if (ModelState.IsValid)
            {
                db.OpeningHourOverrides.Add(openingHourOverride);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHourOverride.LocationId);
            return View(openingHourOverride);
        }

        // GET: OpeningHourOverrides/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHourOverride.LocationId);
            return View(openingHourOverride);
        }

        // POST: OpeningHourOverrides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OverrideStartDate,OverrideEndDate,DayOfWeek,AltOpenTime,AltCloseTime,Closed,OverrideReason,LocationId")] OpeningHourOverride openingHourOverride)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openingHourOverride).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHourOverride.LocationId);
            return View(openingHourOverride);
        }

        // GET: OpeningHourOverrides/Delete/5
        public ActionResult Delete(int? id)
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
            return View(openingHourOverride);
        }

        // POST: OpeningHourOverrides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpeningHourOverride openingHourOverride = db.OpeningHourOverrides.Find(id);
            db.OpeningHourOverrides.Remove(openingHourOverride);
            db.SaveChanges();
            return RedirectToAction("Index");
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
