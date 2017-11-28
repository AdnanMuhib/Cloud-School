using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudSchool.Models;

namespace CloudSchool.Controllers
{
    public class ClassSectionsController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: ClassSections
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }

        // GET: ClassSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSection classSection = db.Sections.Find(id);
            if (classSection == null)
            {
                return HttpNotFound();
            }
            return View(classSection);
        }

        // GET: ClassSections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SectionTitle,ClassName,StartingRegistrationNumber,EndingRegistrationNumber")] ClassSection classSection)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(classSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classSection);
        }

        // GET: ClassSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSection classSection = db.Sections.Find(id);
            if (classSection == null)
            {
                return HttpNotFound();
            }
            return View(classSection);
        }

        // POST: ClassSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SectionTitle,ClassName,StartingRegistrationNumber,EndingRegistrationNumber")] ClassSection classSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classSection);
        }

        // GET: ClassSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSection classSection = db.Sections.Find(id);
            if (classSection == null)
            {
                return HttpNotFound();
            }
            return View(classSection);
        }

        // POST: ClassSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSection classSection = db.Sections.Find(id);
            db.Sections.Remove(classSection);
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
