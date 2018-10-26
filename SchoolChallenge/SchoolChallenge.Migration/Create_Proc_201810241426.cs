using System;

namespace SchoolChallenge.Migration
{
    [FluentMigrator.Migration(201810241426)]
    public class Create_Proc_201810241426 : FluentMigrator.Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Create_Proc_AddStudent_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_AddTeachers_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_GetAssignedStudents_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_GetStudents_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_GetTeachers_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_UpdateAssignedStudents_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_UpdateStudent_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_UpdateTeacher_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_DeleteStudent_201810241426.sql");
            Execute.EmbeddedScript("Create_Proc_DeleteTeacher_201810241426.sql");
        }

        public override void Down()
        {
            Execute.Sql("drop procedure usp_AddStudent");
            Execute.Sql("drop procedure usp_AddTeacher");
            Execute.Sql("drop procedure usp_DeleteStudent");
            Execute.Sql("drop procedure usp_DeleteTeacher");
            Execute.Sql("drop procedure usp_GetAssignedStudents");
            Execute.Sql("drop procedure usp_GetStudents");
            Execute.Sql("drop procedure usp_GetTeachers");
            Execute.Sql("drop procedure usp_UpdateAssignedStudents");
            Execute.Sql("drop procedure usp_UpdateStudent");
            Execute.Sql("drop procedure usp_UpdateTeacher");
        }
    }
}
