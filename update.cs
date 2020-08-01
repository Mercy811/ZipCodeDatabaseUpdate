using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using NLog;

using CsvHelper;

public static class DBUpdate
{
    private static string _directory = "download/";
    private static string _zipFileName = "2020-06-Update-STANDARD.zip";
    private static string _unzipFileDirectory = _directory+ "2020-06-Update-STANDARD/";
    private static string _tabFileName = "2020-06-Update-STANDARD.tab";


    private static Logger logger = LogManager.GetCurrentClassLogger();


    public static string DownloadFile(string url)
    {
        try
        {
            if(!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }
            WebClient client = new WebClient();
            client.DownloadFile(url, _directory + _zipFileName);
            return _zipFileName;
        }
        catch
        {
            return "";
        }
    }

    public static void ExtractFile()
    {
        ZipFile.ExtractToDirectory(_directory+_zipFileName,_unzipFileDirectory);
    }

    public static void AddDataRow(DataTable myTable, UpdateTable myUpdateTable)
    {
        DataRow myRow = myTable.NewRow();
        myRow["ZipCode"] = Int32.Parse(myUpdateTable.ZipCode).ToString();
        myRow["City"]= myUpdateTable.City;
        myRow["State"]= myUpdateTable.State;
        myRow["County"]= myUpdateTable.County;
        myRow["AreaCode"]= myUpdateTable.AreaCode;
        myRow["CityType"]= myUpdateTable.CityType;
        myRow["CityAliasAbbreviation"]= myUpdateTable.CityAliasAbbreviation;
        myRow["CityAliasName"]= myUpdateTable.CityAliasName;
        myRow["Latitude"]= myUpdateTable.Latitude;
        myRow["Longitude"]= myUpdateTable.Longitude;
        myRow["TimeZone"]= myUpdateTable.TimeZone;
        myRow["Elevation"]= myUpdateTable.Elevation;
        myRow["CountyFIPS"]= myUpdateTable.CountyFIPS;
        myRow["DayLightSaving"]= myUpdateTable.DayLightSaving;
        myRow["PreferredLastLineKey"]= myUpdateTable.PreferredLastLineKey;
        myRow["ClassificationCode"]= myUpdateTable.ClassificationCode;
        myRow["MultiCounty"]= myUpdateTable.MultiCounty;
        myRow["StateFIPS"]= myUpdateTable.StateFIPS;
        myRow["CityStateKey"]= myUpdateTable.CityStateKey;
        myRow["CityAliasCode"]= myUpdateTable.CityAliasCode;
        myRow["PrimaryRecord"]= myUpdateTable.PrimaryRecord;
        myRow["CityMixedCase"]= myUpdateTable.CityMixedCase;
        myRow["CityAliasMixedCase"]= myUpdateTable.CityMixedCase;
        myRow["StateANSI"]= myUpdateTable.StateANSI;
        myRow["CountyANSI"]= myUpdateTable.CountyANSI;
        myRow["FacilityCode"]= myUpdateTable.FacilityCode;
        myRow["UniqueZIPName"]= myUpdateTable.UniqueZIPName;
        myRow["CityDeliveryIndicator"]= myUpdateTable.CityDeliveryIndicator;
        myRow["CarrierRouteRateSortation"]= myUpdateTable.CarrierRouteRateSortation;
        myRow["FinanceNumber"]= myUpdateTable.FinanceNumber;
        myRow["CountyMixedCase"]= myUpdateTable.CountyMixedCase;
        myTable.Rows.Add(myRow);
        logger.Info("Add: ZipCode='"+myRow["ZipCode"]+"' AND City='"+myRow["City"]+"' AND County='"+myRow["County"]+"' AND CityAliasName='"+myRow["CityAliasName"]+"' AND PreferredLastLineKey='"+myRow["PreferredLastLineKey"]+"' AND CityStateKey='"+myRow["CityStateKey"]+"'");
    }

    public static void DeleteDataRow(DataTable myTable, UpdateTable myUpdateTable)
    {
        string selectCondition = "ZipCode='"+Int32.Parse(myUpdateTable.ZipCode).ToString()+"' AND City='"+myUpdateTable.City+"' AND County='"+myUpdateTable.County+"' AND CityAliasName='"+myUpdateTable.CityAliasName+"' AND PreferredLastLineKey='"+myUpdateTable.PreferredLastLineKey+"' AND CityStateKey='"+myUpdateTable.CityStateKey+"'";
        logger.Info("DELETE: "+selectCondition);
        DataRow[] myRows = myTable.Select(selectCondition);
        foreach (var row in myRows)
            row.Delete();
    }

