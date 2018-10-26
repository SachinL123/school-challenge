using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDALTeacher
    {
        IEnumerable<Teacher> GetTeachers(int teacherId = 0);
        IEnumerable<TeacherViewModel> GetTeacherDetails(int teacherId = 0);
        void UpdateTeacher(TeacherViewModel teacherViewModel, out int rowsAffected);
        void DeleteTeacher(int id, out int rowsAffected);
        void AddTeacher(TeacherViewModel teacherViewModel, out int rowsAffected);

    }
}
