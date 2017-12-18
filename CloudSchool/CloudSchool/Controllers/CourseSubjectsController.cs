using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudSchool.Models;
using Microsoft.AspNet.Identity;

namespace CloudSchool.Controllers
{
    public class CourseSubjectsController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: CourseSubjects
        public ActionResult Index(string sortOrder, string searchString)
        {

            string id = User.Identity.GetUserId();
            var subjects = db.Subjects.Where(d => d.SchoolID.Equals(id));

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            
            if (!String.IsNullOrEmpty(searchString))
            {
                subjects = subjects.Where(s => s.SubjectTitle.Contains(searchString)
                                       || s.SubjectTitle.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    subjects = subjects.OrderByDescending(s => s.SubjectTitle);
                    break;
                
                default:
                    subjects = subjects.OrderBy(s => s.SubjectTitle);
                    break;
            }
            return View(subjects.ToList());
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
            string id = User.Identity.GetUserId();
            ViewBag.Teachers = new SelectList(db.Teachers.Where(t => t.SchoolID.Equals(id)).ToList(), "RegistrationNumber", "RegistrationNumber");
            ViewBag.Courses = new SelectList(db.Classes.Where(d => d.SchoolID.Equals(id)).ToList(), "Name", "Name");
            //ViewBag.courses=new SelectList(db.Classes.Where(t=>t.))
            return View();
        }

        // POST: CourseSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubjectTitle,TotalMarks,ObtainedMarks,TeacherRegistrationNumber,CourseName")] CourseSubject courseSubject)
        {
            string id = User.Identity.GetUserId();
            var teacher = db.Teachers.Single(t=>t.RegistrationNumber.Equals(courseSubject.TeacherRegistrationNumber));
            var course = db.Classes.Single(t => t.Name.Equals(courseSubject.CourseName));
            courseSubject.CourseID = course.ID.ToString();
            courseSubject.TeacherID = teacher.ID.ToString();
            courseSubject.SchoolID = id;
            if (ModelState.IsValid)
            {
                courseSubject.SchoolID = User.Identity.GetUserId();
                db.Subjects.Add(courseSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseSubject);
        }

        // GET: CourseSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            string schoolid = User.Identity.GetUserId();
            ViewBag.Teachers = new SelectList(db.Teachers.Where(t => t.SchoolID.Equals(schoolid)).ToList(), "RegistrationNumber", "RegistrationNumber");
            ViewBag.Courses = new SelectList(db.Classes.Where(d => d.SchoolID.Equals(schoolid)).ToList(), "Name", "Name");
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
        public ActionResult Edit([Bind(Include = "ID,SubjectTitle,TotalMarks,ObtainedMarks,TeacherRegistrationNumber,CourseName")] CourseSubject courseSubject)
        {
            string id = User.Identity.GetUserId();
            var teacher = db.Teachers.Single(t => t.RegistrationNumber.Equals(courseSubject.TeacherRegistrationNumber));
            var course = db.Classes.Single(t => t.Name.Equals(courseSubject.CourseName));
            courseSubject.CourseID = course.ID.ToString();
            courseSubject.TeacherID = teacher.ID.ToString();
            courseSubject.SchoolID = id;

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
