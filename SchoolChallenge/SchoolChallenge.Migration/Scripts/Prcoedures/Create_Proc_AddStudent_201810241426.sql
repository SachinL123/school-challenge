-- =============================================      
-- Author:  <Sachin Landage>      
-- Create date: 17-10-2018      
-- Description: update student information      
-- =============================================      
CREATE PROCEDURE usp_AddStudent      
 @studentId int     
,@Number varchar(500)      
,@FirstName nvarchar(500)      
,@LastName nvarchar(500)      
,@HasScholarship bit      
,@IsAssigend bit    
AS      
BEGIN      
 INSERT INTO Students (Number, FirstName, LastName, HasScholarship, IsActive)      
 VALUES (@Number, @FirstName, @LastName, @HasScholarship, 1)      
END 