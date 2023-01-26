--CREATE DATABASE [Survea]

CREATE TABLE [Survea].[dbo].[User]
(
	UserId INT PRIMARY KEY,
	Name NVARCHAR(50),
	DateOfBirth DATE,
	Email NVARCHAR(50),
	AccountMode TINYINT
)

CREATE TABLE [Survea].[dbo].[Test]
(
	TestId INT PRIMARY KEY,
	Name NVARCHAR(100),
	AgeRestriction INT,
	QuestionCount INT,
	Description NVARCHAR(250),
	OwnerId INT
)

CREATE TABLE [Survea].[dbo].[Tag]
(
	TagId INT PRIMARY KEY,
	Tag NVARCHAR(50)
)

CREATE TABLE [Survea].[dbo].[UserTag]
(
	Id INT PRIMARY KEY,
	TagId INT,
	UserId INT
)

CREATE TABLE [Survea].[dbo].[TestTag]
(
	Id INT PRIMARY KEY,
	TagId INT,
	UserId INT
)

CREATE TABLE [Survea].[dbo].[DetailedTestInfo]
(
	TestId INT PRIMARY KEY,
	AverageTestCompletionTime INT,
	AttemptCount INT
)

CREATE TABLE [Survea].[dbo].[ReferalCode]
(
	Code NVARCHAR(30) PRIMARY KEY,
	OwnerId INT
)

CREATE TABLE [Survea].[dbo].[PassedTest]
(
	TestPassingId INT PRIMARY KEY,
	UserId INT,
	TestId INT,
	FinishedAt DATETIME
)

CREATE TABLE [Survea].[dbo].[Answer]
(
	AnswerId INT PRIMARY KEY,
	TestPassingId INT,
	QuestionNumber INT,
	QuestionType TINYINT,
	Answer NVARCHAR(250)
)

CREATE TABLE [Survea].[dbo].[DetailedUserInfo]
(
	UserId INT PRIMARY KEY,
	PassedTestCount INT,
	CreatedTestCount INT,
	Gender TINYINT,
	RegistrationDate DATE
)
