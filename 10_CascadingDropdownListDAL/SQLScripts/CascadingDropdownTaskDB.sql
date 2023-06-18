create database CascadingDropdownTaskDB
go
use CascadingDropdownTaskDB
go
CREATE TABLE dbo.Countries 
( 
CountryId int IDENTITY(1,1) NOT NULL, 
Name varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
CONSTRAINT PK_Countries PRIMARY KEY (CountryId) 
); 
go
INSERT INTO dbo.Countries (Name) VALUES('India'); 
INSERT INTO dbo.Countries (Name) VALUES('Srilanka'); 
INSERT INTO dbo.Countries (Name) VALUES('Pakistan'); 
go
CREATE TABLE dbo.Cities 
( 
CityId int IDENTITY(1,1) NOT NULL, 
Name varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
CountryId int NOT NULL, 
CONSTRAINT PK_Cities PRIMARY KEY (CityId), 
CONSTRAINT FK__City__CountryId FOREIGN KEY (CountryId) 
REFERENCES dbo.Countries(CountryId) 
); 
go
INSERT INTO Cities (Name, CountryId) VALUES('New Delhi', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Mumbai', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Chennai', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Calcutta', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Lahore', 3); 
INSERT INTO Cities (Name, CountryId) VALUES('Colombo', 2); 
INSERT INTO Cities (Name, CountryId) VALUES('Kandy', 2); 
INSERT INTO Cities (Name, CountryId) VALUES('Jaipur', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Agra', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Indore', 1); 
INSERT INTO Cities (Name, CountryId) VALUES('Pune', 1);