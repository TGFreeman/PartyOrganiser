CREATE TABLE [dbo].[Attendance]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PersonId] INT NOT NULL, 
    [EventId] INT NOT NULL, 
    [DrinkId] INT NULL, 
    [Discriminator] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Attendance_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
    CONSTRAINT [FK_Attendance_Event] FOREIGN KEY ([EventId]) REFERENCES [BaseParty]([Id]), 
    CONSTRAINT [FK_Attendance_Drink] FOREIGN KEY ([DrinkId]) REFERENCES [Drink]([Id])
)
