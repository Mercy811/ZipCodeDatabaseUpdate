USE SybottDB;
GO
BULK INSERT SybottDB.dbo.ZIPCodes FROM '/usr/data/zip-codes-database-STANDARD-aug.csv'
   WITH (
      FIELDTERMINATOR = ',',
      ROWTERMINATOR = '0x0a',
      FIRSTROW = 2
);
GO