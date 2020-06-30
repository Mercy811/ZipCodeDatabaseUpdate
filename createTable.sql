/****** Object:  Table [dbo].[ZIPCodes]    Script Date: 6/28/2020 7:20:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- CREATE  DATABASE SybottDB
-- GO

USE SybottDB

CREATE TABLE [dbo].[ZIPCodes](
	[ZipCode] [char](5) NOT NULL,
	[City] [varchar](35) NULL,
	[State] [char](2) NULL,
	[County] [varchar](45) NULL,
	[AreaCode] [varchar](55) NULL,
	[CityType] [char](1) NULL,
	[CityAliasAbbreviation] [varchar](13) NULL,
	[CityAliasName] [varchar](35) NULL,
	[Latitude] [decimal](12, 6) NULL,
	[Longitude] [decimal](12, 6) NULL,
	[TimeZone] [char](2) NULL,
	[Elevation] [int] NULL,
	[CountyFIPS] [char](5) NULL,
	[DayLightSaving] [char](1) NULL,
	[PreferredLastLineKey] [varchar](10) NULL,
	[ClassificationCode] [char](1) NULL,
	[MultiCounty] [char](1) NULL,
	[StateFIPS] [char](2) NULL,
	[CityStateKey] [char](6) NULL,
	[CityAliasCode] [varchar](5) NULL,
	[PrimaryRecord] [char](1) NULL,
	[CityMixedCase] [varchar](35) NULL,
	[CityAliasMixedCase] [varchar](35) NULL,
	[StateANSI] [varchar](2) NULL,
	[CountyANSI] [varchar](3) NULL,
	[FacilityCode] [varchar](1) NULL,
	[CityDeliveryIndicator] [varchar](1) NULL,
	[CarrierRouteRateSortation] [varchar](1) NULL,
	[FinanceNumber] [varchar](6) NULL,
	[UniqueZIPName] [varchar](1) NULL,
	[CountyMixedCase] [varchar](45) NULL
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'00000-99999 Five digit numeric ZIP Code of the area.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'ZipCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the city as designated by the USPS.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'City'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'2 letter state name abbreviation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'State'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of County or Parish this ZIP Code resides in.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'County'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The telephone area codes available in this ZIP Code.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'AreaCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the type of locale such as Post Office, Stations, or Branch.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'13 Character abbreviation for the city alias name.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityAliasAbbreviation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alias name of the city if it exists.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityAliasName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geographic coordinate as a point measured in degrees north or south of the equator.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'Latitude'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geographic coordinate as a point measured in degrees east or west of the Greenwich Meridian.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'Longitude'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hours past Greenwich Time Zone this ZIP Code belongs to.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'TimeZone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The average elevation of the county.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'Elevation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIPS code for the County/Parish this ZIP Code resides in.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CountyFIPS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag indicating whether this ZIP Code observes daylight savings.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'DayLightSaving'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Links this record with other products ZIP-Codes.com offers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'PreferredLastLineKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The classification type of this ZIP Code.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'ClassificationCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag indicating whether this ZIP Code crosses county lines.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'MultiCounty'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FIPS code for the State this ZIP Code resides in.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'StateFIPS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Links this record with other products ZIP-Codes.com offers such as the ZIP+4.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityStateKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code indicating the type of the city alias name for this record. Record can be Abbreviations, Universities, Government, and more.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityAliasCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Character ‘P’ denoting if this row is a Primary Record or not. Absence of character denotes a non-primary record.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'PrimaryRecord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city name in mixed case (i.e. Not in all uppercase letters).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityMixedCase'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The city alias name in mixed case (i.e. Not in all uppercase letters).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes', @level2type=N'COLUMN',@level2name=N'CityAliasMixedCase'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'U.S. Zip Code Database Standard (from www.zip-codes.com)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ZIPCodes'
GO

