-- Test
USE SybottDB
GO

CREATE TABLE [dbo].[Students](
    [Name] [char](5) NOT NULL PRIMARY KEY,
	[Phone] [varchar](35) NULL,
	[Gender] [char](2) NULL
)
GO

-- ALTER TABLE ZIPCodes ADD PRIMARY KEY (Name)
-- GO