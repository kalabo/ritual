using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ritual.Booking.Data;
using Ritual.Booking.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ritual.Booking.Web.Controllers
{
    public class TrainingZoneController : Controller
    {
        /// <summary>
        /// Application DB context
        /// </summary>
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        protected UserManager<ApplicationUser> UserManager { get; set; }

        private RitualDBEntities db = new RitualDBEntities();

        // GET: TrainingZone
        public ActionResult MyRitual()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //If user is not a member then redirect to homepage.
            if (!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //var members = db.Members;
            DateTime todaysDate = DateTime.Now;
            TrainingZoneMyRitualData dashboardModel = new TrainingZoneMyRitualData();
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            dashboardModel.UserMember = member;
            dashboardModel.UserHomeLocation = db.Locations.Where(l => l.Id == member.HomeLocationId).FirstOrDefault();
            dashboardModel.UserActiveMembership = db.Memberships.Where(m => m.MemberId == member.Id && m.MembershipStateId == 1).FirstOrDefault();
            dashboardModel.UserPastMemberships = db.Memberships.Where(m => m.MemberId == member.Id && m.MembershipStateId != 1);            
            if (dashboardModel.UserActiveMembership != null)
            {
                dashboardModel.DaysTillMembershipExpiry = Convert.ToInt32((dashboardModel.UserActiveMembership.EndDate - DateTime.Now).TotalDays);
            }

            return View(dashboardModel);
        }

        // GET: MyAssessments
        public ActionResult MyAssessments()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //If user is not a member then redirect to homepage.
            if (!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("Home", "Index");
            }

            return View();
        }

        // GET: TrainingZone
        public ActionResult Dashboard()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //If user is not a member then redirect to homepage.
            if (!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //var members = db.Members;
            DateTime todaysDate = DateTime.Now;
            TrainingZoneDashboardData dashboardModel = new TrainingZoneDashboardData();

            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            dashboardModel.UserMember = member;
            dashboardModel.UserHomeLocation = db.Locations.Where(l => l.Id == member.HomeLocationId).FirstOrDefault();
            dashboardModel.UserActiveMembership = db.Memberships.Where(m => m.MemberId == member.Id && m.MembershipStateId == 1).FirstOrDefault();
            if (dashboardModel.UserActiveMembership != null)
            {
                dashboardModel.DaysTillMembershipExpiry = Convert.ToInt32((dashboardModel.UserActiveMembership.EndDate - DateTime.Now).TotalDays);
            }
            dashboardModel.UpcomingBookings = db.SessionBookings.Where(m => m.MemberId == member.Id && m.LocationId == member.HomeLocationId && m.Date >= todaysDate).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).Take(5); 
            dashboardModel.PastBookings = db.SessionBookings.Where(m => m.MemberId == member.Id && m.LocationId == member.HomeLocationId && m.Date < todaysDate).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).Take(5);
            dashboardModel.QuarterlyAssessments = db.QuarterlyAssessments.Where(qa => qa.MemberId == member.Id).OrderByDescending(qa => qa.QADateTime).Take(5);
            //if (dashboardModel. == null)
            //{
            //    return HttpNotFound();
            //}

            return View(dashboardModel);
        }
        // GET: TrainingZone
        public ActionResult Booking()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //If user is not a member then redirect to homepage.
            if (!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("Home", "Index");
            }

            return View();
        }

        // GET: TrainingZone
        public ActionResult ConfirmBooking(int? id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //If user is not a member then redirect to homepage.
            if (!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("Home", "Index");
            }

            return View();
        }

        // GET: TrainingZone/DeleteBooking/5
        public ActionResult DeleteBooking(int? id)
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
            //Location location = db.Locations.Find(id);
            //if (location == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(location);
            return View();
        }

        // POST: TrainingZone/DeleteBooking/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBookingConfirmed(int id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //Member member = db.Members.Find(id);
            //db.Members.Remove(member);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}