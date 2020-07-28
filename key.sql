-- USE SybottDB
-- GO

-- ALTER TABLE ZIPCodes ADD PRIMARY KEY (ZipCode,City,County,CityAliasAbbreviation,CityAliasName,PreferredLastLineKey,CityStateKey)

-- ALTER TABLE ZIPCodes DROP CONSTRAINT PK__ZIPCodes__2CC2CDB95A353C73
-- GO

DROP TABLE ZIPCodes
GO