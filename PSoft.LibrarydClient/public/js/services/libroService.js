import { APIURL_LIBROSTOCK, APIURL_LIBROS } from "../config/constants.js";

const getLibrosWithStock = () => {
  return fetch(APIURL_LIBROSTOCK)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
};

const searchByTitulo = (q) => {
  return fetch(APIURL_LIBROSTOCK + "&titulo=" + q)
    .then((response) => response.json())
    .catch((err) => console.log("ERROR: " + err));
}


export { getLibrosWithStock, searchByTitulo };
