import { cardLibro } from "./components/cardLibro.js";
import { getLibrosWithStock } from "./services/libroService.js";
import { showAlert } from "./utilsDOM/showAlert.js";

const rowLibros = document.getElementById("rowLibros");
window.addEventListener(
  "load",
  () => {
    if (rowLibros) {
      loadLibrosStock();
    }
  },
  false
);

const loadLibrosStock = async () => {
  const libros = await getLibrosWithStock();
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
