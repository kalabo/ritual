using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ritual.Data;

namespace Ritual.Web.Admin.Controllers
{
    public class InitialAssessmentsController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: InitialAssessments
        public ActionResult Index()
        {
            var initialAssessments = db.InitialAssessments.Include(i => i.Employee).Include(i => i.Member);
            return View(initialAssessments.ToList());
        }

        // GET: InitialAssessments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitialAssessment initialAssessment = db.InitialAssessments.Find(id);
            if (initialAssessment == null)
            {
                return HttpNotFound();
            }
            return View(initialAssessment);
        }

        // GET: InitialAssessments/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "AspNetUserId"); 
            ViewBag.MemberId = new SelectList(db.Members.Where(m => m.InitialAssessments.Count == 0), "Id", "IdentificationNumber");
           
            return View();
        }

        // POST: InitialAssessments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssessmentDateTime,MemberId,EmployeeId,ClientCheckDetails,ClientHearAboutRitual,ClientTrainingHistory,ClientInjuriesMedicalIssues,ClientPosturalArea,ClientPosturalAreaDetails,MovementAnteriorTrunk,MovementPosteriorTrunk,MovementHorizontalPush,MovementVerticalPush,MovementHorizontalPull,MovementVerticalPull,MovementHipPush,MovementHipPull,MovementSingleLeg,MovementLocomotion1,MovementLocamotion2,MovementDetails,Recommendation,WorkoutExplained,WarmupExplained,ClientEmployeeReminder,AdditionalClientProgress,AdditionalClientTips")] InitialAssessment initialAssessment)
        {
            if (ModelState.IsValid)
            {
                db.InitialAssessments.Add(initialAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "AspNetUserId", initialAssessment.EmployeeId);
            ViewBag.MemberId = new SelectList(db.Members.Where(m => m.InitialAssessments.Count == 0), "Id", "IdentificationNumber", initialAssessment.MemberId);
            return View(initialAssessment);
        }

        // GET: InitialAssessments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitialAssessment initialAssessment = db.InitialAssessments.Find(id);
            if (initialAssessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "AspNetUserId", initialAssessment.EmployeeId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "IdentificationNumber", initialAssessment.MemberId);
            return View(initialAssessment);
        }

        // POST: InitialAssessments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssessmentDateTime,MemberId,EmployeeId,ClientCheckDetails,ClientHearAboutRitual,ClientTrainingHistory,ClientInjuriesMedicalIssues,ClientPosturalArea,ClientPosturalAreaDetails,MovementAnteriorTrunk,MovementPosteriorTrunk,MovementHorizontalPush,MovementVerticalPush,MovementHorizontalPull,MovementVerticalPull,MovementHipPush,MovementHipPull,MovementSingleLeg,MovementLocomotion1,MovementLocamotion2,MovementDetails,Recommendation,WorkoutExplained,WarmupExplained,ClientEmployeeReminder,AdditionalClientProgress,AdditionalClientTips")] InitialAssessment initialAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(initialAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "AspNetUserId", initialAssessment.EmployeeId);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "IdentificationNumber", initialAssessment.MemberId);
            return View(initialAssessment);
        }

        // GET: InitialAssessments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InitialAssessment initialAssessment = db.InitialAssessments.Find(id);
            if (initialAssessment == null)
            {
                return HttpNotFound();
            }
            return View(initialAssessment);
        }

        // POST: InitialAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InitialAssessment initialAssessment = db.InitialAssessments.Find(id);
            db.InitialAssessments.Remove(initialAssessment);
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
