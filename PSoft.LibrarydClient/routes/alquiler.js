const routes = require("express").Router();

routes.get("/alquilar", (req, res) => {
  res.render("alquiler/alquilar", {
    title: "Alquilar libro | Libraryd",
    scripts: ["bootstrap-datepicker.min.js", "locale/bootstrap-datepicker.es.min.js", "alquiler.js"],
  });
});

routes.get("/reservar", (req, res) => {
  res.render("alquiler/reserva", {
    title: "Reservar libro | Libraryd",
    scripts: ["bootstrap-datepicker.min.js", "locale/bootstrap-datepicker.es.min.js", "reserva.js"],
  });
});

module.exports = routes;
