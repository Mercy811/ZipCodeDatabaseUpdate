## Development Environment

- VS Code 1.46.0
- SQL Server   *docker image*: mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

- macOS 10.15.5



## SQL Server on macOS

1. **Install SQL Server on macOS**

https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup?view=sql-server-ver15

```
sudo docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
```

2. **Install sqlcmd (command-line query utility) and bcp (Bulk import-export utility) on macOS**

https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup-tools?view=sql-server-ver15

The SQL Server command-line tools are already included in the SQL Server Linux container image. But if we want to use command-line tools outside the container, we have to install it.

```
brew tap microsoft/mssql-release https://github.com/Microsoft/homebrew-mssql-release 
brew update 
brew install mssql-tools
```

3. **Run SQL Server Docker image**

https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

```
docker run --name sql1 \
                    -e 'ACCEPT_EULA=Y’ \
                    -e 'SA_PASSWORD=1Secure*Password1’ \
                    -e 'MSSQL_PID=Enterprise’ \
                    -p 1433:1433 \
                    -v ~/Desktop/sybott/dbManagement/://usr/data/ \
                    -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04
```

4. **Connect to SQL Server**

```
# scenario1: connect outside the container 
sqlcmd -S 127.0.0.1,1433 -U SA -P '1Secure*Password1'

# scenario2: connect inside the container
sudo docker exec -it sql1 "bash" \
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "1Secure*Password1"
```

[Use Visual Studio Code to create and run Transact-SQL scripts](https://docs.microsoft.com/en-us/sql/visual-studio-code/sql-server-develop-use-vscode?view=sql-server-ver15)

**Cannot login?**

	Sqlcmd: Error: Microsoft ODBC Driver 17 for SQL Server : Login failed for user 'SA'..
Maybe due to the password complexity. Checkout [this](https://github.com/microsoft/mssql-docker/issues/315#issuecomment-392957615)



## Task Description

1. **Download a .zip file from  [this website](https://www.zip-codes.com/account_dbupdate.asp) **

<img src="https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/image-20200630001705593.png" alt="image-20200630001705593" style="zoom:40%;" />



locate the .zip file url

<img src="https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/image-20200630005054885.png" alt="image-20200630005054885" style="zoom:50%;" />

Run **crawler.cs** and it will 

- download *2020-06-Update-STANDARD.zip* file in download directory and
- unzip it to *./download/2020-06-Update-STANDARD* directory which has two files: *2020-06-Update-STANDARD.tab* and *2020-06-Update-STANDARD.xls*

```
dotnet run
```

