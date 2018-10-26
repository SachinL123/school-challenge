-- =============================================  
-- Author:  <Sachin Landage>  
-- Create date: 17-10-2018  
-- Description: delete student information  
-- =============================================  
CREATE PROCEDURE usp_DeleteStudent  
@Id int  
AS  
BEGIN  
 UPDATE Students SET   
 IsActive = 0  
 WHERE Id = @Id  
END  