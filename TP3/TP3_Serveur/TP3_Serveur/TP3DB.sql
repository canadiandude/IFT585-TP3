-- Pour créer la BD, dans Server Explorer:
-- right-click sur Data Connections
-- Add Connections...
-- Data source: Microsoft SQL Server Database File (SqlClient)
-- Database file name: (Votre path GitHub)\IFT585-TP3\TP3\TP3_Serveur\TP3_Serveur\TP3DB
-- Right-click sur TP3DB.mdf
-- New Query
-- Copy-paste le script
-- Execute
CREATE TABLE [dbo].[Users] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Chatrooms] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (50)   NOT NULL,
    [Description] VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Messages] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Message]    VARCHAR (1000) NOT NULL,
    [UserId]     INT            NOT NULL,
    [ChatroomId] INT            NOT NULL,
    [Timestamp]  DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([ChatroomId]) REFERENCES [dbo].[Chatrooms] ([Id])
);
CREATE TABLE [dbo].[UsersChatrooms] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [UserId]     INT NOT NULL,
    [ChatroomId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([ChatroomId]) REFERENCES [dbo].[Chatrooms] ([Id])
);
CREATE TABLE [dbo].[Likes] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [UserId]    INT NOT NULL,
    [MessageId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Messages] ([Id])
);