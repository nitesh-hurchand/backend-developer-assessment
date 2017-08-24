CREATE TABLE [dbo].[Artist]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [CountryCodeIso2] NCHAR(2) NOT NULL, 
    [Aliases] NVARCHAR(255) NULL,
	CONSTRAINT pk_artist PRIMARY KEY ([Id]),
	CONSTRAINT uk_artist_uid UNIQUE ([Uid])

)
