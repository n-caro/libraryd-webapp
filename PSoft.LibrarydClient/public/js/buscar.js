import { cardLibro } from "./components/cardLibro.js";
import { searchByTitulo } from "./services/libroService.js";
import { showAlert } from "./utilsDOM/showAlert.js";


const rowLibros = document.getElementById("rowLibros");

const searchFormDOM = document.getElementById("search-form");
if (searchFormDOM) {
  searchFormDOM.onsubmit = function (e) {
    e.preventDefault();
    console.log("manipulando searchForm")
    let q = searchFormDOM.elements.q.value
    let searchBy = searchFormDOM.elements.searchBy.value
    console.log("Buscando " + q + " de tipo " + searchBy)
    searchLibros(q)
  };
}


const searchLibros = async (q) => {
  const libros = await searchByTitulo(q);
  libros
    ? showLibros(libros)
    : showAlert(
        "La lista de libros no se encuentra disponible actualmente.",
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