using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ritual.Data;
using Ritual.Web.Members.Models;
using Ritual.Web.Members.Services.TrainingZone;

namespace Ritual.Web.Members.Controllers
{
    public class TrainingZoneController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private RitualDBEntities db = new RitualDBEntities();

        // GET: MyAssessments
        [Authorize(Roles = "Member")]
        public ActionResult MyAssessments()
        {
            //Redirect back to login page if not authenticatedGetNext
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            return View();
        }

        // GET: TrainingZone
        [Authorize(Roles = "Member")]
        public ActionResult Dashboard()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            TrainingZoneDashboardData dashboardModel = new TrainingZoneDashboardData();

            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            dashboardModel.UserMember = member;
            dashboardModel.UserHomeLocation = member.getUserHomeLocation();
            dashboardModel.UserActiveMembership = member.getActiveMembership();
            if (dashboardModel.UserActiveMembership != null)
            {
                dashboardModel.DaysTillMembershipExpiry = member.getActiveMembership().daysTillExpiry();
            }
            dashboardModel.QuarterlyAssessments = member.getQuarterlyAssessments(5);

            return View(dashboardModel);
        }
        // GET: TrainingZone
        [Authorize(Roles = "Member")]
        public ActionResult Booking()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            TrainingZoneBookingData TrainingZoneModel = new TrainingZoneBookingData();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);

            TrainingZoneModel.currentMember = member;

            return View(TrainingZoneModel);
        }
        
        // GET: TrainingZone
        [Authorize(Roles = "Member")]
        public ActionResult CancelBooking(int? BookingId)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            TrainingZoneCancelBooking TrainingZoneCancelBookingModel = new TrainingZoneCancelBooking();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);

            TrainingZoneCancelBookingModel.sessionBooking = db.SessionBookings.FirstOrDefault(l => l.Id == BookingId);

            return View(TrainingZoneCancelBookingModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public ActionResult DeleteBookingConfirmed(int id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            SessionBooking booking = db.SessionBookings.Find(id);
            db.SessionBookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        // GET: TrainingZone
        [Authorize(Roles = "Member")]
        public ActionResult ConfirmBooking(int timeSlotId, int locationId, DateTime bookingDate)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            TrainingZoneConfirmBooking trainingZoneConfirmBookingModel = new TrainingZoneConfirmBooking();
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);

            var timeslot = db.TimeSlots.Single(m => m.Id == timeSlotId);
            string memberType = member.getActiveMembership().getMembershipType();
            bool offpeakSlot = timeslot.IsOffPeakSlot(locationId);

            trainingZoneConfirmBookingModel.AllowBooking = TrainingZoneService.isUserAllowedBooking(member, locationId, timeslot);

            //if member is session type then count number of available sessions.  
            //If you have no sessions available prevent them booking

            trainingZoneConfirmBookingModel.bookingLocation = db.Locations.FirstOrDefault(l => l.Id == locationId);
            trainingZoneConfirmBookingModel.bookingTimeslot = db.TimeSlots.FirstOrDefault(t => t.Id == timeSlotId);
            trainingZoneConfirmBookingModel.bookingDate = bookingDate;
            trainingZoneConfirmBookingModel.bookingMember = member;

            return View(trainingZoneConfirmBookingModel);
        }
        
        // GET: TrainingZone/DeleteBooking/5
        [Authorize(Roles = "Member")]
        public ActionResult DeleteBooking(int? id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
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


        #region Json Actions

        public ActionResult GetUpcomingBookings(int rowcount)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            List<SessionBookingJSONModel> results = member.getUpcomingBookings(rowcount);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPastBookings(int rowcount)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            List<SessionBookingJSONModel> results = member.getPastBookings(rowcount);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMemberAvailableLocations()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            List<Location> locations = member.getAvailableBookingLocations();

            var rituallocations = new List<RitualLocations>();
            foreach (Location location in locations)
            {
                rituallocations.Add(new RitualLocations(location.Latitude, location.Longitude, location.Name, location.Id, location.Address, location.getLocalTime()));
            }
            return Json(rituallocations, JsonRequestBehavior.AllowGet);
        }   
    
        public ActionResult GetNextOpenDays(int numberofdays, int locationid)
        {
            var location = db.Locations.Single(l => l.Id == locationid);
            List<DateTime> results = location.getDaysOpen(numberofdays, DateTime.UtcNow.AddHours(location.TimeZoneOffset));
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocationNews(int rowcount, int locationid)
        {
            var location = db.Locations.Single(l => l.Id == locationid);
            List<NewsListingJSONModel> results = location.getNews(rowcount);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetHomeLocationNews(int rowcount)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            List<NewsListingJSONModel> results = member.getUserHomeLocation().getNews(rowcount);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Member")]
        public ActionResult GetBookingsByDate(string date, int locationid)
        {
            //If the current date is the same then only show items for current day
            DateTime selectedDate = Convert.ToDateTime(date);

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var location = db.Locations.Single(l => l.Id == locationid);
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);

            if (member.getActiveMembership() != null)
            {
                if (selectedDate.Date == DateTime.UtcNow.AddHours(location.TimeZoneOffset).Date)
                {
                    selectedDate = DateTime.UtcNow.AddHours(location.TimeZoneOffset);
                }

                string memberType = member.getActiveMembership().getMembershipType();
                TrainingZoneBookingData TrainingZoneModel = new TrainingZoneBookingData();
                List<GetUpcomingBookingSlots_Result> results =
                    db.GetUpcomingBookingSlots(location.Id, selectedDate, member.Id).ToList();
                TrainingZoneModel.AvailableBookingSlots = results;
                TrainingZoneModel.MemberType = memberType;
                return Json(TrainingZoneModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                List<string> errors = new List<string>();
                //..some processing
                errors.Add("Error: You do not have any active memberships so you are unable to book a timeslot.");
                return Json(errors, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Member")]
        public ActionResult CancelBookingJSON(int timeslotId, int locationId, string date)
        {
            //If the current date is the same then only show items for current day
            DateTime selectedDate = Convert.ToDateTime(date);

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            if (member != null)
            {
                SessionBooking currentBooking = db.SessionBookings.SingleOrDefault(s => s.LocationId.Equals(locationId) && s.TimeSlotId.Equals(timeslotId) && s.MemberId.Equals(member.Id) && s.Date == selectedDate);
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

        [Authorize(Roles = "Member")]
        public ActionResult AddNewBooking(int timeslotId, string bookingDate)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);

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

        #endregion



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