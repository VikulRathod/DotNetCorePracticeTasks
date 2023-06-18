Working with Stored Procedures in EF Core

Description
You will be learning how to implement Entity Framework Core Code First approach 
using Stored procedures in your ASP.NET Core applications. 
By the end of this, you'll have the skills to create an application with 
Entity Framework Core. 
Learn how to connect to the database using entity framework core in ASP.NET Core.
Learn to perform CRUD operations using Stored procedures and also using the 
EF Core methods.

Objective
Upon completion of this, you will be able to:
•	Describe how to implement Entity framework core for your ASP.NET Core 
application.
•	Implement the Code first approach in EF Core using Migration
•	Implement Stored procedures to perform CRUD operations.

Requirements
Suppose you have two entities – Department and Employee, where the Department 
entity has mandatory properties DepartmentId, Name, and navigation property 
Employees; and the Employee entity has mandatory properties EmployeeId, Name, 
Address, DepartmentId, and navigation property Department.

Do complete the following tasks:
•	Create an Empty ASP.NET Core MVC application.
•	Create a Data Access Layer (DAL) Project.
•	Create Employee and Department Pages.
•	Create Employee and Department Entities in the DAL project.
•	Define database mapping with the help of the EF code first approach.
•	Create and implement the stored procedures for data mapping.
•	Create CRUD operations for Department using LINQ. Please add confirm box 
before deleting a record.
•	Create CRUD operations for Employees using Stored Procedures. 
Here, you have to add and edit employees based on department. 
Please add confirm box before deleting a record.
•	Show Error messages while performing CRUD operations.
