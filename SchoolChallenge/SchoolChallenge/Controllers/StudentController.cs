using BusinessLayer;
using SchoolChallenge.Models;
using SchoolChallenge.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolChallenge.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {            
            return View();
        }
    }
}