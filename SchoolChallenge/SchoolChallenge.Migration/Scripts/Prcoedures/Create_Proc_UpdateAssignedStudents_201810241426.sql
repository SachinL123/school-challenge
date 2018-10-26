-- =============================================      
-- Author:  <Sachin Landage>      
-- Create date: 23-10-2018      
-- Description: update assignment studenet  
-- =============================================      
CREATE PROCEDURE usp_UpdateAssignedStudents      
@teacherId int,  
@studentIdList varchar(max)   
   
AS      
BEGIN       
DELETE FROM TeacherStudentMapping WHERE TeacherId = @teacherId  
 DECLARE @id varchar(200)  
 DECLARE @pos INT  
  
  WHILE CHARINDEX(',', @studentIdList) > 0  
  BEGIN  
   SELECT @pos  = CHARINDEX(',', @studentIdList)    
   SELECT @id = SUBSTRING(@studentIdList, 1, @pos-1)  
  
   INSERT INTO TeacherStudentMapping (TeacherId, StudentId, IsActive)  
   VALUES (@teacherId, @id, 1)  
  
   SELECT @studentIdList = SUBSTRING(@studentIdList, @pos+1, LEN(@studentIdList)-@pos)  
  END  
  
 INSERT INTO TeacherStudentMapping (TeacherId, StudentId, IsActive)  
  VALUES (@teacherId, @studentIdList, 1)  
   
  
END      
