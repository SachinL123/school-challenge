using Schoolchallenge.DataAccess;
using SchoolChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentManager
    {
        public IEnumerable<Student> GetStudents(int studentId = 0)
        {
            List<Student> listStudents = new List<Student>();        
            DLStudents dalStudent = new DLStudents();
            dalStudent.GetStudents();
            return listStudents;
        }
    }
}
