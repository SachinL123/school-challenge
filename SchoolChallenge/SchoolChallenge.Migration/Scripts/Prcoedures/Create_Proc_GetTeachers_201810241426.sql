-- =============================================        
-- Author:  <Sachin Landage>        
-- Create date: 23-10-2018        
-- Description: Get teacher information        
-- =============================================        
CREATE PROCEDURE usp_GetTeachers        
@teacherId int      
AS        
BEGIN        
    
 SELECT         
  Id As TeacherId        
 ,FirstName        
 ,LastName        
 ,IsActive      
 ,dbo.GetAssignedStudentsCount(Id) AS NumberOfStudents         
 ,CreatedBy        
 ,CreatedDate        
 ,ModifiedBy        
 ,ModifiedDate      
 FROM Teachers        
 WHERE IsActive = 1        
 AND (Id= @teacherId OR @teacherId = 0)        
END       
      
