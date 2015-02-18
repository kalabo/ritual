using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ritual.Data;
using Ritual.Web.Members.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ritual.Web.Members.Controllers
{
    public class FrontOfHouseController : Controller
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

        // GET: FrontOfHouse
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Fuelbar
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult fuelbar()
        {
            return View();
        }
        
        // GET: Feedback
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult feedback()
        {
            return View();
        }

        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Checkin()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //If user is not a member then redirect to homepage.
            if (!HttpContext.User.IsInRole("Member"))
            {
                return RedirectToAction("FrontOfHouse", "Index");
            }
            FrontOfHouseCheckInData FrontOfHouseCheckinModel = new FrontOfHouseCheckInData();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

            FrontOfHouseCheckinModel.NextSessionData= db.GetImminentSessionBookings(member.HomeLocationId, DateTime.Now).ToList();
            return View(FrontOfHouseCheckinModel);
        }

        // GET: ConfirmCheckIn
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult ConfirmCheckIn(int TimeSlotId, int SessionBookingId, int pin, int RPEPush, int RPEFeel)
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

            TrainingZoneConfirmBooking TrainingZoneConfirmBookingModel = new TrainingZoneConfirmBooking();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

            //TrainingZoneConfirmBookingModel.bookingLocation = db.Locations.Where(l => l.Id == LocationId).FirstOrDefault();
            //TrainingZoneConfirmBookingModel.bookingTimeslot = db.TimeSlots.Where(t => t.Id == TimeSlotId).FirstOrDefault();
            //TrainingZoneConfirmBookingModel.bookingDate = BookingDate;
            //TrainingZoneConfirmBookingModel.bookingMember = member;

            return View(TrainingZoneConfirmBookingModel);
        }
    }
}