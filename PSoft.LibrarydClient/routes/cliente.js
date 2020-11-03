const routes = require("express").Router();
// dashboard: /cliente/
routes.get("/", (req, res) => {
  res.render("cliente/dashboard", { title: "Dashboard | Libraryd", scripts: ["cliente.js"]});
});
// cliente/alquileres
routes.get("/historial", (req, res) => {
  res.render("cliente/alquileres", { title: "Alquileres | Libraryd", scripts: ["cliente.js"] });
});
//
routes.get("/registro", (req, res) => {
  res.render("cliente/registro", {
    title: "Registrarse | Libraryd",
    scripts: ["registrar.js"],
  });
});

module.exports = routes;
