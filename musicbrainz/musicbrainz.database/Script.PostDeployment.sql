/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Metallica','65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab','US','Metalica,메탈리카');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Lady Gaga','650e7db6-b795-4eb5-a702-5ea2fc46c848','US','Lady Ga Ga,Stefani Joanne Angelina Germanotta');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Mumford & Sons','c44e9c22-ef82-4a77-9bcd-af6c958446d6','GB',null);
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Mott the Hoople','435f1441-0f43-479d-92db-a506449a686b','GB','Mott The Hoppie,Mott The Hopple');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Megadeth','a9044915-8be3-4c7e-b11f-9e2d2ea0a91e','US','Megadeath');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('John Coltrane','b625448e-bf4a-41c3-a421-72ad46cdb831','US','John Coltraine,John William Coltrane');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Mogwai','d700b3f5-45af-4d02-95ed-57d301bda93e','GB','Mogwa');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('John Mayer','144ef525-85e9-40c3-8335-02c32d0861f3','US',null);
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Johnny Cash','18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f','US','Johhny Cash,Jonny Cash');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Jack Johnson','6456a893-c1e9-4e3d-86f7-0008b0a3ac8a','US','Jack Hody Johnson');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('John Frusciante','f1571db1-c672-4a54-a2cf-aaa329f26f0b','US','John Anthony Frusciante');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Elton John','b83bc61f-8451-4a5d-8b8e-7e9ed295e822','GB','E. John, Elthon John,Elton Jphn,John Elton, Reginald Kenneth Dwight');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Rancid','24f8d8a5-269b-475c-a1cb-792990b0b2ee','US','ランシド');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Transplants','29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699','US','The Transplants');
INSERT INTO [dbo].[Artist] ([Name], [Uid], [CountryCodeIso2], [Aliases])
VALUES ('Operation Ivy','931e1d1f-6b2f-4ff8-9f70-aa537210cd46','US','Op Ivy');
