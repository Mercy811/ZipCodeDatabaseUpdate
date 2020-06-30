USE SybottDB;
GO
BULK INSERT SybottDB.dbo.ZIPCodes FROM '/usr/data/zipcode.csv'
   WITH (
      FIELDTERMINATOR = ',',
      ROWTERMINATOR = '\n',
      FORMAT = 'CSV'
);
GO
