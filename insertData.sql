-- USE SybottDB;
-- GO
-- BULK INSERT SybottDB.dbo.ZIPCodes FROM '/usr/data/zipcode.csv'
--    WITH (
--       FIELDTERMINATOR = ',',
--       ROWTERMINATOR = '\n',
--       FORMAT = 'CSV'
-- );
-- GO


USE SybottDB;
GO

INSERT INTO [dbo].[Students]
VALUES 
('Alice', '12345', 'F'),
('Mike', '54321', 'M'),
('Alex', '32145', 'M');
