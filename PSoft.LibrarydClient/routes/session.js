const routes = require("express").Router();
// login
routes.get("/login", (req, res) => {
  res.render("session/login", {
    title: "Acceso | Libraryd",
    scripts: ["session.js"],
  });
});
// cliente/reservas
routes.get("/logout", (req, res) => {
  res.render("session/logout", {
    title: "Cerrar sesion? | Libraryd",
    scripts: ["session.js"],
  });
});
module.exports = routes;
