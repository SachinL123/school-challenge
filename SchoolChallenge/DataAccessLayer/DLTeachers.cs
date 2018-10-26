using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccessLayer.Interfaces;
using Schoolchallenge.Model.ViewModels;
using SchoolChallenge.Models;

namespace DataAccessLayer
{
    public class DLTeachers : DataAccessContext, IDALTeacher
    {
        public IEnumerable<Teacher> GetTeachers(int teacherId = 0)
        {
            IList<Teacher> listTeachers;

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@teacherId", teacherId);
                listTeachers = con.Query<Teacher>("usp_GetTeachers", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return listTeachers;
        }

        public IEnumerable<TeacherViewModel> GetTeacherDetails(int teacherId = 0)
        {
            IList<TeacherViewModel> listTeachers;

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@teacherId", teacherId);
                listTeachers = con.Query<TeacherViewModel>("usp_GetTeachers", param, commandType: CommandType.StoredProcedure).ToList();
            }

            return listTeachers;
        }
        public void AddTeacher(TeacherViewModel teacherViewModel, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                rowsAffected = con.Execute("usp_AddTeacher", teacherViewModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateTeacher(TeacherViewModel teacherViewModel, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                rowsAffected = con.Execute("usp_UpdateTeacher", teacherViewModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTeacher(int id, out int rowsAffected)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                rowsAffected = con.Execute("usp_DeleteTeacher", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
