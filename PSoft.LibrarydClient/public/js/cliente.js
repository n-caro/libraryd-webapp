import { getAlquileresCliente } from "./services/alquilerService.js";
import { showAlert } from "./utilsDOM/showAlert.js";
import { clienteSesion } from "./session.js"
import { cardAlquiler } from "./components/cardAlquiler.js";
import { cardReserva } from "./components/cardReserva.js";

const ESTADO_RESERVA = 1;
const ESTADO_ALQUILER = 2;

const historialCliente = document.getElementById("historialCliente");
window.addEventListener(
  "load",
  () => {
    if (clienteSesion && historialCliente) {
      loadAlquileres(clienteSesion.clienteId);
    }
  },
  false
);

const loadAlquileres = async (id) => {
  const responseAlquileres = await getAlquileresCliente(id);
  responseAlquileres
    ? manageResponseAlquileres(responseAlquileres)
    : showAlert(
        "El historial no encuentra disponible actualmente.",
        "warning"
      );
};

const manageResponseAlquileres = (alquileresr) => {
  if(alquileresr.clienteId){
    alquileresr.alquileres.length > 0
    ? alquileresr.alquileres.forEach(a => {
      switch(a.estado){
        case ESTADO_RESERVA:
          insertReservaDOM(a);
          break;
        case ESTADO_ALQUILER:
          insertAlquilerDOM(a);
          break;
      }
    })
    : showAlert("No has realizado algún alquiler o reserva.", "warning");
  }
  else{
    libros.error = libros.error || "Ha ocurrido un error.";
    showAlert(libros.message, "warning")
  }
  
};

const insertAlquilerDOM = (a) => {
    historialCliente.innerHTML += cardAlquiler(
      {
        id: a.id,
        fechaAlquiler : a.fechaAlquiler,
        fechaDevolucion : a.fechaDevolucion,
        libro : {
          titulo : a.libroTitulo,
          autor: a.libroAutor,
          isbn: a.libroISBN,
          edicion: a.libroEdicion,
          imagen: a.libroImagen
        }
      })
};
const insertReservaDOM = (a) => {
  historialCliente.innerHTML += cardReserva(
    {
      id: a.id,
      fechaReserva : a.fechaReserva,
      libro : {
        titulo : a.libroTitulo,
        autor: a.libroAutor,
        isbn: a.libroISBN,
        edicion: a.libroEdicion,
        imagen: a.libroImagen
      }
    })
};
