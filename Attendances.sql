CREATE TABLE [dbo].[Attendances]
(
		[Id] INT IDENTITY(1,1) NOT NULL , 
    [PersonId] INT NOT NULL, 
    [PartyId] INT NOT NULL, 
    [DrinkId] INT NULL, 
    [Discriminator] NVARCHAR(MAX) NOT NULL, 
        PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attendances_Person] FOREIGN KEY ([PersonId]) REFERENCES [People]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Attendances_Party] FOREIGN KEY ([PartyId]) REFERENCES [BaseParty]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Attendances_Drink] FOREIGN KEY ([DrinkId]) REFERENCES [Drinks]([Id]) ON DELETE CASCADE
)
