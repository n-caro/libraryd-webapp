# Libraryd.API📚

A small web application project 👩‍💻 for booking and renting books from a Library 📚. **Built in .NET Core + EF Core**.

This application is a practice of the subject Software Project in the Computer Engineering degree.

The API was required as **V2** of the practical work.

## About API

PSoft.Libraryd is the path for the backend ⚙🧪 of the web app. The backend  is developed in **.NET Core C #**



## Install and Use

### Create Database

You need change `connectionString` value* for **appsettings.Development.json** file located in `libraryd-webapp/PSoft.Libraryd/PSoft.Libraryd.API`

`*Note:the application works with Microsoft SQLServer ` 

Now using the `update-database` command in the Package Manager Console, as below (verify that the default project is PSoft.Libraryd.API)

```shell
PM> update-database
```

Or Enter the following command in dotnet CLI.

```powershell
> dotnet ef database update --project PSoft.Libraryd.API
```

### Run

In Terminal: 

```shell
cd PSoft.Libraryd

dotnet run --project PSoft.Libraryd.API
```



