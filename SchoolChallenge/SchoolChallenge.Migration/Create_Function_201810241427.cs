using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolChallenge.Migration
{
    [FluentMigrator.Migration(201810241427)]
    public class Create_Function_GetAssignedStudentsCount_201810241427 : FluentMigrator.Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("Create_Function_GetAssignedStudentsCount_201810241427.sql");
        }

        public override void Down()
        {            
            Execute.Sql("drop function dbo.GetAssignedStudentsCount");
        }
        
    }
}
