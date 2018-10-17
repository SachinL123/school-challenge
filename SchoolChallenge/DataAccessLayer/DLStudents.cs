using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccessLayer;
using SchoolChallenge.Models;

namespace Schoolchallenge.DataAccess
{
    public class DLStudents : DataAccessContext
    {
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Execute("usp_AddStudent", student, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Student> GetStudents(int studentId = 0)
        {
            IList<Student> listStudents;      

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {                
                listStudents = con.Query<Student>("usp_GetStudents").ToList();
            }

            return listStudents;
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Execute("usp_UpdateStudent", student, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                con.Execute("usp_DeleteStudent", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }        
    }
}
