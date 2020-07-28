using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Globalization;

using CsvHelper;

using Updating;

public static class DBUpdate
{
    private static string _directory = "download/";
    private static string _zipFileName = "2020-06-Update-STANDARD.zip";
    private static string _unzipFileDirectory = _directory+ "2020-06-Update-STANDARD/";
    private static string _tabFileName = "2020-06-Update-STANDARD.tab";

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


    // public static void AddDataRow(DataTable myTable)
    // {
    //     DataRow myRow = myTable.NewRow();
    //     myRow["ZipCode"] = "9950";
    //     myRow["City"]="KETCHIKAN2";
    //     myRow["State"]="AK";
    //     myRow["County"]="KETCHIKAN GATEWAY";
    //     myRow["AreaCode"]="907";
    //     myRow["CityType"]='Z';
    //     myRow["CityAliasAbbreviation"]=null;
    //     myRow["CityAliasName"]="EDNA BAY";
    //     myRow["Latitude"]=55.815857;
    //     myRow["Longitude"]=-132.97985;
    //     myRow["TimeZone"]="9";
    //     myRow["Elevation"]=298;
    //     myRow["CountyFIPS"]="130";
    //     myRow["DayLightSaving"]='Y';
    //     myRow["PreferredLastLineKey"]="Z10161";
    //     myRow["ClassificationCode"]='P';
    //     myRow["MultiCounty"]=null;
    //     myRow["StateFIPS"]="2";
    //     myRow["CityStateKey"]="9551";
    //     myRow["CityAliasCode"]=null;
    //     myRow["PrimaryRecord"]=null;
    //     myRow["CityMixedCase"]="Ketchikan";
    //     myRow["CityAliasMixedCase"]="Edna Bay";
    //     myRow["StateANSI"]="2";
    //     myRow["CountyANSI"]="130";
    //     myRow["FacilityCode"]='N';
    //     myRow["UniqueZIPName"]=null;
    //     myRow["CityDeliveryIndicator"]='N';
    //     myRow["CarrierRouteRateSortation"]='C';
    //     myRow["FinanceNumber"]="24563";
    //     myRow["CountyMixedCase"]="Ketchikan Gateway";
    //     myTable.Rows.Add(myRow);
    // }
    
    public static void AddDataRow(DataTable myTable)
    {
        DataRow myRow = myTable.NewRow();
        myRow["Name"] = "Mercy";
        myRow["Phone"] = "11212";
        myRow["Gender"] = "F";
        myTable.Rows.Add(myRow);
    }

    public static void DeleteDataRow(DataTable myTable)
    {
        // DataRow[] myRows = myTable.Select("ZipCode='99950' AND City='KETCHIKAN' AND County='KETCHIKAN GATEWAY' AND CityAliasAbbreviation=null AND CityAliasName='EDNA BAY' AND PreferredLastLineKey='Z10161' AND CityStateKey='Z10161'");
        DataRow[] myRows = myTable.Select("Gender='M'");
        Console.Write("myTable.Rows.Count: ");
        Console.WriteLine(myTable.Rows.Count);
        Console.Write("myRows.Length: ");
        Console.WriteLine(myRows.Length);
        foreach (var row in myRows)
            //myTable.Rows[myTable.Rows.IndexOf(row)].Delete();
            row.Delete();
        Console.Write("myTable.Rows.Count: ");
        Console.WriteLine(myTable.Rows.Count);
    }
    public static void DBConnection()
    {
        //create connection
        string connectString = "Data Source=127.0.0.1,1433;Initial Catalog=SybottDB;User ID=SA;Password=1Secure*Password1";
        SqlConnection conn = new SqlConnection(connectString);
        conn.Open();

        //create data adapter
        SqlDataAdapter myDataAdapter = new SqlDataAdapter("select * from SybottDB.dbo.Students", conn);
        SqlCommandBuilder mySqlCommandBuilder = new SqlCommandBuilder(myDataAdapter); 

        //create and fill dataset        
        DataSet myDataSet = new DataSet();
        myDataAdapter.Fill(myDataSet,"Students");

        //get data table reference
        DataTable myTable = myDataSet.Tables["Students"];
        //AddDataRow(myTable);
        DeleteDataRow(myTable);

        //sumbit local changes to SQL Server
        myDataAdapter.Update(myDataSet,"Students");
        myTable.AcceptChanges();
        Console.WriteLine(myTable.Rows.Count);

        myDataSet.Dispose();
        myDataAdapter.Dispose();
        conn.Close();
        conn.Dispose();

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

        using (var reader = new StreamReader(_unzipFileDirectory+_tabFileName))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {    
            csv.Configuration.Delimiter = "\t";
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
            var records = csv.GetRecords<UpdateTable>();
            foreach (var row in records)
            {
                Console.WriteLine(row.Type);
                break;
            }
        }

        // // TEST Studnets table 
        // StudentsUpdate supdate = new StudentsUpdate();
        // supdate.DBConnection();

        // // download 
        // Console.WriteLine("==================1. DOWNLOAD==================");
        // string url = "https://files.zip-codes.com/_updates_a9dh38dyq6ek/2020-06-01_UPDATE_UZJFV7B6/2020-06-Update-STANDARD.zip";
        // string fileName = DBUpdate.DownloadFile(url);
        // if (!String.IsNullOrEmpty(fileName))
        // {
        //     Console.WriteLine("文件下载成功，文件名称：" + fileName);
        // }
        // else
        // {
        //     Console.WriteLine("文件下载失败");
        //     // Application.Exit();
        // }    
        // Console.WriteLine("press Enter to continue.");
        // Console.ReadLine();

        // // unzip
        // Console.WriteLine("====================2.UNZIP===================");
        // ExtractFile();




    }

}