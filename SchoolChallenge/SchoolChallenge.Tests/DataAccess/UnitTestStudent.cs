using DataAccessLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schoolchallenge.DataAccess;
using SchoolChallenge.Controllers;
using SchoolChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Schoolchallenge.Model.ViewModels;
using Moq;
using SchoolChallenge.Common.Helpers;

namespace SchoolChallenge.Tests.DataAccess
{
    [TestClass]
    public class UnitTestStudent
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckExceptionGetAssignedStudents()
        {
            //// mock object
            var iDalMock = new Mock<IDALStudent>();

            //// actual method call
            StudentManager studentManager = new StudentManager(iDalMock.Object);
            var result = studentManager.GetAssignedStudents(0);
        }

        [TestMethod]
        public void CheckGetAssignedStudentsIsNull()
        {
            //// Return data
            IEnumerable<StudentViewModel> students = LoadStudentViewModelList();      

            //// mock object
            var iDalMock = new Mock<IDALStudent>();            
            iDalMock.Setup(m => m.GetAssignedStudents(1)).Returns(students);

            //// actual method call
            StudentManager studentManager = new StudentManager(iDalMock.Object);
            var result = studentManager.GetAssignedStudents(1);
            Assert.IsNotNull(result);            
        }
        
        [TestMethod]
        public void CheckGetStudentsForEmptyList()
        {
            //// Return data
            IEnumerable<Student> students = GetEmptyStudentList();

            //// mock object
            var iDalMock = new Mock<IDALStudent>();
            iDalMock.Setup(m => m.GetStudents(1)).Returns(students);

            //// actual method call
            StudentManager studentManager = new StudentManager(iDalMock.Object);
            var result = studentManager.GetStudents(9999);
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void CheckToViewModel()
        //{
        //    //// Return data
        //    IEnumerable<Student> students = LoadStudentList();
            
        //    //// Expected data
        //    var expected = LoadStudentViewModelList();

        //    //// actual method call
        //    var result = StudentHelper.ToViewModel(students);

        //    Assert.AreEqual(expected.Count(), result.Count());
        //}

        [TestMethod]
        public void CheckIsStudentUpdate()
        {
            //// Initialize data
            IEnumerable<StudentViewModel> existingStudents = LoadStudentViewModelList();
            StudentViewModel studentToCheck = existingStudents.First();

            //// mock object
            var iDalMock = new Mock<IDALStudent>();

            //// call to method
            StudentManager studentManager = new StudentManager(iDalMock.Object);
            bool result = studentManager.IsStudentUpdate(existingStudents, studentToCheck);

            ////Result
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void CheckIsStudentInsert()
        {
            //// Initialize data
            IEnumerable<StudentViewModel> existingStudents = LoadStudentViewModelList();
            StudentViewModel studentToCheck = new StudentViewModel()
            {
                Number = "CR-155",
                FirstName = "Greg",
                LastName = "chappel",
                HasScholarship = false
            };

            //// mock object
            var iDalMock = new Mock<IDALStudent>();

            //// call to method
            StudentManager studentManager = new StudentManager(iDalMock.Object);
            bool result = studentManager.IsStudentUpdate(existingStudents, studentToCheck);

            ////Result
            Assert.AreEqual(false, result);

        }

        // methods to load test data
        #region Methods to Load test data
        private IEnumerable<StudentViewModel> LoadStudentViewModelList()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            students.Add(new StudentViewModel() { StudentId = 1, Number = "CR-100", FirstName = "Sam", LastName = "Karnan", HasScholarship = true });
            students.Add(new StudentViewModel() { StudentId = 2, Number = "CR-101", FirstName = "ricky", LastName = "ponting", HasScholarship = true });
            students.Add(new StudentViewModel() { StudentId = 3, Number = "CR-102", FirstName = "Bret", LastName = "Lee", HasScholarship = true });
            students.Add(new StudentViewModel() { StudentId = 4, Number = "CR-103", FirstName = "Andrew", LastName = "Symonds", HasScholarship = true });
            students.Add(new StudentViewModel() { StudentId = 5, Number = "CR-104", FirstName = "Brian", LastName = "Lara", HasScholarship = true });

            return students;
        }

        private IEnumerable<Student> LoadStudentList()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student() { Id = 1, Number = "CR-100", FirstName = "Sam", LastName = "Karnan", HasScholarship = true });
            students.Add(new Student() { Id = 2, Number = "CR-101", FirstName = "ricky", LastName = "ponting", HasScholarship = true });
            students.Add(new Student() { Id = 3, Number = "CR-102", FirstName = "Bret", LastName = "Lee", HasScholarship = true });
            students.Add(new Student() { Id = 4, Number = "CR-103", FirstName = "Andrew", LastName = "Symonds", HasScholarship = true });
            students.Add(new Student() { Id = 5, Number = "CR-104", FirstName = "Brian", LastName = "Lara", HasScholarship = true });

            return students;
        }

        private IEnumerable<Student> GetEmptyStudentList()
        {
            List<Student> students = new List<Student>();
            return students;
        } 
        #endregion
    }
}
