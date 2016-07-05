using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//added
using ContosoUniversity.DAL;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers {
    public class HomeController : Controller {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index() {
            return View();
        }



        public ActionResult About() {
            //query syntax
            //IQueryable<EnrollmentDateGroup> data = from student in db.Students
            //                                       group student by student.EnrollmentDate into dateGroup
            //                                       select new EnrollmentDateGroup() {
            //                                           EnrollmentDate = dateGroup.Key,
            //                                           StudentCount = dateGroup.Count()
            //                                       };

            //method syntax
            IQueryable<EnrollmentDateGroup> data = db.Students.GroupBy(x => x.EnrollmentDate)
                                                              .Select(stu => new EnrollmentDateGroup { EnrollmentDate = stu.Key, StudentCount = stu.Count() });
            return View(data.ToList());
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}