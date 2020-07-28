
using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Data.SqlClient;
using System.Data;

namespace Updating
{

public class StudentsUpdate
{
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

    public void DBConnection()
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
        AddDataRow(myTable);
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

}

}