using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolChallenge.Migration
{
    [FluentMigrator.Migration(201810241425)]
    public class Create_Table_201810241425 : FluentMigrator.Migration
    {        
        public override void Up()
        {
            Execute.EmbeddedScript("Create_Table_Students_201810241425.sql");
            Execute.EmbeddedScript("Create_Table_Teachers_201810241425.sql");
            Execute.EmbeddedScript("Create_Table_TeacherStudentMapping_201810241425.sql");
        }

        public override void Down()
        {
            Delete.Table("Students");
            Delete.Table("Teachers");
            Delete.Table("TeacherStudentMapping");
        }        
    }
}
