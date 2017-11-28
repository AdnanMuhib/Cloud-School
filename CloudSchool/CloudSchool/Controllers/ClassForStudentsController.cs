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
    public class ClassForStudentsController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: ClassForStudents
        public ActionResult Index()
        {
            return View(db.Classes.ToList());
        }

        // GET: ClassForStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassForStudents classForStudents = db.Classes.Find(id);
            if (classForStudents == null)
            {
                return HttpNotFound();
            }
            return View(classForStudents);
        }

        // GET: ClassForStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassForStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,year,NumberOfSections")] ClassForStudents classForStudents)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(classForStudents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classForStudents);
        }

        // GET: ClassForStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassForStudents classForStudents = db.Classes.Find(id);
            if (classForStudents == null)
            {
                return HttpNotFound();
            }
            return View(classForStudents);
        }

        // POST: ClassForStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,year,NumberOfSections")] ClassForStudents classForStudents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classForStudents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classForStudents);
        }

        // GET: ClassForStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassForStudents classForStudents = db.Classes.Find(id);
            if (classForStudents == null)
            {
                return HttpNotFound();
            }
            return View(classForStudents);
        }

        // POST: ClassForStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassForStudents classForStudents = db.Classes.Find(id);
            db.Classes.Remove(classForStudents);
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
