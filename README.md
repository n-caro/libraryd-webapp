# Libraryd 📚

A small web application project 👩‍💻 for booking and renting books from a Library 📚. **Built in .NET Core + EF Core**.

This application is a practice of the subject Software Project in the Computer Engineering degree.

## Change connectionString of Database (temporal solution)
**⚠ This is a temporary solution **. We are working on a hotfix that will modify the connectionString on a single filesettings / fileconfig. ⚠

But meanwhile:
You need to **change the value of the connectionString** variable in **LibrarydDbContext.cs** (AcessData) and **ContainerBuilder.cs** (Presentation)
* For **LibrarydDbContext.cs**: Go to file libraryd-webapp/PSoft.Libraryd/PSoft.Libraryd.AcessData/LibrarydDbContext.cs , and change the value of the string connectionString (at line 12)
* For **ContainerBuilder.cs**: Go to file libraryd-webapp/PSoft.Libraryd/PSoft.Libraryd.Presentation/ContainerBuilder.cs , and change the value of the string connectionString (at line 24)
## Create database
For create a new migration, open NuGet Package Manager Console and type: 
```
update-database -P PSoft.Libraryd.AcessData
```

## Create migration
For create a new migration, open NuGet Package Manager Console and type: 
```
update-database -P PSoft.Libraryd.AcessData
```
