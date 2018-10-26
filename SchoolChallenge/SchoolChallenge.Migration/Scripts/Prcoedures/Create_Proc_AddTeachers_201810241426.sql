-- =============================================    
-- Author:  <Sachin Landage>    
-- Create date: 23-10-2018    
-- Description: add teacher information    
-- =============================================    
CREATE PROCEDURE usp_AddTeacher    
@TeacherId int    
,@FirstName nvarchar(500)    
,@LastName nvarchar(500)    
,@NumberOfStudents bit    
    
AS    
BEGIN    
 INSERT INTO Teachers(FirstName, LastName, IsActive)    
 VALUES (@FirstName, @LastName, 1)    
END 