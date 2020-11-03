import { getParamURL } from "./utilsDOM/getParamUrl.js";
import { clienteSesion } from "./session.js";
import { showAlert, showAlertRemove } from "./utilsDOM/showAlert.js";
import { postAlquiler } from "./services/alquilerService.js";
import { AlquilerDTO } from "./DTOs/AlquilerDTO.js";
import { cardAlquiler } from "./components/cardAlquiler.js";
import { cardSuccess } from "./components/cardSuccess.js";

const alquilerForm = document.getElementById("alquilerForm");

$("#datepicker").datepicker({
  format: "yyyy-mm-dd",
  startDate: "today",
  maxViewMode: 2,
  todayBtn: "linked",
  language: "es",
});


const noSession = () => {
  showAlert(`Debes <a href="/login">iniciar sesión</a> para realizar un alquiler`, "danger")
  let btn = document.getElementById('btnsubmit').disabled =true;
}
// alquilar
if (alquilerForm) {
  clienteSesion
    ? (alquilerForm.elements.clienteid.value = clienteSesion.clienteId)
    : noSession();
  alquilerForm.onsubmit = function (e) {
    e.preventDefault();
    showAlertRemove();
    let clienteid = Number(alquilerForm.elements.clienteid.value);
    let isbn = alquilerForm.elements.isbn.value;
    let fechaalquiler = alquilerForm.elements.fechaalquiler.value;
    validateAlquilerFields(clienteid, isbn, fechaalquiler)
      ? generateAlquiler(new AlquilerDTO(clienteid, isbn, fechaalquiler))
      : "";
  };
}

// isbn by param
const addISBNquery = (isbn) => {
  alquilerForm.elements.isbn.value = isbn;
};
getParamURL("isbn") ? addISBNquery(getParamURL("isbn")) : "";

// post
const generateAlquiler = async (data) => {
  let alquilerPost = await postAlquiler(data);
  alquilerPost
    ? manageAlquilerResults(alquilerPost)
    : showAlert(
        "El servicio de alquiler no se encuentra disponible actualmente, intente nuevamente en unos minutos.",
        "warning"
      );
};

const manageAlquilerResults = (alquiler) => {
  if (alquiler.cliente) {
    alquilerForm.innerHTML = cardSuccess(
      "Alquiler creado",
      "El alquiler ha sido creada con éxito. Detalles:",
      cardAlquiler(alquiler)
    );
  } else {
    alquiler.error = alquiler.error || "Ha ocurrido un error.";
    showAlert(alquiler.message, "danger");
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
