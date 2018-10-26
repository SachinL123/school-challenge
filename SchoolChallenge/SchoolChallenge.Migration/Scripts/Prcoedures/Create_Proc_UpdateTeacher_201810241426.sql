-- =============================================    
-- Author:  <Sachin Landage>    
-- Create date: 23-10-2018    
-- Description: update teacher information    
-- =============================================    
CREATE PROCEDURE usp_UpdateTeacher    
@TeacherId int    
,@FirstName nvarchar(500)    
,@LastName nvarchar(500)    
,@NumberOfStudents int  
AS    
BEGIN    
 UPDATE Teachers SET     
 FirstName = @FirstName    
 ,LastName = @LastName    
 where Id= @TeacherId    
END 