import { cardLibro } from "./components/cardLibro.js";
import { searchByTitulo, searchByAutor } from "./services/libroService.js";
import { showAlert, showAlertRemove } from "./utilsDOM/showAlert.js";
import { getParamURL } from "./utilsDOM/getParamUrl.js";

const rowLibros = document.getElementById("rowLibros");

const searchFormDOM = document.getElementById("search-form");
if (searchFormDOM) {
  searchFormDOM.onsubmit = function (e) {
    e.preventDefault();
    cleanSearchRow();
    let q = searchFormDOM.elements.q.value;
    let searchBy = searchFormDOM.elements.searchBy.value;
    searchLibros(q, searchBy);
  };
}

const searchLibros = async (q, searchBy = 1) => {
  let libros = searchBy == 2 ? await searchByAutor(q) : await searchByTitulo(q);
  libros
    ? showLibros(libros)
    : showAlert(
        "La búsqueda de libros no se encuentra disponible actualmente.",
        "warning"
      );
};

const showLibros = (libros) => {
  libros.error
    ? showAlert(libros.message, "warning")
    : libros.map((l) => insertLibroDOM(l));
};

const insertLibroDOM = (libro) => {
  rowLibros.innerHTML += cardLibro(libro);
};

const cleanSearchRow = () => {
  rowLibros.innerHTML = "";
  showAlertRemove();
};

// search by q param (search by title)
const searchbyQuery = (q) => {
  cleanSearchRow();
  searchFormDOM.elements.q.value = q;
  searchLibros(q);
};

getParamURL("q") ? searchbyQuery(getParamURL("q")) : "";