CREATE DATABASE CVDatabase

USE CVDatabase

CREATE TABLE Skills(
Id int PRIMARY KEY NOT NULL,
Name varchar(100) NOT NULL
)
CREATE TABLE Users(
Id int PRIMARY KEY NOT NULL,
Username varchar(100) NOT NULL UNIQUE,
Email varchar(100) NOT NULL UNIQUE,
Password varchar(500) NOT NULL,
FirstName nvarchar(100) NOT NULL,
LastName nvarchar(100) NOT NULL,
Salt varbinary(32)
)
CREATE TABLE Resumes(
Id int PRIMARY KEY NOT NULL,
Title nvarchar(100) NOT NULL,
CreationDate datetime2 NOT NULL,
LastModified datetime2 NOT NULL,
UserId int NOT NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id)
)

CREATE TABLE ResumesSkills(
ResumeId int NOT NULL,
SkillId int NOT NULL,
PRIMARY KEY (ResumeId, SkillId),
FOREIGN KEY (ResumeId) REFERENCES Resumes(Id),
FOREIGN KEY (SkillId) REFERENCES Skills(Id)
)

CREATE TABLE [Certificates](
Id int PRIMARY KEY NOT NULL,
Name nvarchar(150) NOT NULL,
Organization nvarchar(100) NOT NULL,
IssueDate date NOT NULL,
ExpirationDate date,
ResumeId int NOT NULL,
FOREIGN KEY (ResumeId) REFERENCES Resumes(Id),
)

CREATE TABLE Educations(
Id int PRIMARY KEY NOT NULL,
Institute nvarchar(100) NOT NULL,
Degree nvarchar(100) NOT NULL,
FieldOfStudy nvarchar(100) NOT NULL,
StartDate date NOT NULL,
EndDate date NOT NULL,
ResumeId int NOT NULL,
FOREIGN KEY (ResumeId) REFERENCES Resumes(Id),
)

CREATE TABLE PersonalInfos(
Id int PRIMARY KEY NOT NULL,
Address nvarchar(200) NOT NULL,
Phone varchar(15) NOT NULL,
UserId int NOT NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id)
)

CREATE TABLE WorkExperiences(
Id int PRIMARY KEY NOT NULL,
Company nvarchar(100) NOT NULL,
Position nvarchar(100) NOT NULL,
StartDate date NOT NULL,
EndDate date NOT NULL,
Description nvarchar(500) NOT NULL,
ResumeId int NOT NULL,
FOREIGN KEY (ResumeId) REFERENCES Resumes(Id),
)

CREATE TABLE Templates(
Id int PRIMARY KEY NOT NULL,
Name varchar(50) NOT NULL,
Path nvarchar(200) NOT NULL
)