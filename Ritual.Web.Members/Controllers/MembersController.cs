using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Data;
using Ritual.Web.Members.Models;

namespace Ritual.Web.Members.Controllers
{
    public class MembersController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: Members
        public ActionResult Index(string sortOrder, string searchString, string Command)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var MemberListing = new MemberListingData();

            MemberListing.LastNameSortParam = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            MemberListing.FirstNameSortParam = sortOrder == "firstname" ? "firstname_desc" : "firstname";

            MemberListing.Members = from m in db.Members.Include(m => m.AspNetUser).Include(m => m.Location) select m;

            if (Command == "Search")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    MemberListing.Members = MemberListing.Members.Where(m => m.AspNetUser.LastName.Contains(searchString)
                                           || m.AspNetUser.HomePhone.Contains(searchString)
                                           || m.AspNetUser.MobilePhone.Contains(searchString)
                                           || m.AspNetUser.FirstName.Contains(searchString)
                                           || m.IdentificationNumber.Contains(searchString));
                }
            }
            else if (Command == "Reset")
            {

            }

            switch (sortOrder)
            {
                case "lastname_desc":
                    MemberListing.Members = MemberListing.Members.OrderByDescending(m => m.AspNetUser.LastName);
                    break;
                case "firstname":
                    MemberListing.Members = MemberListing.Members.OrderBy(m => m.AspNetUser.FirstName);
                    break;
                case "firstname_desc":
                    MemberListing.Members = MemberListing.Members.OrderByDescending(m => m.AspNetUser.FirstName);
                    break;
                default:
                    MemberListing.Members = MemberListing.Members.OrderBy(m => m.AspNetUser.LastName);
                    break;
            }

            return View(MemberListing);
        }

        // GET: Members/Details/5
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

            var detailModel = new MemberDetailData();
            detailModel.Member = db.Members.Find(id);
            detailModel.ActiveMembership = detailModel.Member.getActiveMembership();
            detailModel.PastMemberships = db.Memberships.Where(m => m.MemberId == id && m.EndDate < DateTime.Now);
            detailModel.QuarterlyAssessments = db.QuarterlyAssessments.Where(m => m.MemberId == id);

            if (detailModel.Member == null)
            {
                return HttpNotFound();
            }

            return View(detailModel);
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
        public ActionResult Edit(int id)
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
