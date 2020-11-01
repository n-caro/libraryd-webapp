const routes = require("express").Router();
// dashboard: /cliente/
routes.get("/", (req, res) => {
  res.render("cliente/dashboard", { title: "Dashboard | Libraryd" });
});
// cliente/alquileres
routes.get("/historial", (req, res) => {
  res.render("cliente/alquileres", { title: "Alquileres | Libraryd", scripts: ["cliente.js"] });
});
module.exports = routes;
