using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using Ritual.Data;
using Ritual.Web.Admin.Models;
using Ritual.Web.Admin.Services;

namespace Ritual.Web.Admin.Controllers
{
    public class MembersController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private RitualDBEntities db = new RitualDBEntities();


        public ActionResult AddMembership(int id)
        {
            MemberAddMembershipData addMemberModel = new MemberAddMembershipData();
            addMemberModel.Member = db.Members.Find(id);
            addMemberModel.ActiveMembership = addMemberModel.Member.getActiveMembership();
            addMemberModel.PastMemberships = addMemberModel.Member.getExpiredMemberships();
            addMemberModel.AvailablePackages = db.Packages.Where(p => p.PackageIsActive == true);
            addMemberModel.LocationPackagePrices = db.PackageLocationPrices.Where(pl => pl.LocationId == addMemberModel.Member.HomeLocationId);
            
            return View(addMemberModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMembershipConfirm(
            int memberid,
            int packageid,
            decimal selectedpackagemonthly,
            decimal selectedpackagetotal,
            decimal selectedpackagediscount,
            string selectedpackagediscountreason,
            decimal selectedpackagemonthlydiscount,
            decimal selectedpackagetotaldiscount,
            DateTime membershipstartdate,
            DateTime membershipenddate,
            decimal selectedpackageinitialpayment)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            MemberAddMembershipModel addModel = new MemberAddMembershipModel();
            addModel.membershipenddate = membershipenddate;
            addModel.selectedpackagemonthly = selectedpackagemonthly;
            addModel.selectedpackagetotal = selectedpackagetotal;
            addModel.selectedpackagediscount = selectedpackagediscount;
            addModel.selectedpackagediscountreason = selectedpackagediscountreason;
            addModel.selectedpackagemonthlydiscount = selectedpackagemonthlydiscount;
            addModel.selectedpackagetotaldiscount = selectedpackagetotaldiscount;
            addModel.membershipstartdate = membershipstartdate;
            addModel.membershipenddate = membershipenddate;
            addModel.selectedpackageinitialpayment = selectedpackageinitialpayment;
            addModel.member = db.Members.Find(memberid);
            addModel.package = db.Packages.Find(packageid);

            //if (ModelState.IsValid)
            //{
            //    //db.Members.Add();
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(addModel);
        }

        public ActionResult CancelMembership(int MemberId)
        {
            return View();
        }

        public ActionResult ExtendMembership(int MemberId)
        {
            return View();
        }

        public ActionResult TerminateMembership(int MemberId)
        {
            return View();
        }

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, string Command)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            ViewBag.LastNameSortParam = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.FirstNameSortParam = sortOrder == "firstname" ? "firstname_desc" : "firstname";

            var members = from m in db.Members.Include(m => m.AspNetUser).Include(m => m.Location) select m;

            if (Command == "Search")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    members = members.Where(m => m.AspNetUser.LastName.Contains(searchString)
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
                    members = members.OrderByDescending(m => m.AspNetUser.LastName);
                    break;
                case "firstname":
                    members = members.OrderBy(m => m.AspNetUser.FirstName);
                    break;
                case "firstname_desc":
                    members = members.OrderByDescending(m => m.AspNetUser.FirstName);
                    break;
                default:
                    members = members.OrderBy(m => m.AspNetUser.LastName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(members.ToPagedList(pageNumber, pageSize));
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
            Member currentMember = db.Members.Find(id);
            Membership activeMembership = currentMember.getActiveMembership();
            List<Membership> pastMemberships = currentMember.getExpiredMemberships();
            List<QuarterlyAssessment> assessments = currentMember.getQuarterlyAssessments(10);
            List<SessionBookingModel> pastBookings = currentMember.getPastBookings();
            List<SessionBookingModel> upcomingBookings = currentMember.getUpcomingBookings();

            var detailModel = new MemberDetailData();
            detailModel.Member = currentMember;
            detailModel.ActiveMembership = activeMembership;
            detailModel.PastMemberships = pastMemberships;
            detailModel.QuarterlyAssessments = assessments;
            detailModel.PastBookings = pastBookings;
            detailModel.UpcomingBookings = upcomingBookings;

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
        public ActionResult Create([Bind(Include = "Id,IdentificationNumber,EmailOptOut,HomeLocationId,AspNetUserId")] Member member)
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
            
            Member member = db.Members.Find(id);

            if (member == null)
            {
                return HttpNotFound();
            }

            //ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", member.AspNetUserId);
            //ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name", member.HomeLocationId);
            //return View(member);

            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            var user = UserManager.FindById(User.Identity.GetUserId());

            MembershipEditViewModel model = MembersService.GetModelForMyRitualEditProfile(user, member);

            return View(model);
        }

        //// POST: Members/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,IdentificationNumber,EmailOptOut,HomeLocationId,AspNetUserId")] Member member)
        //{
        //    //Redirect back to login page if not authenticated
        //    if (!HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(member).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", member.AspNetUserId);
        //    ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name", member.HomeLocationId);
        //    return View(member);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MembershipEditViewModel model)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Member member = db.Members.Find(model.MemberId);

            if (member == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {

                db.Entry(member).State = EntityState.Modified;
                MembersService.SaveMyRitualEditProfile(model, member);
                db.SaveChanges();

                this.ApplicationDbContext = new ApplicationDbContext();
                this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
                var user = UserManager.FindById(User.Identity.GetUserId());
                user.HomePhone = model.HomePhone;
                user.MobilePhone = model.MobilePhone;
                user.Birthday = model.Birthday;
                user.Gender = model.Gender;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Salutation = model.Salutation;
                await UserManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            //ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", member.AspNetUserId);
            //ViewBag.HomeLocationId = new SelectList(db.Locations, "Id", "Name", member.HomeLocationId);
            return View(model);
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
