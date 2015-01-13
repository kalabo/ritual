using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Booking.Data;

namespace Ritual.Booking.Web.Controllers
{
    public class MembershipStatesController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: MembershipStates        
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var membershipstates = from ms in db.MembershipStates
                            select ms;

            if (!String.IsNullOrEmpty(searchString))
            {
                membershipstates = membershipstates.Where(l => l.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    membershipstates = membershipstates.OrderByDescending(l => l.Name);
                    break;
                default:
                    membershipstates = membershipstates.OrderBy(l => l.Name);
                    break;
            }
            return View(membershipstates.ToList());

        }

        // GET: MembershipStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipState membershipState = db.MembershipStates.Find(id);
            if (membershipState == null)
            {
                return HttpNotFound();
            }
            return View(membershipState);
        }

        // GET: MembershipStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MembershipState membershipState)
        {
            if (ModelState.IsValid)
            {
                db.MembershipStates.Add(membershipState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipState);
        }

        // GET: MembershipStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipState membershipState = db.MembershipStates.Find(id);
            if (membershipState == null)
            {
                return HttpNotFound();
            }
            return View(membershipState);
        }

        // POST: MembershipStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MembershipState membershipState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipState);
        }

        // GET: MembershipStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipState membershipState = db.MembershipStates.Find(id);
            if (membershipState == null)
            {
                return HttpNotFound();
            }
            return View(membershipState);
        }

        // POST: MembershipStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipState membershipState = db.MembershipStates.Find(id);
            db.MembershipStates.Remove(membershipState);
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
