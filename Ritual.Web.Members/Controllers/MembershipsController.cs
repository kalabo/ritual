using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Data;

namespace Ritual.Web.Members.Controllers
{
    public class MembershipsController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: Memberships
        public ActionResult Index(string sortOrder, string searchString, string StartDateRange, string EndDateRange, string Command)
        {
            var MembershipListing = new MembershipListingData();
            MembershipListing.Memberships = db.Memberships.Include(m => m.Member).Include(m => m.MembershipState).Include(m => m.Package);
            MembershipListing.StartDateSortParam = String.IsNullOrEmpty(sortOrder) ? "startdate_desc" : "";
            MembershipListing.EndDateSortParam = sortOrder == "enddate" ? "enddate_desc" : "enddate";
            
            if (Command == "Search")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    MembershipListing.Memberships = MembershipListing.Memberships.Where(l => l.MembershipState.Name.Contains(searchString)
                                           || l.Member.AspNetUser.LastName.Contains(searchString)
                                           || l.Member.AspNetUser.FirstName.Contains(searchString)
                                           || l.Package.Name.Contains(searchString));
                }

                if(!string.IsNullOrEmpty(StartDateRange) && !string.IsNullOrEmpty(EndDateRange))
                {
                    MembershipListing.Memberships = MembershipListing.Memberships.Where(l => l.EndDate >= Convert.ToDateTime(StartDateRange) && l.StartDate <= Convert.ToDateTime(EndDateRange)); 
                }
            }
            else if (Command == "Reset")
            {

            }
            switch (sortOrder)
            {
                case "enddate":
                    MembershipListing.Memberships = MembershipListing.Memberships.OrderBy(l => l.EndDate);
                    break;
                case "enddate_desc":
                    MembershipListing.Memberships = MembershipListing.Memberships.OrderByDescending(l => l.EndDate);
                    break;
                case "startdate_desc":
                    MembershipListing.Memberships = MembershipListing.Memberships.OrderByDescending(l => l.StartDate);
                    break;
                default:
                    MembershipListing.Memberships = MembershipListing.Memberships.OrderBy(l => l.StartDate);
                    break;
            }

            return View(MembershipListing.Memberships.ToList());
        }

        // GET: Memberships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Memberships/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Salutation");
            ViewBag.MembershipStateId = new SelectList(db.MembershipStates, "Id", "Name");
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult SuspendMembership(int suspension_member_id, int suspension_package_id, string suspension_reason, string suspension_start_date, string suspension_end_date)
        {
            if (suspension_member_id == null || suspension_package_id == null || string.IsNullOrEmpty(suspension_start_date) || string.IsNullOrEmpty(suspension_reason) || string.IsNullOrEmpty(suspension_end_date))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            Membership membership = db.Memberships.Find(suspension_member_id);
            Package package = db.Packages.Find(suspension_package_id);
            DateTime startDate = Convert.ToDateTime(suspension_start_date);
            DateTime endDate = Convert.ToDateTime(suspension_end_date);
            
            if (ModelState.IsValid)
            {
                MembershipSuspension suspension = new MembershipSuspension();
                db.MembershipSuspensions.Add(suspension);
                suspension.MembershipId = membership.Id;
                suspension.SuspensionStartDate = startDate;
                suspension.SuspensionEndDate = endDate;
                suspension.SuspensionReason = suspension_reason;
                db.SaveChanges();

                // Set Membership to Suspend
                membership.MembershipStateId = 6;
                db.Entry(membership).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", "Members", new { id = membership.MemberId});
            }

            return View();
        }

        // GET: Memberships/suspend
        public ActionResult Suspend(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }

            MembershipsSuspensionData suspendModel = new MembershipsSuspensionData();
            suspendModel.Membership = membership;
            suspendModel.Package = membership.Package;

            return View(suspendModel);
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,PackageId,StartDate,EndDate,Trial,MembershipStateId,CancellationDate,Paid,InitialPaymentDate,InitialPayment,MonthlyPrice,TotalPrice,DiscountPercentage,DiscountPrice,DiscountReason")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Memberships.Add(membership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Salutation", membership.MemberId);
            ViewBag.MembershipStateId = new SelectList(db.MembershipStates, "Id", "Name", membership.MembershipStateId);
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", membership.PackageId);
            return View(membership);
        }

        // GET: Memberships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Salutation", membership.MemberId);
            ViewBag.MembershipStateId = new SelectList(db.MembershipStates, "Id", "Name", membership.MembershipStateId);
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", membership.PackageId);
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,PackageId,StartDate,EndDate,Trial,MembershipStateId,CancellationDate,Paid,InitialPaymentDate,InitialPayment,MonthlyPrice,TotalPrice,DiscountPercentage,DiscountPrice,DiscountReason")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Salutation", membership.MemberId);
            ViewBag.MembershipStateId = new SelectList(db.MembershipStates, "Id", "Name", membership.MembershipStateId);
            ViewBag.PackageId = new SelectList(db.Packages, "Id", "Name", membership.PackageId);
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membership membership = db.Memberships.Find(id);
            db.Memberships.Remove(membership);
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
