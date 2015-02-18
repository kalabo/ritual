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
    public class QuarterlyAssessmentsController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: QuarterlyAssessments
        public ActionResult Index(string sortOrder, string searchString)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.MemberNameSortParm = String.IsNullOrEmpty(sortOrder) ? "membername_desc" : "";
            ViewBag.EmployeeNameSortParm = sortOrder == "Employee" ? "Employeename_desc" : "Employee";

            var quarterlyAssessments = from q in db.QuarterlyAssessments.Include(q => q.Member).Include(q => q.Employee) select q;

            if (!String.IsNullOrEmpty(searchString))
            {
                //quarterlyAssessments = quarterlyAssessments.Where(l => l.Member.LastName.Contains(searchString)
                //                       || l.Member.LastName.Contains(searchString)
                //                       || l.Member.FullName.Contains(searchString)
                //                       || l.Employee.FullName.Contains(searchString)
                //                       || l.Employee.LastName.Contains(searchString)
                //                       || l.Employee.FirstName.Contains(searchString)
                //                       || l.QAYear.ToString().Equals(searchString));
            }

            switch (sortOrder)
            {
                //case "membername_desc":
                //    quarterlyAssessments = quarterlyAssessments.OrderByDescending(l => (string)l.Member.LastName);
                //    break;
                //case "Employee":
                //    quarterlyAssessments = quarterlyAssessments.OrderBy(l => (string)l.Employee.LastName);
                //    break;
                //case "Employeename_desc":
                //    quarterlyAssessments = quarterlyAssessments.OrderByDescending(l => (string)l.Employee.LastName);
                //    break;
                //default:
                //    quarterlyAssessments = quarterlyAssessments.OrderBy(l => (string)l.Member.LastName);
                //    break;
            }
            return View(quarterlyAssessments.ToList());

        }

        // GET: QuarterlyAssessments/Details/5
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
            QuarterlyAssessment quarterlyAssessment = db.QuarterlyAssessments.Find(id);
            if (quarterlyAssessment == null)
            {
                return HttpNotFound();
            }
            return View(quarterlyAssessment);
        }

        // GET: QuarterlyAssessments/Create
        public ActionResult Create()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FullName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName");

            GetDropdownListValues();

            return View();
        }

        private void GetEditDropdownListValues(QuarterlyAssessment quarterlyAssessment)
        {
            var testoneactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Pull-up hold for time" }, 
                new { ID = "3", Name = "Max Pull-ups in 1 min" },  
            }, "ID", "Name", quarterlyAssessment.QATestOneType);
            ViewData["TestOneActionList"] = testoneactionlist;

            var testtwoactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Max Pushups in 1 min" },
            }, "ID", "Name", quarterlyAssessment.QATestTwoType);
            ViewData["TestTwoActionList"] = testtwoactionlist;

            var testthreeactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Level 1: Max Squats in 1 min" },
                new { ID = "3", Name = "Level 2: Max Goblet Squats in 1 min (8kg)" },
                new { ID = "4", Name = "Level 3: Max Goblet Squats in 1 min (12kg)" },
                new { ID = "5", Name = "Level 4: Max Goblet Squats in 1 min (16kg)" },
                new { ID = "6", Name = "Level 5: Max Goblet Squats in 1 min (20kg)" },
            }, "ID", "Name", quarterlyAssessment.QATestThreeType);
            ViewData["TestThreeActionList"] = testthreeactionlist;

            var testfouractionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Level 1: Max Burpee for 1 min w/o jump" },
                new { ID = "3", Name = "Level 2: Max Burpee for 1 min w/ jump" },
                new { ID = "4", Name = "Level 3: 50 Burpees w/o jump for time" },
                new { ID = "5", Name = "Level 4: 50 Burpees w/jump for time" },
                new { ID = "6", Name = "Level 5: 30 Burpees + pushup w/o jump for time" },
                new { ID = "7", Name = "Level 6: 30 Burpees + pushup w/ jump for time" },
            }, "ID", "Name", quarterlyAssessment.QATestFourType);
            ViewData["TestFourActionList"] = testfouractionlist;

            var testfiveactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Level 1: Squats" },
                new { ID = "3", Name = "Level 2: Medball Thrusters (6kg)" },
                new { ID = "4", Name = "Level 3: Medball Thrusters (9kg)" },
                new { ID = "5", Name = "Level 4: Dumbell Thrusters (2x5kg)" },
                new { ID = "6", Name = "Level 5:Dumbell Thrusters (2x10kg)" },
                new { ID = "7", Name = "Level 6: Dumbell Thrusters (2x15kg)" },
            }, "ID", "Name", quarterlyAssessment.QATestFiveType);
            ViewData["TestFiveActionList"] = testfiveactionlist;
        }

        private void GetDropdownListValues()
        {
            var testoneactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Pull-up hold for time" }, 
                new { ID = "3", Name = "Max Pull-ups in 1 min" },  
            }, "ID", "Name", -1);
            ViewData["TestOneActionList"] = testoneactionlist;

            var testtwoactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Max Pushups in 1 min" },
            }, "ID", "Name", -1);
            ViewData["TestTwoActionList"] = testtwoactionlist;

            var testthreeactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Level 1: Max Squats in 1 min" },
                new { ID = "3", Name = "Level 2: Max Goblet Squats in 1 min (8kg)" },
                new { ID = "4", Name = "Level 3: Max Goblet Squats in 1 min (12kg)" },
                new { ID = "5", Name = "Level 4: Max Goblet Squats in 1 min (16kg)" },
                new { ID = "6", Name = "Level 5: Max Goblet Squats in 1 min (20kg)" },
            }, "ID", "Name", -1);
            ViewData["TestThreeActionList"] = testthreeactionlist;

            var testfouractionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Level 1: Max Burpee for 1 min w/o jump" },
                new { ID = "3", Name = "Level 2: Max Burpee for 1 min w/ jump" },
                new { ID = "4", Name = "Level 3: 50 Burpees w/o jump for time" },
                new { ID = "5", Name = "Level 4: 50 Burpees w/jump for time" },
                new { ID = "6", Name = "Level 5: 30 Burpees + pushup w/o jump for time" },
                new { ID = "7", Name = "Level 6: 30 Burpees + pushup w/ jump for time" },
            }, "ID", "Name", -1);
            ViewData["TestFourActionList"] = testfouractionlist;

            var testfiveactionlist = new SelectList(new[] { 
                new { ID = "-1", Name = "Please Select Action" }, 
                new { ID = "1", Name = "SKIP" }, 
                new { ID = "2", Name = "Level 1: Squats" },
                new { ID = "3", Name = "Level 2: Medball Thrusters (6kg)" },
                new { ID = "4", Name = "Level 3: Medball Thrusters (9kg)" },
                new { ID = "5", Name = "Level 4: Dumbell Thrusters (2x5kg)" },
                new { ID = "6", Name = "Level 5:Dumbell Thrusters (2x10kg)" },
                new { ID = "7", Name = "Level 6: Dumbell Thrusters (2x15kg)" },
            }, "ID", "Name", -1);
            ViewData["TestFiveActionList"] = testfiveactionlist;
        }

        // POST: QuarterlyAssessments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,EmployeeId,QAQuarter,QAYear,QADateTime,QAClientRPE,QATestOneTitle,QATestOneType,QATestOneTimeReps,QATestOneNotes,QATestTwoTitle,QATestTwoType,QATestTwoTimeReps,QATestTwoNotes,QATestThreeTitle,QATestThreeType,QATestThreeTimeReps,QATestThreeNotes,QATestFourTitle,QATestFourType,QATestFourTimeReps,QATestFourNotes,QATestFiveTitle,QATestFiveType,QATestFiveTimeReps,QATestFiveNotes,QATestFiveRoundOneReps,QATestFiveRoundTwoReps,QATestFiveRoundThreeReps,QATestFiveRoundFourReps,QATestFiveRoundFiveReps,QATestFiveRoundSixReps,QATestFiveRoundSevenReps,QATestFiveRoundEightReps,QATestFiveTotalReps")] QuarterlyAssessment quarterlyAssessment)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.QuarterlyAssessments.Add(quarterlyAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                GetDropdownListValues();
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FullName", quarterlyAssessment.MemberId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", quarterlyAssessment.Employee);
            return View(quarterlyAssessment);
        }

        // GET: QuarterlyAssessments/Edit/5
        public ActionResult Edit(int? id)
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
            QuarterlyAssessment quarterlyAssessment = db.QuarterlyAssessments.Find(id);
            if (quarterlyAssessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FullName", quarterlyAssessment.MemberId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", quarterlyAssessment.EmployeeId);

            GetEditDropdownListValues(quarterlyAssessment);

            return View(quarterlyAssessment);
        }

        // POST: QuarterlyAssessments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,EmployeeId,QAQuarter,QAYear,QADateTime,QAClientRPE,QATestOneTitle,QATestOneType,QATestOneTimeReps,QATestOneNotes,QATestTwoTitle,QATestTwoType,QATestTwoTimeReps,QATestTwoNotes,QATestThreeTitle,QATestThreeType,QATestThreeTimeReps,QATestThreeNotes,QATestFourTitle,QATestFourType,QATestFourTimeReps,QATestFourNotes,QATestFiveTitle,QATestFiveType,QATestFiveTimeReps,QATestFiveNotes,QATestFiveRoundOneReps,QATestFiveRoundTwoReps,QATestFiveRoundThreeReps,QATestFiveRoundFourReps,QATestFiveRoundFiveReps,QATestFiveRoundSixReps,QATestFiveRoundSevenReps,QATestFiveRoundEightReps,QATestFiveTotalReps")] QuarterlyAssessment quarterlyAssessment)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Entry(quarterlyAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                GetEditDropdownListValues(quarterlyAssessment);
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FullName", quarterlyAssessment.MemberId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", quarterlyAssessment.EmployeeId);
            return View(quarterlyAssessment);
        }

        // GET: QuarterlyAssessments/Delete/5
        public ActionResult Delete(int? id)
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
            QuarterlyAssessment quarterlyAssessment = db.QuarterlyAssessments.Find(id);
            if (quarterlyAssessment == null)
            {
                return HttpNotFound();
            }
            return View(quarterlyAssessment);
        }

        // POST: QuarterlyAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            QuarterlyAssessment quarterlyAssessment = db.QuarterlyAssessments.Find(id);
            db.QuarterlyAssessments.Remove(quarterlyAssessment);
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
