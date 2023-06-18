CREATE PROCEDURE usp_getemployees 
AS 
BEGIN  
SELECT EmployeeId, emp.Name, emp.Address, dept.DepartmentId, 
dept.Name AS DepartmentName   
FROM Employees AS emp  
join Departments AS dept   
ON emp.DepartmentId=dept.DepartmentId 
END  

GO 
CREATE PROCEDURE usp_getemployee @EmployeeId int 
AS 
BEGIN  
SELECT * FROM Employees WHERE EmployeeId=@EmployeeId 
END 

GO 
CREATE PROCEDURE usp_addemployee 
@Name varchar(50), @Address varchar(50), @DepartmentId int, 
@Status int out 
AS 
BEGIN  
BEGIN TRY     
INSERT Employees(Name, Address, DepartmentId) 
VALUES(@Name, @Address, @DepartmentId)  
SET @Status=1  
END 
TRY    
BEGIN CATCH    
SET @Status=0  
END CATCH 
END 