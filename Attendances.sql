CREATE TABLE [dbo].[Attendances]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PersonId] INT NOT NULL, 
    [EventId] INT NOT NULL, 
    [DrinkId] INT NULL, 
    CONSTRAINT [FK_Attendance_Person] FOREIGN KEY ([PersonId]) REFERENCES [People]([Id]), 
    CONSTRAINT [FK_Attendance_Event] FOREIGN KEY ([EventId]) REFERENCES [Events]([Id]), 
    CONSTRAINT [FK_Attendance_Drink] FOREIGN KEY ([DrinkId]) REFERENCES [Drinks]([Id])
)
