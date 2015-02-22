using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ritual.Data;
using Ritual.Web.Members.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ritual.Web.Members.Controllers
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

        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult MyRitual()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            TrainingZoneMyRitualData dashboardModel = new TrainingZoneMyRitualData();
            Member member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            dashboardModel.UserMember = member;
            dashboardModel.UserHomeLocation = member.getUserHomeLocation();
            dashboardModel.UserActiveMembership = member.getActiveMembership();
            dashboardModel.UserPastMemberships = member.getExpiredMemberships();

            if (dashboardModel.UserActiveMembership != null)
            {
                dashboardModel.DaysTillMembershipExpiry = member.getActiveMembership().daysTillExpiry();
            }

            return View(dashboardModel);
        }

        // GET: MyAssessments
        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult MyAssessments()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // GET: TrainingZone
        [Authorize(Roles = "Member, Administrator")]
        public ActionResult Dashboard()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            TrainingZoneDashboardData dashboardModel = new TrainingZoneDashboardData();

            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            dashboardModel.UserMember = member;
            dashboardModel.UserHomeLocation = member.getUserHomeLocation();
            dashboardModel.UserActiveMembership = member.getActiveMembership();
            if (dashboardModel.UserActiveMembership != null)
            {
                dashboardModel.DaysTillMembershipExpiry = member.getActiveMembership().daysTillExpiry();
            }
            dashboardModel.UpcomingBookings = member.getUpcomingBookings(5);
            dashboardModel.PastBookings = member.getPastBookings(5);
            dashboardModel.QuarterlyAssessments = member.getQuarterlyAssessments(5);

            return View(dashboardModel);
        }
        // GET: TrainingZone
        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult Booking()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            TrainingZoneBookingData TrainingZoneModel = new TrainingZoneBookingData();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

            TrainingZoneModel.OpenDays = member.getUserHomeLocation().getDaysOpen(3, DateTime.Now);
            TrainingZoneModel.AvailableBookingSlots = db.GetUpcomingBookingSlots(member.HomeLocationId, TrainingZoneModel.OpenDays[0], member.Id).ToList();
            return View(TrainingZoneModel);
        }

        public ActionResult GetNextOpenDays(string date, int numberofdays)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            List<DateTime> results = member.getUserHomeLocation().getDaysOpen(numberofdays, Convert.ToDateTime(date));
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult GetBookingsByDate(string date)
        {
            //If the current date is the same then only show items for current day
            DateTime selectedDate = Convert.ToDateTime(date);

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            if (selectedDate.Date == DateTime.Now.Date)
            {
                selectedDate = new DateTimeOffset(DateTime.Now).ToOffset(TimeSpan.FromHours(member.Location.TimeZoneOffset)).Date;
            }
            List<GetUpcomingBookingSlots_Result> results = db.GetUpcomingBookingSlots(member.HomeLocationId, selectedDate, member.Id).ToList();
            return Json(results, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult CancelBookingJSON(int timeslotId, int locationId, string date)
        {
            //If the current date is the same then only show items for current day
            DateTime selectedDate = Convert.ToDateTime(date);

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            if (member != null)
            {
                SessionBooking currentBooking = db.SessionBookings.Where(s => s.LocationId.Equals(locationId) && s.TimeSlotId.Equals(timeslotId) && s.MemberId.Equals(member.Id) && s.Date == selectedDate).SingleOrDefault();
                if (currentBooking != null)
                {
                    db.SessionBookings.Remove(currentBooking);
                    db.SaveChanges();
                    return Json("Delete Successful", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    List<string> errors = new List<string>();
                    //..some processing
                    errors.Add("Error: Delete Failed, No booking object found");
                    return Json(errors, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                List<string> errors = new List<string>();
                //..some processing
                errors.Add("Error: You are not allowed to delete a booking that is not yours");
                return Json(errors, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult AddNewBooking(int timeslotId, string bookingDate)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

            SessionBooking booking = new SessionBooking();
            booking.TimeSlotId = timeslotId;
            booking.Date = Convert.ToDateTime(bookingDate);
            booking.MemberId = member.Id;
            booking.LocationId = member.HomeLocationId;
            //Set booking to "pending"
            booking.BookingStateId = 1;
            //Set Default RPE
            booking.RPEFeeling = 0;
            booking.RPEPush = 0;

            db.SessionBookings.Add(booking);
            db.SaveChanges();
            return Json("Insert Successful", JsonRequestBehavior.AllowGet);
        }


        // GET: TrainingZone
        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult CancelBooking(int? BookingId)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            TrainingZoneCancelBooking TrainingZoneCancelBookingModel = new TrainingZoneCancelBooking();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

            TrainingZoneCancelBookingModel.sessionBooking = db.SessionBookings.Where(l => l.Id == BookingId).FirstOrDefault();

            return View(TrainingZoneCancelBookingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult DeleteBookingConfirmed(int id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            SessionBooking booking = db.SessionBookings.Find(id);
            db.SessionBookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        // GET: TrainingZone
        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult ConfirmBooking(int TimeSlotId, int LocationId, DateTime BookingDate)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            TrainingZoneConfirmBooking TrainingZoneConfirmBookingModel = new TrainingZoneConfirmBooking();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

            TrainingZoneConfirmBookingModel.bookingLocation = db.Locations.Where(l => l.Id == LocationId).FirstOrDefault();
            TrainingZoneConfirmBookingModel.bookingTimeslot = db.TimeSlots.Where(t => t.Id == TimeSlotId).FirstOrDefault();
            TrainingZoneConfirmBookingModel.bookingDate = BookingDate;
            TrainingZoneConfirmBookingModel.bookingMember = member;

            return View(TrainingZoneConfirmBookingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member,Admininistrator")]
        public ActionResult AddNewBooking(int TimeSlotId, int LocationId, DateTime BookingDate)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                var user = UserManager.FindById(User.Identity.GetUserId());
                var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

                SessionBooking booking = new SessionBooking();
                booking.TimeSlotId = TimeSlotId;
                booking.Date = BookingDate;
                booking.MemberId = member.Id;
                booking.LocationId = member.HomeLocationId;
                //Set booking to "pending"
                booking.BookingStateId = 1;
                //Set Default RPE
                booking.RPEFeeling = 0;
                booking.RPEPush = 0;

                db.SessionBookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View();
        }


        // GET: TrainingZone/DeleteBooking/5
        [Authorize(Roles = "Member,Admininistrator")]
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