-- Pour créer la BD, dans Server Explorer:
-- right-click sur Data Connections
-- Add Connections...
-- Data source: Microsoft SQL Server Database File (SqlClient)
-- Database file name: (Votre path GitHub)\IFT585-TP3\TP3\TP3_Serveur\TP3_Serveur\TP3DB
-- Right-click sur TP3DB.mdf
-- New Query
-- Copy-paste le script
-- Execute
CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL
);
CREATE TABLE [dbo].[Messages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Message] VARCHAR(1000) NOT NULL, 
    [UserId] INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
);
CREATE TABLE [dbo].[Chatrooms]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(1000) NOT NULL
);
CREATE TABLE [dbo].[UsersChatrooms]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserId] INT NOT NULL FOREIGN KEY REFERENCES Users(Id), 
    [ChatroomId] INT NOT NULL FOREIGN KEY REFERENCES Chatrooms(Id)
);
CREATE TABLE [dbo].[ChatroomsMessages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [ChatroomId] INT NOT NULL FOREIGN KEY REFERENCES Chatrooms(Id), 
    [MessageId] INT NOT NULL FOREIGN KEY REFERENCES Messages(Id)
);
CREATE TABLE [dbo].[Likes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [UserId] INT NOT NULL FOREIGN KEY REFERENCES Users(Id), 
    [MessageId] INT NOT NULL FOREIGN KEY REFERENCES Messages(Id)
);