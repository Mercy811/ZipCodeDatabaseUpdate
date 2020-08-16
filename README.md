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
                    -v ~/Desktop/sybott/dbManagement/://usr/dbManagement/ \
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

5. **Initialize ZIPCodes table**

We need to go inside the docker container and copy the zipcode.csv file to another directory, since problem occures when in mount directory.

```
# go inside the docker
docker exec -it docker-id /bin/bash
# copy zipcode.csv to another directory
mkdir /usr/data
cp /usr/dbManagement/zipcode.csv /usr/data/
```



## Task Description

1. **Download a .zip file from  [this website](https://www.zip-codes.com/account_dbupdate.asp)**

- Clean cookies of Chrome: shift+cmd+delete

<img src="https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/clean-cookie.png" style="zoom:50%;" />

when click the buttom in the below picture, Postman will capture two package

<img src="https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/image-20200630001705593.png" style="zoom:40%;" />

- Send POST request to https://www.zip-codes.com/account_login.asp to get cookies
- Send GET request to https://www.zip-codes.com/account_dbupdate.asp?t=s&action=dl&dluID=3555 to get the locaiton of zip file

Download *YYYY-MM-Update-STANDARD.zip* file in download directory 

2. **Unzip file**

Unzip *YYYY-MM-Update-STANDARD.zip* to *./download/YYYY-MM-Update-STANDARD* directory which has two files: *YYYY-MM-Update-STANDARD.tab* and *YYYY-MM-Update-STANDARD.xls*

2. **Initialize ZIPCodes DB**

   run *insertData.sql* 

3. **Insert and delete operation**

4. **Read update information from *download/2020-06-Update-STANDARD/2020-06-Update-STANDARD.tab***




# Sensitive Data

Cause *update.cs* includes tokens of twilio and DB so [git-crypt](https://github.com/AGWA/git-crypt) is used to encrypte this file to binary. 

Both GPG and symmetric key are supported.

-  **GPG**

First, I need to add the GPG ID of the person I want to share with the following command

```
git-crypt add-gpg-user USER_ID
```

It will add and commit a GPG-encrypted key file in the *.git-crypt* directory of the root of the repository

<img src="https://github.com/Mercy811/ZipCodeDatabaseUpdate/blob/master/img/add-gpg-user.jpeg" style="zoom:50%;" />

After cloning encrypted file, unlock with GPG

```
git-crypt unlock
```

- **Symmetric Key**

Already exported symmetric key using the following command

```
git-crypt export-key .git-crypt/symmetric-keys/key
```

I can share the generated *.git-crypt/symmetric-keys/key* file to collaborators and they can unlock the encrypted file

```
git-crypt unlock /path/to/key
```



