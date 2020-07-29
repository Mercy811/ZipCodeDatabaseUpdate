- **How to delete a row from DataTable and update to SQL Server?**
- **Why the delete result does not update to SQL Server?**

See more details from [this](http://www.mamicode.com/info-detail-2523323.html)

Do not use *DataTable.Rows.Remove(row)*, which equals to *DataTable.Rows[rowIndex].Delete()* and *DataTable.AcceptChanges()* combined. But *DataTable.AcceptChanges()* should be used AFTER *DataAdapter.Update()*.



- **read from .xls or .tab?**

At first, I tried to extract data from .xls to DataTable

```
public static DataTable ExcelToDataTableUsingExcelDataReader(string storePath)
{
    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    FileStream stream = File.Open(storePath, FileMode.Open, FileAccess.Read);
    
    var reader = ExcelReaderFactory.CreateReader(stream);

    DataSet excelDataset = reader.AsDataSet();
    DataTable excelDataTable = excelDataset.Tables[0];
    return excelDataTable;
}
```

but got the following error

```
Unhandled exception. ExcelDataReader.Exceptions.HeaderException: Invalid file signature.
   at ExcelDataReader.ExcelReaderFactory.CreateReader(Stream fileStream, ExcelReaderConfiguration configuration)
   at DBUpdate.ExcelToDataTableUsingExcelDataReader(String storePath) in /Users/xinyi.ye/Desktop/sybott/dbManagement/update.cs:line 141
   at DBUpdate.Main(String[] args) in /Users/xinyi.ye/Desktop/sybott/dbManagement/update.cs:line 151
```

when I tried to open this .xls file, I got the prompt window. This is probably the reason why I got an exception when using *ExcelDataReader*.

![prompt window from Excel](https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/xlsformatnotmatch.png){:height="50%" width="50%"}

So I read from .tab at last.

