import { APIURL_LIBROSTOCK, APIURL_LIBROS } from "../config/constants.js";

const getLibrosWithStock = () => {
  return fetch(APIURL_LIBROSTOCK)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

const searchByTitulo = (q) => {
  return fetch(APIURL_LIBROS + "?titulo=" + q)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

const searchByAutor = (q) => {
  return fetch(APIURL_LIBROS + "?autor=" + q)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

export { getLibrosWithStock, searchByTitulo, searchByAutor };
