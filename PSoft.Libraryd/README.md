# Libraryd.API📚

A small web application project 👩‍💻 for booking and renting books from a Library 📚. **Built in .NET Core + EF Core**.

This application is a practice of the subject Software Project in the Computer Engineering degree.

The API was required as **V2** of the practical work.

## About API

PSoft.Libraryd is the path for the backend ⚙🧪 of the web app. The backend  is developed in **.NET Core C #**

###### Architecture

* Layered Architecture Pattern
  * API Layer
  * Application Layer
  * Domain Layer
  * AccessData Layer
* REST API level 2

######  Design Patterns

* Some S.O.L.I.D principles
* Dependency injection
* CQRS (Command Query Responsibility Segregation)

###### Framework and tools
Builted in ASP.NET Core C # with the following tools:
* Entity Framework Core *(Code First approach)*
* SQL Kata
* Swagger, for API documentation 📄

------

## Install and Usage

#### Create Database

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
#### Run
In Terminal: 

```shell
cd PSoft.Libraryd
dotnet run --project PSoft.Libraryd.API
```
Now, you can go to the url. For default are `https://localhost:5000` and `https://localhost:5001`

Docs in swagger:  https://localhost:5001/swagger

------

## Changelog

##### V3.0.0

Released: 2020/11/6

Features:
* Improved search 🔍: Search has been improved, using 'LIKE' in Query for searches.
* Preload Libros on migration 📚: New Libros  have been loaded by default during migration, now with the "image" field loaded (external image URL).

Bugfixes:
* Deleted "Estado1" Fk in Alquileres Table.
* Order DESC in GetAlquileresByCliente query
* Bug in AlquilerService, fechaAlquiler validator. Fixed, now accept today date.
* Bug: AlquilerServices - FechaDevolucion.  "fechaDevolucion" now adds 7 days to "fechaAlquiler".

