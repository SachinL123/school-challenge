using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AssignStudentManager
    {
        IDALTeacher iDALTeacher;
        public AssignStudentManager()
        {
            iDALTeacher = new DLTeachers();
        }

        public IEnumerable<TeacherViewModel> GetTeachers(int teacherId = 0)
        {
            IEnumerable<TeacherViewModel> teacherDetails = iDALTeacher.GetTeacherDetails(teacherId);
            return teacherDetails;
        }
    }
}
