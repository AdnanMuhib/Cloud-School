using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudSchool.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CloudSchool.Controllers
{
    public class TeachersController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: Teachers
        public ActionResult Index()
        {

            return View(db.Teachers.ToList());
        }
        // GET: Teachers
        public ActionResult InstituteTeachers()
        {
            string id = User.Identity.GetUserId();
            var teachers = db.Teachers.Where(d => d.SchoolID.Equals(id));
            return View(teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }
        // GET: Teachers/Details/5
        public ActionResult DisplayTeacher(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }


        // GET: Teachers/Create
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Create()
        {
            return View();
        }
        // GET: Teachers/Create
        public ActionResult AddTeacher()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Create([Bind(Include = "ID,Qualification,Experience,ProfilePicture,Name,FatherName,DateOfBirth,EmailID,CNIC,Password,InstituteName,Address,MobileNumber,Gender")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> AddTeacher([Bind(Include = "ID,Qualification,Experience,ProfilePicture,Name,FatherName,DateOfBirth,EmailID,CNIC,Password,InstituteName,Address,MobileNumber,Gender,SchoolID")] Teacher teacher, HttpPostedFileBase imgFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(imgFile.FileName);
            string extension = Path.GetExtension(imgFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            teacher.ProfilePicture = "/Images/Accounts/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Images/Accounts/"), fileName);


            teacher.SchoolID = User.Identity.GetUserId();
            teacher.InstituteName = User.Identity.GetUserName();

            if (ModelState.IsValid)
            {
                // creating new Account in the Identity Manager
                ApplicationDbContext context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser();
                user.UserName = teacher.Name;
                user.Email = teacher.EmailID;
                user.ProfilePicture = teacher.ProfilePicture;
                string password = teacher.Password;

                var chkusr = UserManager.Create(user, password);


                if (chkusr.Succeeded)
                {
                    imgFile.SaveAs(fileName);
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    await UserManager.AddToRoleAsync(user.Id, "Teacher");
                    return RedirectToAction("InstituteTeachers", "Teachers");
                }

                return RedirectToAction("InstituteTeachers");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        [Authorize(Roles = "SchoolAdmin, Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }
        // GET: Teachers/Edit/5
        public ActionResult EditTeacher(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }
        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin, Teacher")]
        public ActionResult Edit([Bind(Include = "ID,Qualification,Experience,ProfilePicture,Name,FatherName,DateOfBirth,EmailID,CNIC,Password,InstituteName,Address,MobileNumber,Gender")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin, Teacher")]
        public ActionResult EditTeacher([Bind(Include = "ID,Qualification,Experience,ProfilePicture,Name,FatherName,DateOfBirth,EmailID,CNIC,Password,InstituteName,Address,MobileNumber,Gender")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("InstituteTeachers");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }
        // GET: Teachers/Delete/5
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult DeleteTeacher(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: Teachers/Delete/5
        [HttpPost, ActionName("DeleteTeacher")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult DeleteConfirmedTeacher(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("InstituteTeachers");
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
