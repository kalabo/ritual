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

            return View();
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
            if(!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("Home", "Index");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            //var members = db.Members;

            var dashboardModel = new TrainingZoneDashboardData();
            //dashboardModel. = db.OpeningHours.Where(m => m.LocationId == id);

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