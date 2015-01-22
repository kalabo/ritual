using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Booking.Data;
using Ritual.Booking.Web.Models;

namespace Ritual.Booking.Web.Controllers
{
    public class MembersController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: Members
        public ActionResult Index(string sortOrder, string searchString)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "firstname" ? "firstname_desc" : "firstname";

            var members = from m in db.Members.Include(m => m.AspNetUser).Include(m => m.Location) select m;

            if (Request.Form["searchButton"] != null)
            {
                // Code for function 1
            }
            else if (Request.Form["resetButton"] != null)
            {
                // code for function 2
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m => m.LastName.Contains(searchString)
                                       || m.HomePhone.Contains(searchString)
                                       || m.MobilePhone.Contains(searchString)
                                       || m.FirstName.Contains(searchString)
                                       || m.IdentificationNumber.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "lastname_desc":
                    members = members.OrderByDescending(m => m.LastName);
                    break;
                case "firstname":
                    members = members.OrderBy(m => m.FirstName);
                    break;
                case "firstname_desc":
                    members = members.OrderByDescending(m => m.FirstName);
                    break;
                default:
                    members = members.OrderBy(m => m.LastName);
                    break;
            }
            
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
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
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Salutation,FirstName,LastName,IdentificationNumber,EmailOptOut,Email,Birthday,HomePhone,MobilePhone,HomeLocationId,AspNetUserId")] Member member)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", member.AspNetUserId);
            ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name", member.HomeLocationId);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
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
            Member member = db.Members.Find(id);
            
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", member.AspNetUserId);
            ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name", member.HomeLocationId);
            return View(member);
        }
        
        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Salutation,FirstName,LastName,IdentificationNumber,EmailOptOut,Email,Birthday,HomePhone,MobilePhone,HomeLocationId,AspNetUserId")] Member member)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", member.AspNetUserId);
            ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name", member.HomeLocationId);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
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
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
