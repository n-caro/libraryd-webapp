const routes = require('express').Router();

//index
routes.get('/', (req, res) => {res.render('home', {title: 'Libraryd - Biblioteca Carmen De Areco',})})
//404
routes.use(function(req, res, next) {res.status(404).render('notfound', {title: "Pagina no encontrada - Libraryd"})});

module.exports = routes;