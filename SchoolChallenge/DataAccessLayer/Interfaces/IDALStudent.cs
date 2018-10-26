using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDALStudent
    {
        void AddStudent(StudentViewModel studentViewModel, out int rowsAffected);
        IEnumerable<Student> GetStudents(int studentId = 0);
        IEnumerable<StudentViewModel> GetAssignedStudents(int teacherId);
        void UpdateStudent(StudentViewModel studentViewModel, out int rowsAffected);
        void UpdateStudentAssignnment(int teacherId, string studentId, out int rowsAffected);
        void DeleteStudent(int id, out int rowsAffected);
    }
}
