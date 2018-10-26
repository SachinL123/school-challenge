using BusinessLayer;
using Schoolchallenge.Model.Models;
using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Common.Helpers;
using SchoolChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolChallenge.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<TeacherViewModel> teacherList = ShowTeacherDetails();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        private IEnumerable<TeacherViewModel> ShowTeacherDetails()
        {
            TeacherManager teacherManager = new TeacherManager();
            IEnumerable<TeacherViewModel> teacherDetails = teacherManager.GetTeachers();
            return teacherDetails;
        }

        public JsonResult GetbyID(int ID)
        {
            TeacherManager TeacherManager = new TeacherManager();
            IEnumerable<TeacherViewModel> TeacherList = TeacherManager.GetTeachers(ID);
            return Json(TeacherList.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }        

        public ActionResult Update(TeacherViewModel teacherViewModel)
        {
            TeacherManager TeacherManager = new TeacherManager();
            TeacherManager.UpdateTeacher(teacherViewModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int Id)
        {
            TeacherManager TeacherManager = new TeacherManager();
            TeacherManager.DeleteTeacher(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(TeacherViewModel teacherViewModel)
        {
            TeacherManager TeacherManager = new TeacherManager();
            TeacherManager.AddTeacher(teacherViewModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadTeachers()
        {
            var postedFile = Request.Files[0];
            List<string> listErrors = new List<string>();
            if (!IsValidFile(postedFile, listErrors))
            {
                return Json(new { sucess = false, errors = string.Join("\n", listErrors) });
            }

            List<TeacherViewModel> importedTeachers = new List<TeacherViewModel>();
            using (StreamReader streamReader = new StreamReader(postedFile.InputStream))
            {
                string csvData;
                int i = 0;
                while (!streamReader.EndOfStream)
                {
                    csvData = streamReader.ReadLine();
                    if (i > 0)
                    {
                        TeacherViewModel teacher = TeacherHelper.ToModelFromCSV(csvData);
                        if (teacher != null)
                        {
                            importedTeachers.Add(teacher);
                        }
                    }

                    i++;
                }
            }

            if (importedTeachers != null && importedTeachers.Count > 0)
            {
                FileUploadLog fileUploadLog = new FileUploadLog()
                {
                    FileName = postedFile.FileName,
                    FileSize = postedFile.ContentLength,
                    UploadedAt = DateTime.Now
                };

                TeacherManager teacherManager = new TeacherManager();
                teacherManager.ProcessTeacherImport(importedTeachers, fileUploadLog);
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