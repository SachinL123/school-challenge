-- =============================================        
-- Author:  <Sachin Landage>        
-- Create date: 17-10-2018        
-- Description: update student information        
-- =============================================        
CREATE PROCEDURE usp_UpdateStudent        
@StudentId int        
,@Number varchar(500)        
,@FirstName nvarchar(500)        
,@LastName nvarchar(500)        
,@HasScholarship bit        
 ,@IsAssigend bit      
AS        
BEGIN        
 UPDATE Students SET         
 Number = @Number        
 ,FirstName = @FirstName        
 ,LastName = @LastName        
 ,HasScholarship = @HasScholarship        
 where Number = @Number        
END     
