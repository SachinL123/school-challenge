using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Models;

namespace Schoolchallenge.DataAccess
{
    public class DLStudents : DataAccessContext, IDALStudent
    {
        public void AddStudent(StudentViewModel studentViewModel, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                rowsAffected = con.Execute("usp_AddStudent", studentViewModel, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Student> GetStudents(int studentId = 0)
        {
            IList<Student> listStudents;      

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@studentId", studentId);
                listStudents = con.Query<Student>("usp_GetStudents", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return listStudents;
        }

        public IEnumerable<StudentViewModel> GetAssignedStudents(int teacherId)
        {
            IList<StudentViewModel> listStudents;

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@teacherId", teacherId);
                listStudents = con.Query<StudentViewModel>("usp_GetAssignedStudents", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return listStudents.OrderByDescending( x=> x.IsAssigend);
        }

        public void UpdateStudent(StudentViewModel studentViewModel, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                rowsAffected = con.Execute("usp_UpdateStudent", studentViewModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteStudent(int id, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                rowsAffected = con.Execute("usp_DeleteStudent", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateStudentAssignnment(int teacherId, string studentId, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@teacherId", teacherId);
                param.Add("@studentIdList", studentId);
                rowsAffected = con.Execute("usp_UpdateAssignedStudents", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
