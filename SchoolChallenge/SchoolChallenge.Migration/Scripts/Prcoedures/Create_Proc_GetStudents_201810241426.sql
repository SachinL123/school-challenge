-- =============================================    
-- Author:  <Sachin Landage>    
-- Create date: 17-10-2018    
-- Description: Get student information    
-- =============================================    
CREATE PROCEDURE usp_GetStudents    
@studentId int  
AS    
BEGIN    
 SELECT     
  Id    
 ,Number    
 ,FirstName    
 ,LastName    
 ,HasScholarship    
 ,IsActive    
 ,CreatedBy    
 ,CreatedDate    
 ,ModifiedBy    
 ,ModifiedDate    
 FROM Students    
 WHERE IsActive = 1    
 AND (Id= @studentId OR @studentId = 0)    
END      