    public class UpdateTable
    {
        public char Type { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string AreaCode { get; set; }
        public char CityType { get; set; }
        public string?  CityAliasAbbreviation { get; set; }
        public string  CityAliasName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string TimeZone { get; set; }
        public int Elevation { get; set; }
        public string  CountyFIPS { get; set; }
        public char DayLightSaving { get; set; }
        public string  PreferredLastLineKey { get; set; }
        public string? ClassificationCode  { get; set; }
        public string? MultiCounty  { get; set; }
        public string  StateFIPS { get; set; }
        public string  CityStateKey { get; set; }
        public string?  CityAliasCode { get; set; }
        public string? PrimaryRecord  { get; set; }
        public string  CityMixedCase { get; set; }
        public string  CityAliasMixedCase { get; set; }
        public string  StateANSI { get; set; }
        public string  CountyANSI { get; set; }
        public char FacilityCode  { get; set; }
        public string? UniqueZIPName  { get; set; }
        public char CityDeliveryIndicator  { get; set; }
        public char CarrierRouteRateSortation  { get; set; }
        public string  FinanceNumber { get; set; }
        public string  CountyMixedCase { get; set; }

    }

    public static void Main(string[] args)
    {
        try
        {
            // // download 
            // Console.WriteLine("==================1. DOWNLOAD==================");
            // string url = "https://files.zip-codes.com/_updates_a9dh38dyq6ek/2020-06-01_UPDATE_UZJFV7B6/2020-06-Update-STANDARD.zip";
            // string fileName = DBUpdate.DownloadFile(url);
            // if (!String.IsNullOrEmpty(fileName))
            // {
            //     Console.WriteLine("Successfully download '" + fileName+"'");
            // }
            // else
            // {
            //     Console.WriteLine("Failed to download '"+fileName+"'");
            //     // Application.Exit();
            // }    
            // Console.WriteLine("press Enter to continue.");
            // Console.ReadLine();

            // // unzip
            // Console.WriteLine("====================2.UNZIP===================");
            // ExtractFile();
            // Console.WriteLine("Successfully unzip the file");
            // Console.WriteLine("press Enter to continue.");
            // Console.ReadLine();


            
            //create connection
            Console.WriteLine("====================3.UNDATE===================");
            string connectString = "Data Source=127.0.0.1,1433;Initial Catalog=SybottDB;User ID=SA;Password=1Secure*Password1";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();

            //create data adapter
            SqlDataAdapter myDataAdapter = new SqlDataAdapter("select * from SybottDB.dbo.ZIPCodes", conn);
            SqlCommandBuilder mySqlCommandBuilder = new SqlCommandBuilder(myDataAdapter); 

            //create and fill dataset        
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet,"ZIPCodes");

            //get data table reference
            DataTable myTable = myDataSet.Tables["ZIPCodes"];
            logger.Info("The Total Number of Items BEFORE Updating: "+ myTable.Rows.Count);

            //read from [update].tab file
            var reader = new StreamReader(_unzipFileDirectory+"test.tab");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.Delimiter = "\t";
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
            var records = csv.GetRecords<UpdateTable>();
            foreach (var row in records)
            {
                if (row.Type == 'D')
                {
                    DeleteDataRow(myTable, row);

                }
                else
                {
                    AddDataRow(myTable, row);
                }
                
            }

            //sumbit local changes to SQL Server
            myDataAdapter.Update(myDataSet,"ZIPCodes");
            myTable.AcceptChanges();
            logger.Info("The Total Number of Items AFTER Updating: "+ myTable.Rows.Count);

            myDataSet.Dispose();
            myDataAdapter.Dispose();
            conn.Close();
            conn.Dispose();
            
        }
        catch (FileNotFoundException ex)
        {
            logger.Error(ex);
        }
        catch ( System.Data.SqlClient.SqlException ex)
        {
            logger.Error(ex);
        }
        // catch (Exception ex)
        // {
        //     // NLog: catch any exception and log it.
        //     logger.Error(ex, "Stopped program because of an exception");
        // }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }

    }
}