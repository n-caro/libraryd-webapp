# Libraryd web-app📚
<p align="center">
<img src="https://user-images.githubusercontent.com/45347839/98265722-30c1d000-1f68-11eb-8f48-439b0134b7e4.png" alt="libraryd-logo-big"  width="40%" /></p>
<p align="center"><b>Libraryd</b></p>
<p align="center">A small web application project 👩‍💻 for booking and renting books from a Library 📚. <b>Built in .NET Core + EF Core ,  Node.js (Express + HBS) and Javascript</b> .
</p>

This application is a practice of the subject Software Project in the Computer Engineering degree 👨‍🎓 at National University Arturo Jauretche.


### About

The project has been requested in 3 versions, being v3 the final version of the project.

* V3: Web App: Client + API
* V2: API
* V1: Console Application

##### About API

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

#### About Libraryd.Client

Libraryd.Client it is a web application built in Javascript.   For the server side, uses **Node.js server**, along with **Express** for the definition of routes and **HBS** (HandleBars) as the template system. 

For client execution, pure JavaScript and some small JQuery implementations are used *(these are Acceptance Criteria requirements)*.

Finally, for libraryd.API services consumption, we use Fetch API.

##### Dependencies

###### Server side (Node.js)
* [express](https://www.npmjs.com/package/express)
* [hbs](https://www.npmjs.com/package/hbs)
###### Client side
* Boostrap v4.0
* JQuery
* fontawesome
* bootstrap-datepicker

##### Resources used 
* Favicon Generator:  https://favicon.io/favicon-generator/
* Illustrations: https://undraw.co/search
* Icons https://fontawesome.com/


## Install and usage

To install and use the API and Client, please read the README.md file within their respective directories.

* [PSoft.Libraryd/README.md](/PSoft.Libraryd/README.md)
* [PSoft.LibrarydClient/README.md](/PSoft.LibrarydClient/README.md#readme)
