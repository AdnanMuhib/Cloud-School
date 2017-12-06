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

    public class DashboardsController : Controller
    {
        //public bool isAdminUser() {
        //    return false;
        //}
        //public bool isSchoolAdmin() {
        //    return false;
        //}

        private CloudSchoolDbContext db = new CloudSchoolDbContext();

        // GET: Dashboards
        public ActionResult Index()
        {
            return View(db.Dashboards.ToList());
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
