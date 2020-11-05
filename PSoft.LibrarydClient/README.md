# Libraryd.Client 📚💻

A small web application project 👩‍💻 for booking and renting books from a Library 📚. **Built in .NET Core + EF Core**.

This application is a practice of the subject Software Project in the Computer Engineering degree.

The Client was required as **V3** of the practical work (API + Client).

## About Libraryd.Client

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

## Install and Usage
##### Installation
You need to install the dependencies before running the server
```shell
npm install
```
##### Use
For run the server
```shell
# for default, start with nodemon
npm start
# or use node
node app.js
```