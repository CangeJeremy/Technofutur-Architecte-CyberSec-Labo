﻿CREATE TABLE [AppUser].[WebsitesPwd]
(
	[Id] INT NOT NULL IDENTITY,
	[UserId] INT NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	[Website] NVARCHAR(MAX) NOT NULL,
	[Pwd] NVARCHAR(MAX) NOT NULL

	CONSTRAINT PK_WEBSITEPWD_ID PRIMARY KEY ([Id])
)
