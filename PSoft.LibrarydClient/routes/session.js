const routes = require("express").Router();
routes.get("/login", (req, res) => {
  res.render("session/login", {
    title: "Acceso | Libraryd",
    scripts: ["session.js"],
  });
});
routes.get("/logout", (req, res) => {
  res.render("session/logout", {
    title: "Cerrar sesion? | Libraryd",
    scripts: ["session.js"],
  });
});

routes.get('/registro', (req, res) => {
  res.redirect('/cliente/registro');
});
module.exports = routes;
