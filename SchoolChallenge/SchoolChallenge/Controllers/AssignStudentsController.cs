using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolChallenge.Controllers
{
    public class AssignStudentsController : Controller
    {
        // GET: AssignStudents
        public ActionResult Index()
        {
            AssignStudentManager assignStudentManager = new AssignStudentManager();
            ViewBag.Techers =  assignStudentManager.GetTeachers();
            return View();
        }

        public ActionResult UpdateAssignemnts(int teacherId, string studentIds)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.UpdateStudentAssignnment(teacherId, studentIds);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}