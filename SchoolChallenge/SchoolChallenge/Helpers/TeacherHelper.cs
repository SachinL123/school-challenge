using System;
using System.Linq;
using Schoolchallenge.Model.ViewModels;

namespace SchoolChallenge.Common.Helpers
{
    public class TeacherHelper
    {
        public static TeacherViewModel ToModelFromCSV(string csvData)
        {
            TeacherViewModel teacher = null;
            if (!string.IsNullOrEmpty(csvData) && csvData.Contains(','))
            {
                string[] teacherData = csvData.Split(',');
                teacher = new TeacherViewModel()
                {
                    TeacherId = Convert.ToInt32(teacherData[0]),
                    FirstName = teacherData[1],
                    LastName = teacherData[2],
                };
            }

            return teacher;
        }
    }
}
