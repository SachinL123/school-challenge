-- =============================================  
-- Author:  <Sachin Landage>  
-- Create date: 23-10-2018  
-- Description: delete teacher information  
-- =============================================  
CREATE PROCEDURE usp_DeleteTeacher  
@Id int  
AS  
BEGIN  
 UPDATE Teachers SET   
 IsActive = 0  
 WHERE Id = @Id  
END  