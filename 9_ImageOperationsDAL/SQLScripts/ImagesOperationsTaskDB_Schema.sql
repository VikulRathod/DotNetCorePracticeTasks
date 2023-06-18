create database ImageOperationsTaskDB
go
use ImageOperationsTaskDB
go
SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
CREATE TABLE [dbo].[Employees](  
[EmployeeId] [int] IDENTITY(1,1) NOT NULL,  
[Name] [varchar](250) NOT NULL,  
[Address] [varchar](250) NOT NULL,  
[ImagePath] [varchar](250) NOT NULL,  
CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
([EmployeeId] ASC) WITH 
(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) 
ON [PRIMARY] 
GO 