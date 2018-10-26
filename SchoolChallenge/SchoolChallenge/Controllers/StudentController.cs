using BusinessLayer;
using Schoolchallenge.Model.Models;
using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Common;
using SchoolChallenge.Common.Helpers;
using SchoolChallenge.Models;
using SchoolChallenge.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolChallenge.Controllers
{
    public class StudentController : Controller
    {
        private static log4net.ILog Log { get; set; }

        log4net.ILog log = log4net.LogManager.GetLogger(typeof(StudentController));
        // GET: Student
        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<StudentViewModel> studentList = ShowStudentDetails();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAssignedStudents(int teacherId)
        {
            StudentManager studentManager = new StudentManager();
            IEnumerable<StudentViewModel> studentDetails = studentManager.GetAssignedStudents(teacherId);
            return Json(studentDetails, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            StudentManager studentManager = new StudentManager();
            IEnumerable<StudentViewModel> studentList = studentManager.GetStudents(ID);
            return Json(studentList.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }       

        public ActionResult Update(StudentViewModel studentViewModel)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.UpdateStudent(studentViewModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int Id)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.DeleteStudent(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(StudentViewModel studentViewModel)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.AddStudent(studentViewModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        private IEnumerable<StudentViewModel> ShowStudentDetails()
        {
            StudentManager studentManager = new StudentManager();
            IEnumerable<StudentViewModel> studentDetails = studentManager.GetStudents();
            return studentDetails;
        }

        [HttpPost]
        public ActionResult UploadStudents()
        {
            
            var postedFile = Request.Files[0];           
            List<string> listErrors = new List<string>();
            if (!IsValidFile(postedFile, listErrors))
            {
                return Json(new { sucess = false, errors = string.Join("\n", listErrors) });
            }

            List<StudentViewModel> importedStudents = new List<StudentViewModel>();
            using (StreamReader streamReader = new StreamReader(postedFile.InputStream))
            {
                string csvData;
                int i = 0;                
                while (!streamReader.EndOfStream)
                {
                    csvData = streamReader.ReadLine();
                    if (i > 0)
                    {                        
                        StudentViewModel studentViewModel = StudentHelper.ToViewModelFromCSV(csvData);
                        if (studentViewModel != null)
                        {
                            importedStudents.Add(studentViewModel);
                        }
                    }

                    i++;
                }
            }

            if (importedStudents != null && importedStudents.Count > 0)
            {
                FileUploadLog fileUploadLog = new FileUploadLog()
                {
                    FileName = postedFile.FileName,
                    FileSize = postedFile.ContentLength,
                    UploadedAt = DateTime.Now      
                };

                log.Info("File Uploaded");
                log.Info(string.Format("{0} {1}", "File Name", fileUploadLog.FileName));
                log.Info(string.Format("{0} {1}", "File Size", fileUploadLog.FileSize));
                log.Info(string.Format("{0} {1}", "Rows affected", importedStudents.Count));
                StudentManager StudentManager = new StudentManager();                
                StudentManager.ProcessStudentImport(importedStudents, fileUploadLog);
            }

            return Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
        }

        private bool IsValidFile(HttpPostedFileBase httpPostedFileBase, List<string> errors)
        {
            bool isValid = true;
            if (httpPostedFileBase == null)
            {
                isValid = false;
                errors.Add("file cannnot be null");
            }          

            if (Path.GetExtension(httpPostedFileBase.FileName) != ".csv")
            {
                isValid = false;
                errors.Add("only csv file supported");
            }

            return isValid;
        }
    }
}