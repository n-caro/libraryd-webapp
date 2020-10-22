const routes = require("express").Router();
// dashboard: /cliente/
routes.get("/", (req, res) => {
  res.render("index", { title: "Dashboard | Libraryd" });
});
// cliente/reservas
routes.get("/reservas", (req, res) => {
  res.render("index", { title: "Reservas | Libraryd" });
});
// cliente/alquileres
routes.get("/reservas", (req, res) => {
  res.render("index", { title: "Alquileres | Libraryd" });
});
module.exports = routes;
