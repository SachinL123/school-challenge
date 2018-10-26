-- =============================================  
-- Author:  <Sachin Landage>  
-- Create date: <23-10-208>  
-- Description: <function to get studenet count>  
-- =============================================  
CREATE FUNCTION GetAssignedStudentsCount  
(  
 @teacherId int  
)  
RETURNS int  
AS  
BEGIN  
 DECLARE @studentCount int  
  
 SELECT @studentCount = count(*) from TeacherStudentMapping tsm  
 INNER JOIN Students s on tsm.StudentId = s.Id AND s.IsActive =1  
 where TeacherId = @teacherId AND tsm.IsActive =1   
  
 RETURN @studentCount  
  
END  