using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using Ritual.Data;
using Ritual.Web.Common;
using Ritual.Web.Members.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
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



        private const int AvatarStoredWidth = 160;
        private const int AvatarStoredHeight = 160;
        private const int AvatarScreenWidth = 400;

        private const string TempFolder = "/Temp";
        private const string MapTempFolder = "~" + TempFolder;
        private const string AvatarPath = "/Content/Avatars";

        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };

        [HttpGet]
        public ActionResult UploadPhoto()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _UploadPhoto()
        {
            return PartialView();
        }

        [ValidateAntiForgeryToken]
        public ActionResult _UploadPhoto(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any()) return Json(new { success = false, errorMessage = "No file uploaded." });
            var file = files.FirstOrDefault();  // get ONE only
            if (file == null || !IsImage(file)) return Json(new { success = false, errorMessage = "File is of wrong format." });
            if (file.ContentLength <= 0) return Json(new { success = false, errorMessage = "File cannot be zero length." });
            var webPath = GetTempSavedFilePath(file);
            return Json(new { success = true, fileName = webPath.Replace("/", "\\") }); // success
        }

        [HttpPost]
        public ActionResult Save(string t, string l, string h, string w, string fileName)
        {
            try
            {
                // Calculate dimensions
                var top = Convert.ToInt32(t.Replace("-", "").Replace("px", ""));
                var left = Convert.ToInt32(l.Replace("-", "").Replace("px", ""));
                var height = Convert.ToInt32(h.Replace("-", "").Replace("px", ""));
                var width = Convert.ToInt32(w.Replace("-", "").Replace("px", ""));

                // Get file from temporary folder
                var fn = Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(fileName));
                // ...get image and resize it, ...
                var img = new WebImage(fn);
                img.Resize(width, height);
                // ... crop the part the user selected, ...
                img.Crop(top, left, img.Height - top - AvatarStoredHeight, img.Width - left - AvatarStoredWidth);
                // ... delete the temporary file,...
                System.IO.File.Delete(fn);
                // ... and save the new one.
                var newFileName = Path.Combine(AvatarPath, Path.GetFileName(fn));
                var newFileLocation = HttpContext.Server.MapPath(newFileName);
                if (Directory.Exists(Path.GetDirectoryName(newFileLocation)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation));
                }
                img.Save(newFileLocation);

                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                var user = UserManager.FindById(User.Identity.GetUserId());
                user.PhotoUrl = newFileName;
                UserManager.Update(user);

                return Json(new { success = true, avatarFileLocation = newFileName });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = "Unable to upload file.\nERRORINFO: " + ex.Message });
            }
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            if (file == null) return false;
            return file.ContentType.Contains("image") ||
                _imageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        private string GetTempSavedFilePath(HttpPostedFileBase file)
        {
            // Define destination
            var serverPath = HttpContext.Server.MapPath(TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }


            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            Member member = db.Members.Single(m => m.AspNetUserId == user.Id);

            // Generate unique file name
            var ext = Path.GetExtension(file.FileName);
            var fileName = user.Id + ext;
            fileName = SaveTemporaryAvatarFileImage(file, serverPath, fileName);

            // Clean up old files after every save
            CleanUpTempFolder(1);
            return Path.Combine(TempFolder, fileName);
        }

        private static string SaveTemporaryAvatarFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(AvatarScreenWidth, (int)(AvatarScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);
            return Path.GetFileName(img.FileName);
        }

        private void CleanUpTempFolder(int hoursOld)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = HttpContext.Server.MapPath("/Temp");
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);
                foreach (var fileEntry in fileEntries)
                {
                    var fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry);
                    var res = currentUtcNow - fileCreationTime;
                    if (res.TotalHours > hoursOld)
                    {
                        System.IO.File.Delete(fileEntry);
                    }
                }
            }
            catch
            {
                // Deliberately empty.
            }
        }






        [Authorize(Roles = "Member")]
        public ActionResult MyRitual()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            TrainingZoneMyRitualData dashboardModel = new TrainingZoneMyRitualData();
            Member member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();
            dashboardModel.Gravatar = string.Format("<img src='{0}' class='gravatar'/>", user.PhotoUrl);
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
        [Authorize(Roles = "Member")]
        public ActionResult MyAssessments()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            return View();
        }

        // GET: /TrainingZone/EditProfile
        public ActionResult EditProfile()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            Member member = db.Members.Single(m => m.AspNetUserId == user.Id);

            MembershipProfileEditViewModel model = new MembershipProfileEditViewModel();
            model.AddressLine1 = member.AddressLine1;
            model.AddressLine2 = member.AddressLine2;
            model.City = member.City;

            model.Country = member.Country;
            model.Countries = new SelectList(IEnumerables.GetCountries(), "ID", "Name", model.Country);

            model.PostCodeZip = member.PostZipCode;

            model.ShirtSize = !string.IsNullOrEmpty(member.ShirtSize) ? member.ShirtSize.Trim() : string.Empty;
            model.ShirtSizes = new SelectList(IEnumerables.GetShirtSizes(), "ID", "Name", model.ShirtSize);

            model.ShortSize = !string.IsNullOrEmpty(member.ShortSize) ? member.ShortSize.Trim() : string.Empty;
            model.ShortSizes = new SelectList(IEnumerables.GetShortSizes(), "ID", "Name", model.ShortSize);

            model.IDNumber = !string.IsNullOrEmpty(member.IDNumber) ? member.IDNumber.Trim() : string.Empty;
            model.IDType = !string.IsNullOrEmpty(member.IDType) ? member.IDType.Trim() : string.Empty;
            model.IDTypes = new SelectList(IEnumerables.GetIDTypes(), "ID", "Name", model.IDType);

            model.EmergencyContactName = !string.IsNullOrEmpty(member.EmergencyContactName) ? member.EmergencyContactName.Trim() : string.Empty;
            model.EmergencyContactNumber = !string.IsNullOrEmpty(member.EmergencyContactNumber) ? member.EmergencyContactNumber.Trim() : string.Empty;
            model.HomePhone = !string.IsNullOrEmpty(user.HomePhone) ? user.HomePhone.Trim() : string.Empty;
            model.MobilePhone = !string.IsNullOrEmpty(user.MobilePhone) ? user.MobilePhone.Trim() : string.Empty;
            model.Birthday = Convert.ToDateTime(user.Birthday);
            model.EmailOptOut = member.EmailOptOut;
            return View(model);
        }

        // POST: /TrainingZone/EditProfile
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(MembershipProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {

                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                var user = UserManager.FindById(User.Identity.GetUserId());
                user.HomePhone = model.HomePhone;
                user.MobilePhone = model.MobilePhone;
                user.Birthday = model.Birthday;
                await UserManager.UpdateAsync(user);

                Member member = db.Members.Single(m => m.AspNetUserId == user.Id);
                member.ShirtSize = model.ShirtSize.Trim();
                member.ShortSize = model.ShortSize.Trim();
                member.AddressLine1 = model.AddressLine1;
                member.AddressLine2 = model.AddressLine2;
                member.City = model.City;
                member.Country = model.Country;
                member.PostZipCode = model.PostCodeZip;
                member.IDNumber = model.IDNumber;
                member.IDType = model.IDType;
                member.EmergencyContactName = model.EmergencyContactName;
                member.EmergencyContactNumber = model.EmergencyContactNumber;
                member.EmailOptOut = model.EmailOptOut;
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyRitual", "TrainingZone");
            }

            return View(model);
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

        public ActionResult GetNextOpenDays(int numberofdays)
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);
            List<DateTime> results = member.getUserHomeLocation().getDaysOpen(numberofdays, DateTime.UtcNow.AddHours(member.Location.TimeZoneOffset));
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
        public ActionResult GetBookingsByDate(string date)
        {
            //If the current date is the same then only show items for current day
            DateTime selectedDate = Convert.ToDateTime(date);

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());
            var member = db.Members.Single(m => m.AspNetUserId == user.Id);

            if (member.getActiveMembership() != null)
            {
                if (selectedDate.Date == DateTime.UtcNow.AddHours(member.Location.TimeZoneOffset).Date)
                {
                    selectedDate = DateTime.UtcNow.AddHours(member.Location.TimeZoneOffset);
                }

                string memberType = member.getActiveMembership().getMembershipType();
                TrainingZoneBookingData TrainingZoneModel = new TrainingZoneBookingData();
                List<GetUpcomingBookingSlots_Result> results =
                    db.GetUpcomingBookingSlots(member.HomeLocationId, selectedDate, member.Id).ToList();
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

            trainingZoneConfirmBookingModel.AllowBooking = isUserAllowedBooking(member, locationId, timeslot);
            
            //if member is session type then count number of available sessions.  
            //If you have no sessions available prevent them booking

            trainingZoneConfirmBookingModel.bookingLocation = db.Locations.FirstOrDefault(l => l.Id == locationId);
            trainingZoneConfirmBookingModel.bookingTimeslot = db.TimeSlots.FirstOrDefault(t => t.Id == timeSlotId);
            trainingZoneConfirmBookingModel.bookingDate = bookingDate;
            trainingZoneConfirmBookingModel.bookingMember = member;

            return View(trainingZoneConfirmBookingModel);
        }

        private bool isUserAllowedBooking(Member member, int locationId, TimeSlot timeslot)
        {
            if (member.HomeLocationId != locationId)
            {
                return false;
            }

            if (!member.hasActiveMembership())
            {
                return false;
            }

            if (member.hasActiveMembership())
            {
                if (member.getActiveMembership().getMembershipType() == "Off-Peak" &&  !timeslot.IsOffPeakSlot(locationId) )
                {
                    return false;
                }
            }
            
            return true;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public ActionResult AddNewBooking(int timeSlotId, int locationId, DateTime bookingDate, TrainingZoneConfirmBooking model)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            if (ModelState.IsValid)
            {
                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                var user = UserManager.FindById(User.Identity.GetUserId());
                var member = db.Members.Where(m => m.AspNetUserId == user.Id).Single();

                SessionBooking booking = new SessionBooking();
                booking.TimeSlotId = timeSlotId;
                booking.Date = bookingDate;
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