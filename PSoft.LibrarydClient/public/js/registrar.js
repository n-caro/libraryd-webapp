import { postCliente } from "./services/clienteService.js";
import { ClienteDTO } from "./DTOs/ClienteDTO.js";
import { showAlert, showAlertRemove } from "./utilsDOM/showAlert.js";
import { cardSuccess } from "./components/cardSuccess.js"

const clienteForm = document.getElementById("registroClienteForm");

window.onload = () => {
  clienteForm.onsubmit = function (e) {
    e.preventDefault();
    showAlertRemove();
    let nombre = clienteForm.elements.nombre.value;
    let apellido = clienteForm.elements.apellido.value;
    let dni = clienteForm.elements.dni.value;
    let email = clienteForm.elements.email.value;
    registerCliente(nombre, apellido, dni, email);
  };
};

const registerCliente = async (nombre, apellido, dni, email) => {
  let cliente = new ClienteDTO(nombre, apellido, dni, email);
  let clientePost = await postCliente(cliente);
  clientePost
    ? managepostClienteResults(clientePost)
    : showAlert(
        "El servicio de registro no se encuentra disponible actualmente.",
        "warning"
      );
};

const managepostClienteResults = (clienteresponse) => {
  if (clienteresponse.clienteId) {
    clienteForm.innerHTML = cardSuccess(
      "¡Registro exitoso!",
      "Has sido registrado con éxito en nuestro sistema, continua para iniciar sesión.",
      `<a class="btn btn-primary btn-lg px-5" href="/login" role="button">Continuar</a>`
      );
  } else {
    clienteresponse.error = clienteresponse.error || "Ha ocurrido un error.";
    showAlert(clienteresponse.message, "danger");
  }
};