CREATE TABLE [dbo].[BaseParty]
(
	[Id] INT IDENTITY(1,1) NOT NULL , 
    [Name] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [Discriminator] NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
