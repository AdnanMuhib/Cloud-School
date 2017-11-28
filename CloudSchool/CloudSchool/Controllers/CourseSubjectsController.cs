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
    public class CourseSubjectsController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: CourseSubjects
        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }

        // GET: CourseSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseSubject courseSubject = db.Subjects.Find(id);
            if (courseSubject == null)
            {
                return HttpNotFound();
            }
            return View(courseSubject);
        }

        // GET: CourseSubjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubjectTitle,TotalMarks,ObtainedMarks")] CourseSubject courseSubject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(courseSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseSubject);
        }

        // GET: CourseSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseSubject courseSubject = db.Subjects.Find(id);
            if (courseSubject == null)
            {
                return HttpNotFound();
            }
            return View(courseSubject);
        }

        // POST: CourseSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubjectTitle,TotalMarks,ObtainedMarks")] CourseSubject courseSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseSubject);
        }

        // GET: CourseSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseSubject courseSubject = db.Subjects.Find(id);
            if (courseSubject == null)
            {
                return HttpNotFound();
            }
            return View(courseSubject);
        }

        // POST: CourseSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseSubject courseSubject = db.Subjects.Find(id);
            db.Subjects.Remove(courseSubject);
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
