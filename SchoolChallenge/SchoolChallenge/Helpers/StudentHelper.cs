using System;
using System.Collections.Generic;
using System.Linq;
using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Models;

namespace SchoolChallenge
{
    public class StudentHelper
    {
        public static StudentViewModel ToViewModelFromCSV(string csvData)
        {
            StudentViewModel studentViewModel = null;
            if (!string.IsNullOrEmpty(csvData) && csvData.Contains(','))
            {
                string[] studentData = csvData.Split(',');
                studentViewModel = new StudentViewModel()
                {
                    StudentId = Convert.ToInt32(studentData[0]),
                    Number = studentData[1],
                    FirstName = studentData[2],
                    LastName = studentData[3],
                    HasScholarship = studentData[4].Equals("Yes", StringComparison.OrdinalIgnoreCase) ? true : false
                };
            }

            return studentViewModel;
        }
    }
}
