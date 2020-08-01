## Delete a row from DataTable and update to SQL Server

See more details from [this](http://www.mamicode.com/info-detail-2523323.html)

Do not use *DataTable.Rows.Remove(row)*, which equals to *DataTable.Rows[rowIndex].Delete()* and *DataTable.AcceptChanges()* combined. But *DataTable.AcceptChanges()* should be used AFTER *DataAdapter.Update()*.



## Read from .xls or .tab?

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

<img src="https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/xlsformatnotmatch.png" height="50%" width="50%"/>

So I read from .tab at last.



## NLog with VSCode

Here are two ways to use NLog in .net core application: 

1. use nlog.config
2. [configure in the code](https://github.com/NLog/NLog/wiki/Configure-from-code)

When I tried to follow the [documentation](https://github.com/NLog/NLog/wiki/Configure-from-code), it didn't work. The problem is that the configuration file was not included to complie. And the key is the sentence in ***Description/2. Create a nlog.config file***: 

> (File Properties: Copy Always)

However, instead of using VSCode, the tutorial uses Visual Studio which is able to set this property easily, just clicking the file and reseting the property. 

In VScode, file property could set in .csproj file. For example, in <ItemGroup> add <Content> element and <CopyToOutputDirectoy> element. According to [VS documentation](https://docs.microsoft.com/en-us/visualstudio/msbuild/propertygroup-element-msbuild?view=vs-2019) making such modificaiton in .csproj is equvilant to directly clicking the file and setting. 

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="NLog" Version="4.7.3" />
    <Content Include="NLog.config">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
  </ItemGroup>

</Project>
```



