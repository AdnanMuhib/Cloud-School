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
using LumenWorks.Framework.IO.Csv;
using System.Globalization;

namespace CloudSchool.Controllers
{
    public class StudentsController : Controller
    {
        private CloudSchoolDbContext db = new CloudSchoolDbContext();
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            var students = db.Students.Where(d => d.SchoolID.Equals(id));
            return View(students.ToList());
        }
        // GET: View to upload students CSV File
        public ActionResult Upload()
        {

            return View();
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var institute = db.Institutes.Single(d => d.AccountID.Equals(userId));
                string instituteName = institute.Name;
                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();
                        using (CsvReader csvReader =
                            new CsvReader(new StreamReader(stream), true))
                        {
                            csvTable.Load(csvReader);
                        }
                        // This Code gets the columns Names and the row data from csv for further processing
                        // Columns Names
                        List<string> lstStudents = new List<string>();
                        foreach (DataColumn col in csvTable.Columns)
                        {
                            //Console.WriteLine(col.ColumnName);
                            lstStudents.Add(col.ColumnName);
                        }
                        // rows Data
                        foreach (DataRow row in csvTable.Rows)
                        {
                            // Creating Student Object from Uploaded CSV File
                            Student student = new Student
                            {
                                Name = row["UserName"].ToString(),
                                FatherName = row["FatherName"].ToString(),
                                Address = row["Address"].ToString(),
                                CNIC = row["CNIC"].ToString(),
                                EmailID = row["EmailId"].ToString(),
                                EmailIDParents = row["ParentsEmail"].ToString(),
                                Gender = row["Gender"].ToString(),
                                InstituteName = instituteName,
                                SchoolID = User.Identity.GetUserId(),
                                MobileNumber = row["MobileNumber"].ToString(),
                                RegistrationNumber = row["RegNumber"].ToString(),
                                LastPassedExam = row["LastPassedExam"].ToString(),
                                LastExamTotalMarks = Int32.Parse(row["LastExamTotalMarks"].ToString()),
                                LastExamObtainedMarks = row["LastExamObtainedMarks"].ToString(),
                                ProfilePicture = row["ProfilePicture"].ToString(),
                                Password = row["Password"].ToString()
                            };

                            DateTime DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                            student.DateOfBirth = DateOfBirth;


                            var user = new ApplicationUser();
                            user.UserName = student.CNIC;
                            user.Email = student.EmailID;
                            user.ProfilePicture = student.ProfilePicture;
                            string password = student.Password;

                            var chkusr = UserManager.Create(user, password);


                            if (chkusr.Succeeded)
                            {
                                db.Students.Add(student);
                                db.SaveChanges();
                                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                                // Send an email with this link
                                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                                await UserManager.AddToRoleAsync(user.Id, "Student");

                            }

                            //return RedirectToAction("Index");
                        }
                        return RedirectToAction("Index", "Students");
                       // return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Create()
        {
            string id = User.Identity.GetUserId();
            ViewBag.Courses = new SelectList(db.Classes.Where(d => d.SchoolID.Equals(id)).ToList(), "Name", "Name");
            ViewBag.Sections = new SelectList(db.Sections.Where(d => d.SchoolID.Equals(id)).ToList(), "SectionTitle", "SectionTitle");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "ID,LastPassedExam,LastExamTotalMarks,LastExamObtainedMarks,RegistrationNumber,EnrolledClassName,EnrolledSectionName,EmailIDParents,ProfilePicture,Name,FatherName,DateOfBirth,EmailID,CNIC,Password,InstituteName,Address,MobileNumber,Gender")] Student student, string EnrolledClassName, HttpPostedFileBase imgFile)
        {
            ViewBag.Sections = new SelectList(db.Sections, "SectionTitle", "SectionTitle");
            var classes = db.Classes.Single(c => c.Name.Equals(student.EnrolledClassName));
            student.CourseID = classes.ID;
            string fileName = Path.GetFileNameWithoutExtension(imgFile.FileName);
            string extension = Path.GetExtension(imgFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            student.ProfilePicture = "/Images/Accounts/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Images/Accounts/"), fileName);


            student.SchoolID = User.Identity.GetUserId();
            student.InstituteName = User.Identity.GetUserName();

            if (ModelState.IsValid)
            {
                // creating new Account in the Identity Manager

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser();
                user.UserName = student.RegistrationNumber;
                user.Email = student.EmailID;
                user.ProfilePicture = student.ProfilePicture;
                string password = student.Password;

                var chkusr = UserManager.Create(user, password);


                if (chkusr.Succeeded)
                {
                    imgFile.SaveAs(fileName);
                    db.Students.Add(student);
                    db.SaveChanges();
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    await UserManager.AddToRoleAsync(user.Id, "Student");
                    return RedirectToAction("Index", "Students");
                }

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Edit(int? id)
        {
            string idd = User.Identity.GetUserId();
            ViewBag.Courses = new SelectList(db.Classes.Where(d => d.SchoolID.Equals(idd)).ToList(), "Name", "Name");
            ViewBag.Sections = new SelectList(db.Sections.Where(d => d.SchoolID.Equals(idd)).ToList(), "SectionTitle", "SectionTitle");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            //var sections = db.Sections.Where(s => s.CourseID.Equals(student.CourseID));
            //ViewBag.Sections = new SelectList(sections, "SectionTitle", "SectionTitle");

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Edit([Bind(Include = "ID,LastPassedExam,LastExamTotalMarks,LastExamObtainedMarks,RegistrationNumber,EnrolledClassName,EnrolledSectionName,EmailIDParents,ProfilePicture,Name,FatherName,DateOfBirth,EmailID,CNIC,Password,InstituteName,Address,MobileNumber,Gender")] Student student)
        {
            var sections = db.Sections.Single(c => c.SectionTitle.Equals(student.EnrolledSectionName));
            student.SectionID = sections.ID;

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "SchoolAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
