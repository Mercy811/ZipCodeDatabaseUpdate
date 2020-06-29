using System;
using System.Net;
using System.IO;
using System.IO.Compression;

public static class FileHandler
{
    private static string _directory = "download/";
    private static string _zipFileName = "2020-06-Update-STANDARD.zip";
    private static string _unzipFileDirectory = _directory+ "2020-06-Update-STANDARD";

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

    static void Main(string[] args)
    {

        string url = "https://files.zip-codes.com/_updates_a9dh38dyq6ek/2020-06-01_UPDATE_UZJFV7B6/2020-06-Update-STANDARD.zip";
        string fileName = FileHandler.DownloadFile(url);
        if (!String.IsNullOrEmpty(fileName))
        {
            Console.WriteLine("文件下载成功，文件名称：" + fileName);
        }
        else
        {
            Console.WriteLine("文件下载失败");
        }   
        
        ExtractFile();
    }

}