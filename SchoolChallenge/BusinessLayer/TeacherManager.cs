using DataAccessLayer;
using DataAccessLayer.Interfaces;
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
    public class TeacherManager
    {
        IDALTeacher iDALTeacher;
        public TeacherManager()
        {
            iDALTeacher = new DLTeachers();
        }        

        public IEnumerable<TeacherViewModel> GetTeachers(int teacherId = 0)
        {
            return iDALTeacher.GetTeacherDetails(teacherId);
        }

        public bool DeleteTeacher(int TeacherId = 0)
        {
            int rowsAffected;
            iDALTeacher.DeleteTeacher(TeacherId, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public bool UpdateTeacher(TeacherViewModel teacherViewModel)
        {
            int rowsAffected;
            iDALTeacher.UpdateTeacher(teacherViewModel, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public bool AddTeacher(TeacherViewModel teacherViewModel)
        {
            int rowsAffected;
            iDALTeacher.AddTeacher(teacherViewModel, out rowsAffected);
            return rowsAffected > 0 ? true : false;
        }

        public void ProcessTeacherImport(List<TeacherViewModel> listTeachers, FileUploadLog fileUploadLog)
        {
            IEnumerable<TeacherViewModel> existingTeachers = GetTeachers();
            if (listTeachers != null && listTeachers.Count > 0)
            {
                List<FileData> fileData = new List<FileData>();
                foreach (TeacherViewModel teacherViewModel in listTeachers)
                {
                    if (IsTeacherUpdate(existingTeachers, teacherViewModel))
                    {
                        UpdateTeacher(teacherViewModel);
                        fileData.Add(new FileData() { ID = teacherViewModel.TeacherId.ToString(), IsUpdated = true });
                    }
                    else
                    {
                        AddTeacher(teacherViewModel);
                        fileData.Add(new FileData() { ID = teacherViewModel.TeacherId.ToString(), IsUpdated = false });
                    }
                }

                fileUploadLog.FileRows.AddRange(fileData);
            }
        }

        private bool IsTeacherUpdate(IEnumerable<TeacherViewModel> existingTeachers, TeacherViewModel Teacher)
        {
            bool isValid = false;
            if (existingTeachers != null && existingTeachers.Count() > 0)
            {
                isValid = existingTeachers.Where(x => x.TeacherId == Teacher.TeacherId).ToList().Count > 0 ? true : false;
            }

            return isValid;
        }
    }
}
