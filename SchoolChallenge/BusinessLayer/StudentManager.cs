using DataAccessLayer.Interfaces;
using Schoolchallenge.DataAccess;
using Schoolchallenge.Model.Models;
using Schoolchallenge.Model.ViewModels;
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
        IDALStudent iDALStudent;
        private static log4net.ILog Log { get; set; }

        log4net.ILog log = log4net.LogManager.GetLogger(typeof(StudentManager));

        public StudentManager()
        {
            iDALStudent = new DLStudents();
        }

        public StudentManager(IDALStudent iDALStudentObj)
        {
            iDALStudent = iDALStudentObj;
        }

        public IEnumerable<StudentViewModel> GetStudents(int studentId = 0)
        {
            IEnumerable<Student> studentDetails = iDALStudent.GetStudents(studentId);
            return ToViewModel(studentDetails);
        }

        public IEnumerable<StudentViewModel> GetAssignedStudents(int teacherId)
        {
            if (teacherId == 0)
            {
                throw new Exception("Invalid tecaher Id");
            }

            IEnumerable<StudentViewModel> assignedStudents = iDALStudent.GetAssignedStudents(teacherId);
            return assignedStudents;
        }       

        public bool DeleteStudent(int studentId = 0)
        {
            int rowsAffected;
            iDALStudent.DeleteStudent(studentId, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public bool UpdateStudent(StudentViewModel studentViewModel)
        {
            int rowsAffected;
            iDALStudent.UpdateStudent(studentViewModel, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public bool AddStudent(StudentViewModel studentViewModel)
        {
            int rowsAffected;
            iDALStudent.AddStudent(studentViewModel, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public bool UpdateStudentAssignnment(int teacherId, string studentId)
        {
            int rowsAffected;
            iDALStudent.UpdateStudentAssignnment(teacherId, studentId, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public void ProcessStudentImport(List<StudentViewModel> listStudents, FileUploadLog fileUploadLog)
        {
            IEnumerable<StudentViewModel> existingStudents = GetStudents();
            if (listStudents != null && listStudents.Count > 0)
            {
                List<FileData> fileData = new List<FileData>();
                foreach (StudentViewModel student in listStudents)
                {
                    if (IsStudentUpdate(existingStudents, student))
                    {
                        UpdateStudent(student);
                        log.Info(string.Format("{0}-{1}", "Updated Record:-", student.Number));
                    }
                    else
                    {
                        AddStudent(student);
                        log.Info(string.Format("{0}-{1}", "Inserted Record:-", student.Number));
                    }
                }

                fileUploadLog.FileRows.AddRange(fileData);
            }
        }

        public bool IsStudentUpdate(IEnumerable<StudentViewModel> existingStudents, StudentViewModel student)
        {
            bool isValid = false;
            if (existingStudents != null && existingStudents.Count() > 0)
            {
                isValid = existingStudents.Where(x => x.Number.Trim() == student.Number.Trim()).ToList().Count > 0 ? true : false;
            }

            return isValid;
        }

        public static IEnumerable<StudentViewModel> ToViewModel(IEnumerable<Student> listStudents)
        {
            List<StudentViewModel> listStudentViewModels = new List<StudentViewModel>();
            if (listStudents != null && listStudents.Count() > 0)
            {
                foreach (Student student in listStudents)
                {
                    listStudentViewModels.Add(new StudentViewModel()
                    {
                        StudentId = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        HasScholarship = student.HasScholarship,
                        Number = student.Number
                    });
                }
            }

            return listStudentViewModels;
        }
    }
}
