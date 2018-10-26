-- =============================================      
-- Author:  <Sachin Landage>      
-- Create date: 23-10-2018      
-- Description: Get student information      
-- =============================================      
CREATE PROCEDURE usp_GetAssignedStudents      
@teacherId int    
AS      
BEGIN      
 SELECT       
  Id AS StudentId      
 ,Number   
 ,FirstName      
 ,LastName      
 ,HasScholarship    
 ,1 As IsAssigend    
 FROM TeacherStudentMapping tsm     
 INNER JOIN Students s ON tsm.StudentId = s.Id AND s.IsActive = 1  
 WHERE tsm.IsActive = 1      
 AND (TeacherId= @teacherId)     
 UNION  
  SELECT     
 Id AS StudentId      
 ,Number    
 ,FirstName    
 ,LastName    
 ,HasScholarship       
 ,0 As IsAssigend    
 FROM Students    
 WHERE IsActive = 1 AND Id NOT IN  
 (SELECT       
  Id       
 FROM TeacherStudentMapping tsm     
 INNER JOIN Students s ON tsm.StudentId = s.Id AND s.IsActive = 1  
 WHERE tsm.IsActive = 1      
 AND (TeacherId= @teacherId) )    
END          
