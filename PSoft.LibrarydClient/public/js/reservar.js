import { getParamURL } from "./utilsDOM/getParamUrl.js";
import { clienteSesion } from "./session.js";
import { showAlert, showAlertRemove } from "./utilsDOM/showAlert.js";
import { postAlquiler } from "./services/alquilerService.js";
import { ReservaDTO } from "./DTOs/AlquilerDTO.js";
import { cardReserva } from "./components/cardReserva.js";
import { cardSuccess} from "./components/cardSuccess.js"

const reservaForm = document.getElementById("reservaForm");

$("#datepicker").datepicker({
  format: "yyyy-mm-dd",
  startDate: "today",
  maxViewMode: 2,
  todayBtn: "linked",
  language: "es",
});

const noSession = () => {
  showAlert(`Debes <a href="/login">iniciar sesión</a> para realizar una reserva`, "danger")
  let btn = document.getElementById('btnsubmit').disabled =true;
}

// alquilar
if (reservaForm) {
  clienteSesion
    ? (reservaForm.elements.clienteid.value = clienteSesion.clienteId)
    : noSession();
  reservaForm.onsubmit = function (e) {
    e.preventDefault();
    showAlertRemove();
    let clienteid = Number(reservaForm.elements.clienteid.value);
    let isbn = reservaForm.elements.isbn.value;
    let fechareserva = reservaForm.elements.fechareserva.value;
    validateAlquilerFields(clienteid, isbn, fechareserva)
      ? generateAlquiler(new ReservaDTO(clienteid, isbn, fechareserva))
      : "";
  };
}

// isbn by param
const addISBNquery = (isbn) => {
  reservaForm.elements.isbn.value = isbn;
};
getParamURL("isbn") ? addISBNquery(getParamURL("isbn")) : "";

// post
const generateAlquiler = async (data) => {
  let alquilerPost = await postAlquiler(data);
  alquilerPost
    ? manageAlquilerResults(alquilerPost)
    : showAlert(
        "El servicio de reserva no se encuentra disponible actualmente, intente nuevamente en unos minutos.",
        "warning"
      );
};

const manageAlquilerResults = (reserva) => {
  if (reserva.cliente) {
    reservaForm.innerHTML = cardSuccess("Reserva creada", "La reserva ha sido creada con éxito", cardReserva(reserva) )
  } else {
    reserva.error = reserva.error || "Ha ocurrido un error al solicitar la reserva.";
    showAlert(reserva.message, "danger");
  }
};

// validator
const validateAlquilerFields = (clienteid, isbn, fecha) => {
  if (isNaN(clienteid)) {
    showAlert("ID de cliente ingresado no es válido.", "danger");
    return false;
  }
  if (isbn == "") {
    showAlert("Debe ingresar un ISBN.", "danger");
    return false;
  }
  let fechaDate = Date.parse(fecha + "T00:00:00");
  let today = new Date().setHours(0, 0, 0, 0);
  if (isNaN(fechaDate) || fechaDate < today) {
    let errormsg = isNaN(fechaDate)
      ? "Ingrese fecha en formato AAAA-MM-DD"
      : "No se aceptan fechas anteriores al día de hoy.";
    showAlert("La fecha ingresada no válida. " + errormsg, "danger");
    return false;
  }
  return true;
};
