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
    public class OpeningHoursController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: OpeningHours
        public ActionResult Index()
        {
            var openingHours = db.OpeningHours.Include(o => o.Location);
            return View(openingHours.ToList());
        }

        // GET: OpeningHours/Details/5
        public ActionResult Details(int? id)
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
            return View(openingHour);
        }

        // GET: OpeningHours/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: OpeningHours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOfWeek,OpenTime,CloseTime,LocationId")] OpeningHour openingHour)
        {
            if (ModelState.IsValid)
            {
                db.OpeningHours.Add(openingHour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }

        // GET: OpeningHours/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }

        // POST: OpeningHours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOfWeek,OpenTime,CloseTime,LocationId")] OpeningHour openingHour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openingHour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", openingHour.LocationId);
            return View(openingHour);
        }

        // GET: OpeningHours/Delete/5
        public ActionResult Delete(int? id)
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
            return View(openingHour);
        }

        // POST: OpeningHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpeningHour openingHour = db.OpeningHours.Find(id);
            db.OpeningHours.Remove(openingHour);
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
