using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ritual.Data;
using Ritual.Web.Members.Models;
using Ritual.Web.Members.Services.MyRitual;
using Ritual.Web.Members.Services.TrainingZone;

namespace Ritual.Web.Members.Controllers
{
    public class MyRitualController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private RitualDBEntities db = new RitualDBEntities();

        #region Constants
        private const int AvatarStoredWidth = 160;
        private const int AvatarStoredHeight = 160;
        private const int AvatarScreenWidth = 400;
        private const string TempFolder = "/Content/images/Temp";
        private const string MapTempFolder = "~" + TempFolder;
        private const string AvatarPath = "/Content/images/Avatars";
        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };
        #endregion

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

            MyRitualDashboardData model = MyRitualService.GetModelForMyRitual(user);

            return View(model);
        }


        // GET: /TrainingZone/SuspendMembership
        public ActionResult SuspendMembership()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Account");
            }

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            MembershipSuspensionViewModel model = MyRitualService.GetMembershipSuspension(user);

            return View(model);
        }

        // POST: /TrainingZone/SuspendMembership
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendMembership(MembershipSuspensionViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                var user = UserManager.FindById(User.Identity.GetUserId());

                MyRitualService.SaveSuspendMembership(user, model);
                return RedirectToAction("Dashboard", "MyRitual");
            }

            return View(model);
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

            MembershipProfileEditViewModel model = MyRitualService.GetModelForMyRitualEditProfile(user);

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

                MyRitualService.SaveMyRitualEditProfile(user, model);
                return RedirectToAction("Dashboard", "MyRitual");
            }

            return View(model);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }


        #region private photo upload methods
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


        #endregion
        
    }

}