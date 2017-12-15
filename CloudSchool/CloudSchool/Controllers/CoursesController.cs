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
    public class CoursesController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            var courses = db.Classes.Where(d => d.SchoolID.Equals(id));
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
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

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
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

        // GET: Courses/Edit/5
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

        // POST: Courses/Edit/5
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

        // GET: Courses/Delete/5
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

        // POST: Courses/Delete/5
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
