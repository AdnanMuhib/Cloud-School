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
    public class InstitutesController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: Institutes
        public ActionResult Index()
        {
            return View(db.Institutes.ToList());
        }

        // GET: Institutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = db.Institutes.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // GET: Institutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Institutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,TypeOfInstitute,PhoneNumber,Email,Password,Address,Logo")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Institutes.Add(institute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(institute);
        }

        // GET: Institutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = db.Institutes.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // POST: Institutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,TypeOfInstitute,PhoneNumber,Email,Password,Address,Logo")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institute);
        }

        // GET: Institutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = db.Institutes.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // POST: Institutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institute institute = db.Institutes.Find(id);
            db.Institutes.Remove(institute);
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
