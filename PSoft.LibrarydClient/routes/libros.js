const routes = require("express").Router();
// /libros
routes.get("/", (req, res) => {
  res.render("libros/index", {
    title: "Libros disponibles | Libraryd",
    scripts: ["libros.js"],
  });
});
module.exports = routes;
