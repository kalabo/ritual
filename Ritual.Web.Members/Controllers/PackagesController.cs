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
    public class PackagesController : Controller
    {
        private RitualDBEntities db = new RitualDBEntities();

        // GET: Packages
        public ActionResult Index(string sortOrder, string searchString, string Command)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PackageTypeSortParm = sortOrder == "packagetype" ? "packagetype_desc" : "packagetype";

            var packages = from m in db.Packages.Include(m => m.PackageType) select m;

            if (Command == "Search")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    packages = packages.Where(p => p.Name.Contains(searchString)
                                           || p.PackageType.Name.Contains(searchString));
                }
            }
            else if (Command == "Reset")
            {

            }

            switch (sortOrder)
            {
                case "name_desc":
                    packages = packages.OrderByDescending(p => p.Name);
                    break;
                case "packagetype":
                    packages = packages.OrderBy(p => p.PackageType);
                    break;
                case "packagetype_desc":
                    packages = packages.OrderByDescending(p => p.PackageType);
                    break;
                default:
                    packages = packages.OrderBy(p => p.Name);
                    break;
            }

            return View(packages.ToList());
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "Name");

            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PackageTypeId,PackagePeriodMonths,PackageSuspensionLimit,PackageVisitLimit,PackageIsActive,PackageIsReoccuring,PackagePayInFull")] Package package)
        {
            //Redirect back to login page if not authenticated
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "Name", package.PackageTypeId);

            return View(package);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }

            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "Name", package.PackageTypeId);

            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PackageType,PackagePeriodMonths,PackageSuspensionLimit,PackageVisitLimit,PackageIsActive,PackageIsReoccuring,PackagePayInFull")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
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
