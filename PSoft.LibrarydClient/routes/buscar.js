const routes = require("express").Router();
// /buscar
routes.get("/", (req, res) => {
  res.render("search/index", {
    title: "Buscar | Libraryd",
    scripts: ["buscar.js"],
  });
});
module.exports = routes;
