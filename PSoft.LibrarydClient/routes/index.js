const routes = require("express").Router();
const cliente = require("./cliente");
const session = require("./session");
const libros = require("./libros");

//index
routes.get("/", (req, res) => {
  res.render("index", { title: "Libraryd - Biblioteca Carmen De Areco" });
});

// import routes
routes.use("/cliente", cliente);
routes.use("/", session);
routes.use("/libros", libros);

//404
routes.use(function (req, res, next) {
  res
    .status(404)
    .render("notfound", { title: "Pagina no encontrada - Libraryd" });
});

module.exports = routes;
